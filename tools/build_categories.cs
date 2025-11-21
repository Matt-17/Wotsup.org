#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_categories.cs
// Generate src/_data/categories.yml from catalog/categories.yaml
// Run with: dotnet tools/build_categories.cs

#pragma warning disable IL3050 // AOT warnings not applicable to build-time tools

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(rootDir, "catalog");
var categoriesSourceFile = Path.Combine(catalogDir, "categories.yaml");
var dataDir = Path.Combine(rootDir, "src", "_data");
var categoriesOutFile = Path.Combine(dataDir, "categories.yml");
// flattened extensions data file (may be named catalog_flat.yml)
var extensionsFlatFile = Path.Combine(dataDir, "catalog_flat.yml");

if (!File.Exists(categoriesSourceFile))
{
    Console.Error.WriteLine($"Source file not found: {categoriesSourceFile}");
    return 1;
}

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
    .Build();

try
{
    var catYaml = File.ReadAllText(categoriesSourceFile);
    var catList = deserializer.Deserialize<List<Dictionary<string, object?>>>(catYaml);

    if (catList == null || catList.Count == 0)
    {
        Console.WriteLine("No categories found in source file.");
        return 0;
    }

    // Transform catalog format to site data format
    var transformed = new List<Dictionary<string, object?>>();
    int id = 0;

    // Build a mapping from slug (name) -> source title to avoid any ambiguity from deserialization
    var slugToTitle = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    foreach (var cat in catList)
    {
        if (cat.TryGetValue("name", out var nameVal) && nameVal != null)
        {
            var slugKey = nameVal.ToString()!.ToLower();
            if (cat.TryGetValue("title", out var tval) && tval != null)
            {
                slugToTitle[slugKey] = tval.ToString()!;
            }
        }
    }

    foreach (var cat in catList.OrderBy(c => c.TryGetValue("short", out var s) ? s?.ToString() : ""))
    {
        var slug = cat.TryGetValue("name", out var nameVal) ? nameVal?.ToString()?.ToLower() : "unknown";
        var shortVal = cat.TryGetValue("short", out var sVal) ? sVal : "Unknown";
        var descVal = cat.TryGetValue("description", out var dVal) ? dVal : "";

        var entry = new Dictionary<string, object?>
        {
            ["id"] = id++,
            ["name"] = shortVal,
            ["title"] = (slug != null && slugToTitle.TryGetValue(slug, out var srcTitle)) ? srcTitle : (cat.TryGetValue("title", out var titleVal) ? titleVal : shortVal),
            ["slug"] = slug,
            ["description"] = descVal,
            ["icon"] = "folder"
        };

        transformed.Add(entry);
    }

    // If catalog_flat.yml exists, determine which categories have no entries
    var categoriesWithEntries = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var flatFile = extensionsFlatFile; // actually catalog_flat.yml here
    if (File.Exists(flatFile))
    {
        try
        {
            var flatYaml = File.ReadAllText(flatFile);
            var items = deserializer.Deserialize<List<Dictionary<string, object?>>>(flatYaml) ?? new List<Dictionary<string, object?>>();
            foreach (var it in items)
            {
                if (it == null) continue;
                if (it.TryGetValue("categories", out var catsObj) && catsObj is IEnumerable<object> catsSeq)
                {
                    foreach (var c in catsSeq)
                    {
                        if (c == null) continue;
                        var slugVal = c.ToString() ?? "";
                        if (!string.IsNullOrWhiteSpace(slugVal)) categoriesWithEntries.Add(slugVal.ToLower());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: failed to read {flatFile} for category filtering: {ex.Message}");
        }
    }
    // Emit warnings for categories that exist in the master categories file but have no entries
    if (categoriesWithEntries.Count > 0)
    {
        var missing = new List<string>();
        foreach (var cat in catList)
        {
            var slugVal = cat.TryGetValue("name", out var nameVal) && nameVal != null ? nameVal.ToString()!.ToLower() : null;
            if (string.IsNullOrEmpty(slugVal)) continue;
            if (!categoriesWithEntries.Contains(slugVal))
            {
                var shortName = cat.TryGetValue("short", out var sname) && sname != null ? sname.ToString()! : slugVal;
                Console.WriteLine($"Warning: no extensions found for category '{slugVal}' ('{shortName}') — it will be excluded from generated data.");
                missing.Add(slugVal);
            }
        }

        transformed = transformed
            .Where(c => c.TryGetValue("slug", out var s) && s != null && categoriesWithEntries.Contains(s.ToString()!.ToLower()))
            .ToList();
    }

    // Wrap in categories key
    var output = new Dictionary<string, object>
    {
        ["categories"] = transformed
    };

    Directory.CreateDirectory(dataDir);
    var yaml = serializer.Serialize(output);
    File.WriteAllText(categoriesOutFile, yaml);

    Console.WriteLine($"Generated {categoriesOutFile} with {transformed.Count} categories from {categoriesSourceFile}.");

    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed to process categories: {ex.Message}");
    return 1;
}
