#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_category_pages.cs
// Generate small category page stubs in src/categories/ from src/_data/categories.yml
// Run with: dotnet tools/build_category_pages.cs

#pragma warning disable IL3050 // AOT warnings not applicable to build-time tools

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var dataFile = Path.Combine(rootDir, "src", "_data", "categories.yml");
var outDir = Path.Combine(rootDir, "src", "categories");

var catalogFlatFile = Path.Combine(rootDir, "src", "_data", "catalog_flat.yml");
var extensionsFlatFile = Path.Combine(rootDir, "src", "_data", "extensions_flat.yml");

if (!File.Exists(dataFile))
{
    Console.WriteLine($"Categories data not found at {dataFile} — nothing to do.");
    return 0;
}

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

try
{
    var yaml = File.ReadAllText(dataFile);
    var doc = deserializer.Deserialize<Dictionary<string, List<Dictionary<string, object?>>>>(yaml);
    if (doc == null || !doc.TryGetValue("categories", out var cats) || cats == null || cats.Count == 0)
    {
        Console.WriteLine("No categories found in data — nothing to generate.");
        return 0;
    }

    Directory.CreateDirectory(outDir);
    int created = 0;

    // Collect which categories actually have entries from catalog_flat.yml or extensions_flat.yml
    var categoriesWithEntries = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    if (File.Exists(catalogFlatFile) || File.Exists(extensionsFlatFile))
    {
        try
        {
            var source = File.Exists(catalogFlatFile) ? catalogFlatFile : extensionsFlatFile;
            var flatYaml = File.ReadAllText(source);
            var items = deserializer.Deserialize<List<Dictionary<string, object?>>>(flatYaml);
            if (items != null)
            {
                foreach (var it in items)
                {
                    if (it == null) continue;
                    // Support new `categories` list or legacy `category` scalar
                    if (it.TryGetValue("categories", out var catsObj) && catsObj is IEnumerable<object> catsSeq)
                    {
                        foreach (var c in catsSeq)
                        {
                            if (c == null) continue;
                            var slugVal = c.ToString() ?? "";
                            if (!string.IsNullOrWhiteSpace(slugVal)) categoriesWithEntries.Add(slugVal.ToLower());
                        }
                    }
                    else if (it.TryGetValue("category", out var cval) && cval != null)
                    {
                        var slugVal = cval.ToString() ?? "";
                        if (!string.IsNullOrWhiteSpace(slugVal)) categoriesWithEntries.Add(slugVal.ToLower());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: failed to read flattened data files: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine($"Warning: neither {catalogFlatFile} nor {extensionsFlatFile} exist — will generate pages for all categories.");
    }

    // If we have flattened items we can compute per-category counts and create paginated files
    List<Dictionary<string, object?>>? itemsList = null;
    if (File.Exists(catalogFlatFile) || File.Exists(extensionsFlatFile))
    {
        try
        {
            var source = File.Exists(catalogFlatFile) ? catalogFlatFile : extensionsFlatFile;
            var flatYaml = File.ReadAllText(source);
            itemsList = deserializer.Deserialize<List<Dictionary<string, object?>>>(flatYaml);
        }
        catch { /* ignore, categoriesWithEntries already computed */ }
    }

    foreach (var cat in cats)
    {
        var slug = cat.TryGetValue("slug", out var s) && s != null ? s.ToString()! : null;
        var shortName = cat.TryGetValue("name", out var sn) && sn != null ? sn.ToString()! : (slug ?? "Category");
        var pageTitle = cat.TryGetValue("title", out var pt) && pt != null ? pt.ToString()! : shortName;
        var description = cat.TryGetValue("description", out var d) && d != null ? d.ToString()! : string.Empty;
        if (string.IsNullOrEmpty(slug)) continue;

        if (categoriesWithEntries.Count > 0 && !categoriesWithEntries.Contains(slug.ToLower()))
        {
            Console.WriteLine($"Warning: no extensions found for category '{slug}' — skipping page generation.");
            continue;
        }

        var catDir = Path.Combine(outDir, slug);
        Directory.CreateDirectory(catDir);
        var indexPath = Path.Combine(catDir, "index.md");
        var safePageTitle = pageTitle.Replace("\"", "'");
        var safeShortName = shortName.Replace("\"", "'");
        var safeDescription = description?.Replace("\"", "'") ?? string.Empty;
        var frontMatter = $"---\nlayout: category\ntitle: \"{safePageTitle}\"\npermalink: /categories/{slug}/\ncategory_slug: {slug}\ncategory_name: \"{safeShortName}\"\n" + (string.IsNullOrWhiteSpace(safeDescription) ? string.Empty : $"description: \"{safeDescription}\"\n")
            + "---\n";

        if (!File.Exists(indexPath) || File.ReadAllText(indexPath) != frontMatter)
        {
            File.WriteAllText(indexPath, frontMatter);
            created++;
        }

        int totalForCategory = 0;
        if (itemsList != null)
        {
            foreach (var it in itemsList)
            {
                if (it == null) continue;
                bool matched = false;
                if (it.TryGetValue("categories", out var catsObj) && catsObj is IEnumerable<object> catsSeq)
                {
                    foreach (var c in catsSeq)
                    {
                        if (c == null) continue;
                        var slugVal = c.ToString() ?? "";
                        if (!string.IsNullOrWhiteSpace(slugVal) && string.Equals(slugVal, slug, StringComparison.OrdinalIgnoreCase)) { matched = true; break; }
                    }
                }
                else if (it.TryGetValue("category", out var cval) && cval != null)
                {
                    var slugVal = cval.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(slugVal) && string.Equals(slugVal, slug, StringComparison.OrdinalIgnoreCase)) matched = true;
                }

                if (matched) totalForCategory++;
            }
        }

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
        catch { /* fallback to default */ }
        int pages = (totalForCategory + perPage - 1) / perPage;
        if (pages <= 1) continue;

        for (int p = 2; p <= pages; p++)
        {
            var pagePath = Path.Combine(catDir, $"page{p}.md");
            var pageFront = $"---\nlayout: category\ntitle: \"{safePageTitle} - page {p}\"\npermalink: /categories/{slug}/page{p}\ncategory_slug: {slug}\ncategory_name: \"{safeShortName}\"\n---\n";
            if (!File.Exists(pagePath) || File.ReadAllText(pagePath) != pageFront)
            {
                File.WriteAllText(pagePath, pageFront);
                created++;
            }
        }
    }

    Console.WriteLine($"Generated/updated {created} category pages in {outDir}.");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Failed to generate category pages: {ex.Message}");
    return 1;
}
