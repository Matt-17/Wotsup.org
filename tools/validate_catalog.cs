#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/validate_catalog.cs
// Read-only Phase 1 catalog validator. This does not generate or modify files.
// Run from the repository root with: dotnet tools/validate_catalog.cs

#pragma warning disable IL3050 // Dynamic code warnings are not relevant for build-time tooling.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

var rootDir = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(rootDir, "catalog");
var categoriesFile = Path.Combine(catalogDir, "categories.yaml");
var strict = args.Any(a => a.Equals("--strict", StringComparison.OrdinalIgnoreCase));

var errors = new List<string>();
var warnings = new List<string>();
var categoryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
var extensionSlugs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var aliasOwners = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
var extensionFileCount = 0;
var extensionEntryCount = 0;
var attachedFileReferences = 0;

var deserializer = new DeserializerBuilder().Build();

if (!Directory.Exists(catalogDir))
{
    errors.Add("Missing catalog directory.");
    return Finish();
}

ValidateCategories();
ValidateCatalogEntries();

return Finish();

void ValidateCategories()
{
    if (!File.Exists(categoriesFile))
    {
        errors.Add("Missing catalog/categories.yaml.");
        return;
    }

    List<object> categories;
    try
    {
        categories = AsList(deserializer.Deserialize<object?>(File.ReadAllText(categoriesFile))).ToList();
    }
    catch (Exception ex)
    {
        errors.Add($"catalog/categories.yaml: failed to parse YAML: {ex.Message}");
        return;
    }

    if (categories.Count == 0)
        errors.Add("catalog/categories.yaml: expected at least one category.");

    foreach (var (category, index) in categories.Select((value, index) => (value, index + 1)))
    {
        if (!TryMap(category, out var map))
        {
            errors.Add($"catalog/categories.yaml: category #{index} must be a mapping.");
            continue;
        }

        var name = GetString(map, "name");
        var shortName = GetString(map, "short");
        var title = GetString(map, "title");
        var description = GetString(map, "description");

        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add($"catalog/categories.yaml: category #{index} missing required 'name'.");
            continue;
        }

        if (!Regex.IsMatch(name, "^[a-z0-9]+(?:-[a-z0-9]+)*$"))
            errors.Add($"catalog/categories.yaml: category '{name}' should use lowercase kebab-case.");

        if (!categoryNames.Add(name))
            errors.Add($"catalog/categories.yaml: duplicate category '{name}'.");

        if (string.IsNullOrWhiteSpace(shortName))
            errors.Add($"catalog/categories.yaml: category '{name}' missing required 'short'.");
        if (string.IsNullOrWhiteSpace(title))
            errors.Add($"catalog/categories.yaml: category '{name}' missing required 'title'.");
        if (string.IsNullOrWhiteSpace(description))
            warnings.Add($"catalog/categories.yaml: category '{name}' has no description.");
    }
}

void ValidateCatalogEntries()
{
    foreach (var bucketDir in Directory.GetDirectories(catalogDir).OrderBy(d => d, StringComparer.OrdinalIgnoreCase))
    {
        var bucket = Path.GetFileName(bucketDir);
        if (string.IsNullOrWhiteSpace(bucket))
            continue;

        if (!IsExpectedBucket(bucket))
        {
            warnings.Add($"{Rel(bucketDir)}: unexpected catalog bucket name. Expected '0-9' or a lowercase letter.");
            continue;
        }

        foreach (var directYaml in Directory.GetFiles(bucketDir, "*.yml").Concat(Directory.GetFiles(bucketDir, "*.yaml")))
            warnings.Add($"{Rel(directYaml)}: legacy direct YAML files are transitional; prefer <extension>/index.md.");

        foreach (var entryDir in Directory.GetDirectories(bucketDir).OrderBy(d => d, StringComparer.OrdinalIgnoreCase))
            ValidateEntryDirectory(bucket, entryDir);
    }
}

void ValidateEntryDirectory(string bucket, string entryDir)
{
    var slug = Path.GetFileName(entryDir);
    if (string.IsNullOrWhiteSpace(slug))
        return;

    var expectedBucket = ExpectedBucketForSlug(slug);
    if (!string.Equals(bucket, expectedBucket, StringComparison.OrdinalIgnoreCase))
        errors.Add($"{Rel(entryDir)}: slug '{slug}' belongs under catalog/{expectedBucket}/, not catalog/{bucket}/.");

    if (!Regex.IsMatch(slug, "^[a-z0-9][a-z0-9_.+-]*$"))
        warnings.Add($"{Rel(entryDir)}: extension directory should use lowercase URL-safe characters.");

    if (extensionSlugs.TryGetValue(slug, out var existingPath))
        errors.Add($"{Rel(entryDir)}: duplicate extension slug '{slug}' also used by {existingPath}.");
    else
        extensionSlugs[slug] = Rel(entryDir);

    var indexMd = Path.Combine(entryDir, "index.md");
    var indexYaml = Path.Combine(entryDir, "index.yaml");
    if (!File.Exists(indexMd) && !File.Exists(indexYaml))
    {
        errors.Add($"{Rel(entryDir)}: missing index.md.");
        return;
    }

    if (File.Exists(indexYaml))
        warnings.Add($"{Rel(indexYaml)}: index.yaml is transitional; prefer index.md with front matter.");

    if (!File.Exists(indexMd))
        return;

    extensionFileCount++;
    if (!TryExtractFrontMatter(indexMd, out var frontMatter))
        return;

    Dictionary<object, object> document;
    try
    {
        var parsed = deserializer.Deserialize<object?>(frontMatter);
        if (!TryMap(parsed, out document))
        {
            errors.Add($"{Rel(indexMd)}: front matter must be a YAML mapping.");
            return;
        }
    }
    catch (Exception ex)
    {
        errors.Add($"{Rel(indexMd)}: failed to parse front matter: {ex.Message}");
        return;
    }

    var extensionSlug = GetString(document, "extension");
    if (!string.IsNullOrWhiteSpace(extensionSlug) && !string.Equals(extensionSlug, slug, StringComparison.OrdinalIgnoreCase))
        errors.Add($"{Rel(indexMd)}: front matter extension '{extensionSlug}' does not match directory slug '{slug}'.");

    if (!TryGet(document, "extensions", out var extensionsValue))
    {
        errors.Add($"{Rel(indexMd)}: missing required 'extensions' list.");
        return;
    }

    var extensionItems = AsList(extensionsValue).ToList();
    if (extensionItems.Count == 0)
    {
        errors.Add($"{Rel(indexMd)}: 'extensions' must contain at least one entry.");
        return;
    }

    foreach (var (item, index) in extensionItems.Select((value, index) => (value, index + 1)))
        ValidateExtensionItem(indexMd, entryDir, slug, item, index);
}

void ValidateExtensionItem(string indexMd, string entryDir, string slug, object item, int index)
{
    if (!TryMap(item, out var map))
    {
        errors.Add($"{Rel(indexMd)}: extensions[{index}] must be a mapping.");
        return;
    }

    extensionEntryCount++;

    var name = GetString(map, "name");
    var description = GetString(map, "description");

    if (string.IsNullOrWhiteSpace(name))
        errors.Add($"{Rel(indexMd)}: extensions[{index}] missing required 'name'.");
    if (string.IsNullOrWhiteSpace(description))
        warnings.Add($"{Rel(indexMd)}: extensions[{index}] has no description.");

    var categories = ReadCategories(map).ToList();
    if (categories.Count == 0)
    {
        errors.Add($"{Rel(indexMd)}: extensions[{index}] missing required 'categories'.");
    }
    else
    {
        foreach (var category in categories)
        {
            if (!categoryNames.Contains(category))
                errors.Add($"{Rel(indexMd)}: extensions[{index}] references unknown category '{category}'.");
        }
    }

    if (TryGet(map, "file", out var fileValue))
    {
        var fileName = ScalarString(fileValue);
        if (string.IsNullOrWhiteSpace(fileName))
        {
            errors.Add($"{Rel(indexMd)}: extensions[{index}] has an empty 'file' value.");
        }
        else
        {
            attachedFileReferences++;
            var filePath = Path.Combine(entryDir, fileName);
            if (!File.Exists(filePath))
                warnings.Add($"{Rel(indexMd)}: extensions[{index}] references missing file '{fileName}'.");
        }
    }

    if (TryGet(map, "link", out var linkValue))
    {
        var link = ScalarString(linkValue);
        if (!string.IsNullOrWhiteSpace(link) &&
            !Uri.TryCreate(link, UriKind.Absolute, out var uri) &&
            !link.StartsWith("/", StringComparison.Ordinal))
        {
            warnings.Add($"{Rel(indexMd)}: extensions[{index}] link '{link}' is not an absolute or root-relative URL.");
        }
    }

    foreach (var alias in ReadStringList(map, "aliases"))
    {
        if (string.Equals(alias, slug, StringComparison.OrdinalIgnoreCase))
            warnings.Add($"{Rel(indexMd)}: extensions[{index}] alias '{alias}' duplicates the extension slug.");

        if (aliasOwners.TryGetValue(alias, out var owner) && !string.Equals(owner, slug, StringComparison.OrdinalIgnoreCase))
            warnings.Add($"{Rel(indexMd)}: alias '{alias}' is also used by extension '{owner}'.");
        else
            aliasOwners[alias] = slug;
    }
}

IEnumerable<string> ReadCategories(Dictionary<object, object> map)
{
    var values = new List<string>();
    values.AddRange(ReadStringList(map, "categories"));
    values.AddRange(ReadStringList(map, "category"));
    return values.Where(v => !string.IsNullOrWhiteSpace(v)).Distinct(StringComparer.OrdinalIgnoreCase);
}

IEnumerable<string> ReadStringList(Dictionary<object, object> map, string key)
{
    if (!TryGet(map, key, out var value) || value is null)
        yield break;

    foreach (var item in AsList(value))
    {
        var text = ScalarString(item);
        if (!string.IsNullOrWhiteSpace(text))
            yield return text.Trim();
    }
}

bool TryExtractFrontMatter(string file, out string frontMatter)
{
    frontMatter = "";
    var lines = File.ReadAllLines(file);
    if (lines.Length == 0 || lines[0].Trim() != "---")
    {
        errors.Add($"{Rel(file)}: missing opening front matter delimiter.");
        return false;
    }

    for (var i = 1; i < lines.Length; i++)
    {
        if (lines[i].Trim() == "---")
        {
            frontMatter = string.Join("\n", lines.Skip(1).Take(i - 1));
            if (string.IsNullOrWhiteSpace(frontMatter))
                errors.Add($"{Rel(file)}: empty front matter.");
            return !string.IsNullOrWhiteSpace(frontMatter);
        }
    }

    errors.Add($"{Rel(file)}: missing closing front matter delimiter.");
    return false;
}

bool TryMap(object? value, out Dictionary<object, object> map)
{
    if (value is Dictionary<object, object> typed)
    {
        map = typed;
        return true;
    }

    map = new Dictionary<object, object>();
    return false;
}

bool TryGet(Dictionary<object, object> map, string key, out object? value)
{
    foreach (var kvp in map)
    {
        if (string.Equals(kvp.Key?.ToString(), key, StringComparison.OrdinalIgnoreCase))
        {
            value = kvp.Value;
            return true;
        }
    }

    value = null;
    return false;
}

string GetString(Dictionary<object, object> map, string key)
{
    return TryGet(map, key, out var value) ? ScalarString(value) : "";
}

string ScalarString(object? value)
{
    return value switch
    {
        null => "",
        string s => s.Trim(),
        _ when value is IEnumerable && value is not string => "",
        _ => value.ToString()?.Trim() ?? ""
    };
}

IEnumerable<object> AsList(object? value)
{
    if (value is null)
        yield break;

    if (value is string)
    {
        yield return value;
        yield break;
    }

    if (value is Dictionary<object, object>)
    {
        yield return value;
        yield break;
    }

    if (value is IEnumerable sequence)
    {
        foreach (var item in sequence)
            if (item is not null)
                yield return item;
        yield break;
    }

    yield return value;
}

bool IsExpectedBucket(string bucket)
{
    return bucket == "0-9" || Regex.IsMatch(bucket, "^[a-z]$");
}

string ExpectedBucketForSlug(string slug)
{
    if (string.IsNullOrWhiteSpace(slug))
        return "";

    var first = char.ToLowerInvariant(slug[0]);
    return char.IsDigit(first) ? "0-9" : first.ToString();
}

string Rel(string path)
{
    return Path.GetRelativePath(rootDir, path).Replace('\\', '/');
}

int Finish()
{
    if (strict && warnings.Count > 0)
        errors.AddRange(warnings.Select(w => $"strict warning: {w}"));

    Console.WriteLine("Catalog validation summary");
    Console.WriteLine($"  Catalog files: {extensionFileCount}");
    Console.WriteLine($"  Extension entries: {extensionEntryCount}");
    Console.WriteLine($"  File references: {attachedFileReferences}");
    Console.WriteLine($"  Categories: {categoryNames.Count}");
    Console.WriteLine($"  Errors: {errors.Count}");
    Console.WriteLine($"  Warnings: {warnings.Count}");
    Console.WriteLine();

    if (errors.Count > 0)
    {
        Console.Error.WriteLine("Errors:");
        foreach (var error in errors.Distinct())
            Console.Error.WriteLine($"  - {error}");
        Console.Error.WriteLine();
    }

    if (warnings.Count > 0)
    {
        Console.WriteLine("Warnings:");
        foreach (var warning in warnings.Distinct())
            Console.WriteLine($"  - {warning}");
        Console.WriteLine();
    }

    if (errors.Count == 0)
    {
        Console.WriteLine("Catalog validation passed.");
        return 0;
    }

    Console.Error.WriteLine("Catalog validation failed.");
    return 1;
}
