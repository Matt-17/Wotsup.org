#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_letters.cs
// Generate letter pages only for existing extensions and write _data/letters.yml
// Run with: dotnet tools/build_letters.cs

#pragma warning disable IL3050 // AOT warnings not applicable to build-time tools

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var srcDir = Path.Combine(rootDir, "src");
var dataDir = Path.Combine(srcDir, "_data");
var lettersDir = Path.Combine(srcDir, "extensions");
var lettersDataPath = Path.Combine(dataDir, "letters.yml");

Directory.CreateDirectory(lettersDir);
Directory.CreateDirectory(dataDir);

// Load extensions from extensions.yml, extensions_flat.yml, or catalog_flat.yml
var extListFile = Path.Combine(dataDir, "extensions.yml");
var extFlatFile = Path.Combine(dataDir, "extensions_flat.yml");
var catalogFlatFile = Path.Combine(dataDir, "catalog_flat.yml");

// Build ordered list of potential source files
var candidates = new[] { extListFile, extFlatFile, catalogFlatFile }.Where(File.Exists).ToList();

if (candidates.Count == 0)
{
    Console.WriteLine($"No extensions data found at {extListFile}, {extFlatFile}, or {catalogFlatFile} — nothing to do.");
    return 0;
}

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

List<Dictionary<object, object>>? items = null;
string? sourceFile = null;

// Try each candidate file until we find one with actual data
foreach (var candidate in candidates)
{
    try
    {
        var yamlContent = File.ReadAllText(candidate);
        var candidateItems = deserializer.Deserialize<List<Dictionary<object, object>>>(yamlContent);
        if (candidateItems != null && candidateItems.Count > 0)
        {
            items = candidateItems;
            sourceFile = candidate;
            break;
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: Failed to parse {candidate}: {ex.Message}");
        Console.Error.WriteLine($"  Expected format: YAML array of objects with 'ext' field (e.g., - ext: .pdf)");
    }
}

if (items == null || items.Count == 0)
{
    Console.WriteLine("No extensions in data — nothing to generate.");
    Console.WriteLine($"  Checked files: {string.Join(", ", candidates)}");
    Console.WriteLine("  Expected: YAML array with entries containing 'ext' field");
    return 0;
}

// Collect letters from the 'letter' field in catalog data (catalog folder names)
var letters = new HashSet<string>(StringComparer.Ordinal);
foreach (var item in items)
{
    if (item.TryGetValue("letter", out var letterObj) && letterObj != null)
    {
        var letter = letterObj.ToString() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(letter))
            letters.Add(letter);
    }
}

var sortedLetters = letters.OrderBy(l => l, StringComparer.Ordinal).ToList();

// Write _data/letters.yml
var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var lettersDoc = new Dictionary<string, object>
{
    ["letters"] = sortedLetters.ToList()
};
File.WriteAllText(lettersDataPath, serializer.Serialize(lettersDoc));
Console.WriteLine($"Wrote {lettersDataPath} with {sortedLetters.Count} letters.");

// Template file generation removed — use `_includes/letter.md` and `layout: letter` instead.

// Clean letters directory and regenerate all
if (Directory.Exists(lettersDir))
{
    foreach (var file in Directory.GetFiles(lettersDir, "*.md"))
    {
        File.Delete(file);
    }
}
Directory.CreateDirectory(lettersDir);

// Generate pages for each existing letter (including pagination pages)
int created = 0, updated = 0;
// Determine pagination size: prefer command-line argument, then environment variable, fall back to 25.
int perPage = 25;
try
{
    if (args != null && args.Length > 0 && int.TryParse(args[0], out var argVal) && argVal > 0)
    {
        perPage = argVal;
    }
    else
    {
        var envVal = Environment.GetEnvironmentVariable("PAGINATION_SIZE");
        if (!string.IsNullOrEmpty(envVal) && int.TryParse(envVal, out var envParsed) && envParsed > 0)
        {
            perPage = envParsed;
        }
    }
}
catch { }
foreach (var letter in sortedLetters)
{
    var letterForFile = letter.ToLower();
    // Create a per-letter directory and write an index.md so all pages live under the same folder
    var letterDirPath = Path.Combine(lettersDir, letterForFile);
    Directory.CreateDirectory(letterDirPath);
    var indexPath = Path.Combine(letterDirPath, "index.md");
    // Liquid include tag requires escaping braces in C# interpolated string ({{ => {, }} => })
    var frontMatter = $"---\nlayout: letter\ntitle: \"Extensions: {letter}\"\npermalink: /extensions/{letterForFile}/\nletter: {letter}\n---\n";
    if (!File.Exists(indexPath) || File.ReadAllText(indexPath) != frontMatter)
    {
        File.WriteAllText(indexPath, frontMatter);
        if (!File.Exists(indexPath)) created++; else updated++;
    }

    // Count items for this letter to determine pagination
    int totalForLetter = items.Count(it =>
    {
        if (!it.TryGetValue("letter", out var l) || l == null) return false;
        return string.Equals(l.ToString(), letter, StringComparison.OrdinalIgnoreCase);
    });

    int pages = (totalForLetter + perPage - 1) / perPage;
    if (pages <= 1) continue;

    // Generate page2..pageN files with permalinks like /extensions/{letter}/page{n}/
    for (int p = 2; p <= pages; p++)
    {
        var pagePath = Path.Combine(letterDirPath, $"page{p}.md");
        var pageFront = $"---\nlayout: letter\ntitle: \"Extensions: {letter} - page {p}\"\npermalink: /extensions/{letterForFile}/page{p}\nletter: {letter}\n---\n";
        if (!File.Exists(pagePath) || File.ReadAllText(pagePath) != pageFront)
        {
            File.WriteAllText(pagePath, pageFront);
            if (!File.Exists(pagePath)) created++; else updated++;
        }
    }
}

Console.WriteLine($"Generated/updated {sortedLetters.Count} letter pages (with pagination) in {lettersDir}. Created: {created}, Updated: {updated}");
return 0;
