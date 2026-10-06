#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_undocumented_formats.cs
// Build the research backlog at src/_data/undocumented_formats.yml.

#pragma warning disable IL3050

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(rootDir, "catalog");
var outputFile = Path.Combine(rootDir, "src", "_data", "undocumented_formats.yml");

if (!Directory.Exists(catalogDir))
{
    Console.Error.WriteLine($"Catalog directory not found: {catalogDir}");
    return 1;
}

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();
var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var backlog = new List<Dictionary<string, object?>>();

foreach (var sourceFile in Directory.GetFiles(catalogDir, "index.md", SearchOption.AllDirectories)
             .OrderBy(path => path, StringComparer.OrdinalIgnoreCase))
{
    var extensionDir = Path.GetDirectoryName(sourceFile)!;
    var extension = Path.GetFileName(extensionDir);
    var letter = Path.GetFileName(Path.GetDirectoryName(extensionDir)!);
    var lines = File.ReadAllLines(sourceFile);

    if (lines.Length < 3 || lines[0].Trim() != "---")
        continue;

    var frontmatterEnd = Array.FindIndex(lines, 1, line => line.Trim() == "---");
    if (frontmatterEnd < 0)
        continue;

    var frontmatterText = string.Join("\n", lines.Skip(1).Take(frontmatterEnd - 1));
    var body = string.Join("\n", lines.Skip(frontmatterEnd + 1)).Trim();
    var frontmatter = deserializer.Deserialize<Dictionary<string, object?>>(frontmatterText) ?? new();

    if (!frontmatter.TryGetValue("extensions", out var resourcesValue))
        continue;

    var resources = EnumerateMappings(resourcesValue).ToList();
    if (resources.Count == 0)
        continue;

    var hasAvailableFile = false;
    var hasActiveLink = false;
    var missingFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var unavailableLinks = 0;
    var names = new List<string>();
    var categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    foreach (var resource in resources)
    {
        var name = GetString(resource, "name") ?? GetString(resource, "title");
        if (!string.IsNullOrWhiteSpace(name) && !names.Contains(name, StringComparer.OrdinalIgnoreCase))
            names.Add(name);

        foreach (var category in GetStrings(resource, "categories"))
            categories.Add(category);
        foreach (var category in GetStrings(resource, "category"))
            categories.Add(category);

        var fileName = GetString(resource, "file");
        if (!string.IsNullOrWhiteSpace(fileName))
        {
            if (File.Exists(Path.Combine(extensionDir, fileName)))
                hasAvailableFile = true;
            else
                missingFiles.Add(fileName);
        }

        var link = GetString(resource, "link") ?? GetString(resource, "url");
        if (!string.IsNullOrWhiteSpace(link))
        {
            if (!GetBool(resource, "badlink"))
                hasActiveLink = true;
            else
                unavailableLinks++;
        }
    }

    if (!string.IsNullOrWhiteSpace(body) || hasAvailableFile || hasActiveLink)
        continue;

    var reason = missingFiles.Count > 0
        ? missingFiles.Count == 1 ? "Missing archived file" : $"{missingFiles.Count} missing archived files"
        : unavailableLinks > 0
            ? unavailableLinks == 1 ? "Unavailable external link" : "Unavailable external links"
            : "No source material recorded";

    backlog.Add(new Dictionary<string, object?>
    {
        ["extension"] = extension,
        ["letter"] = letter,
        ["url"] = $"/extensions/{letter}/{extension}/",
        ["name"] = names.FirstOrDefault() ?? extension,
        ["additional_meanings"] = Math.Max(0, names.Count - 1),
        ["categories"] = categories.OrderBy(value => value, StringComparer.OrdinalIgnoreCase).ToList(),
        ["reason"] = reason,
        ["missing_files"] = missingFiles.OrderBy(value => value, StringComparer.OrdinalIgnoreCase).ToList()
    });
}

backlog = backlog
    .OrderBy(item => item["extension"]?.ToString(), StringComparer.OrdinalIgnoreCase)
    .ToList();

var output = new Dictionary<string, object?>
{
    ["count"] = backlog.Count,
    ["criteria"] = "No detailed format notes, no preserved local specification, and no active external reference.",
    ["formats"] = backlog
};

Directory.CreateDirectory(Path.GetDirectoryName(outputFile)!);
File.WriteAllText(outputFile, serializer.Serialize(output));
Console.WriteLine($"Generated undocumented formats backlog with {backlog.Count} entries.");
return 0;

IEnumerable<IDictionary<object, object?>> EnumerateMappings(object? value)
{
    if (value is IDictionary<object, object> objectMapping)
    {
        yield return objectMapping.ToDictionary(pair => pair.Key, pair => (object?)pair.Value);
        yield break;
    }

    if (value is IEnumerable sequence and not string)
    {
        foreach (var item in sequence)
        foreach (var mapping in EnumerateMappings(item))
            yield return mapping;
    }
}

object? GetValue(IDictionary<object, object?> mapping, string key)
{
    var pair = mapping.FirstOrDefault(item => string.Equals(item.Key?.ToString(), key, StringComparison.OrdinalIgnoreCase));
    return pair.Key == null ? null : pair.Value;
}

string? GetString(IDictionary<object, object?> mapping, string key)
{
    return GetValue(mapping, key)?.ToString()?.Trim();
}

IEnumerable<string> GetStrings(IDictionary<object, object?> mapping, string key)
{
    var value = GetValue(mapping, key);
    if (value is string text)
        return string.IsNullOrWhiteSpace(text) ? [] : [text.Trim()];
    if (value is IEnumerable sequence)
        return sequence.Cast<object?>()
            .Select(item => item?.ToString()?.Trim())
            .Where(item => !string.IsNullOrWhiteSpace(item))
            .Cast<string>();
    return [];
}

bool GetBool(IDictionary<object, object?> mapping, string key)
{
    var value = GetValue(mapping, key);
    return value is bool boolean
        ? boolean
        : bool.TryParse(value?.ToString(), out var parsed) && parsed;
}
