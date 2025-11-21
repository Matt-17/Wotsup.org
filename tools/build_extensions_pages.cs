#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_extensions_pages.cs
// Generate paginated files for the full extensions list (src/extensions/pageN.md)
// Run with: dotnet tools/build_extensions_pages.cs

#pragma warning disable IL3050

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var dataFile = Path.Combine(rootDir, "src", "_data", "catalog_flat.yml");
var outDir = Path.Combine(rootDir, "src", "extensions");

if (!File.Exists(dataFile))
{
    Console.WriteLine($"Data file not found at {dataFile} — nothing to do.");
    return 0;
}

var deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

try
{
    var yaml = File.ReadAllText(dataFile);
    var items = deserializer.Deserialize<List<Dictionary<string, object?>>>(yaml) ?? new List<Dictionary<string, object?>>();
    int total = items.Count;
    const int perPage = 25;
    int pages = (total + perPage - 1) / perPage;

    if (pages <= 1)
    {
        Console.WriteLine("No pagination needed for extensions list.");
        return 0;
    }

    Directory.CreateDirectory(outDir);
    int created = 0;

    // Create page2..pageN files under src/extensions/page{n}.md with appropriate permalinks
    for (int p = 2; p <= pages; p++)
    {
        var pagePath = Path.Combine(outDir, $"page{p}.md");
        var pageFront = $"---\nlayout: default\ntitle: \"All File Extensions - page {p}\"\npermalink: /extensions/page{p}/\nnavigation: Extensions\n---\n";
        if (!File.Exists(pagePath) || File.ReadAllText(pagePath) != pageFront)
        {
            File.WriteAllText(pagePath, pageFront);
            created++;
        }
    }

    Console.WriteLine($"Generated/updated {created} extensions pagination pages in {outDir} (pages: {pages}).");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed to generate extensions pagination pages: {ex.Message}");
    return 1;
}
