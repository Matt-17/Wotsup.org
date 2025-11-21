#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_site_stats.cs
// Compute site stats from generated data and repository contents, writing to src/_data/site_stats.yml
// Run with: dotnet tools/build_site_stats.cs

#pragma warning disable IL3050 // AOT warnings not applicable to build-time tools

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var dataDir = Path.Combine(rootDir, "src", "_data");
var catalogFlatFile = Path.Combine(dataDir, "catalog_flat.yml");
var categoriesFile = Path.Combine(dataDir, "categories.yml");
var downloadsDir = Path.Combine(rootDir, "wotsit.org", "files");
var outFile = Path.Combine(dataDir, "site_stats.yml");

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
    .Build();

int entriesTotal = 0; // total spec entries (may include multiple specs per format)
int fileFormatsTotal = 0; // distinct file format slugs
int categoriesTotal = 0;
int lettersTotal = 0;

// 1) Formats/specs from catalog_flat.yml (exclude entries marked is_alternative)
if (File.Exists(catalogFlatFile))
{
    try
    {
        var yaml = File.ReadAllText(catalogFlatFile);
        var items = deserializer.Deserialize<List<Dictionary<string, object?>>>(yaml) ?? new();
        var filtered = items.Where(x => !(x.TryGetValue("is_alternative", out var alt) && alt is bool b && b)).ToList();
        entriesTotal = filtered.Count;
        var slugs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var it in filtered)
        {
            if (it.TryGetValue("slug", out var sv) && sv != null)
            {
                var s = sv.ToString();
                if (!string.IsNullOrWhiteSpace(s)) slugs.Add(s);
            }
        }
        fileFormatsTotal = slugs.Count;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: failed to read {catalogFlatFile}: {ex.Message}");
    }
}
else
{
    Console.Error.WriteLine($"Warning: {catalogFlatFile} not found; formats_total will be 0.");
}

// 2) Categories count from categories.yml
if (File.Exists(categoriesFile))
{
    try
    {
        var yaml = File.ReadAllText(categoriesFile);
        var root = deserializer.Deserialize<Dictionary<string, object?>>(yaml) ?? new();
        if (root.TryGetValue("categories", out var clistObj) && clistObj is IEnumerable<object> clist)
        {
            categoriesTotal = clist.Count();
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: failed to read {categoriesFile}: {ex.Message}");
    }
}
else
{
    Console.Error.WriteLine($"Warning: {categoriesFile} not found; categories_total will be 0.");
}

// 3) Letters count from src/_data/letters.yml (if present)
var lettersFile = Path.Combine(dataDir, "letters.yml");
if (File.Exists(lettersFile))
{
    try
    {
        var yaml = File.ReadAllText(lettersFile);
        // try deserialize as a list first
        try
        {
            var list = deserializer.Deserialize<List<Dictionary<string, object?>>>(yaml);
            if (list != null) lettersTotal = list.Count;
        }
        catch
        {
            // fallback: treat as root object with a 'letters' key
            var root = deserializer.Deserialize<Dictionary<string, object?>>(yaml) ?? new();
            if (root.TryGetValue("letters", out var lobj) && lobj is IEnumerable<object> seq) lettersTotal = seq.Count();
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: failed to read {lettersFile}: {ex.Message}");
    }
}
else
{
    Console.Error.WriteLine($"Warning: {lettersFile} not found; letters_total will be 0.");
}

// Prepare output
var stats = new Dictionary<string, object?>
{
    ["entries_total"] = entriesTotal,                 // total spec entries (may have multiple per format)
    ["file_formats_total"] = fileFormatsTotal,        // distinct file formats (slugs)
    ["categories_total"] = categoriesTotal,
    ["letters_total"] = lettersTotal,
    ["generated_at_utc"] = DateTime.UtcNow.ToString("o")
};

Directory.CreateDirectory(dataDir);
var outYaml = serializer.Serialize(stats);
File.WriteAllText(outFile, outYaml);

Console.WriteLine($"Generated {outFile} with entries_total={entriesTotal}, file_formats_total={fileFormatsTotal}, categories_total={categoriesTotal}, letters_total={lettersTotal}.");
return 0;
