#!/usr/bin/env dotnet
// tools/validate_yaml_schema.cs
// Validate catalog YAML files for required keys and uniqueness.
// Exit with non-zero on failure.

#nullable enable
#r "nuget: YamlDotNet, 16.2.0"

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var root = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(root, "catalog");
var categoriesFile = Path.Combine(catalogDir, "categories.yaml");
var errors = new List<string>();
var deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

if (!File.Exists(categoriesFile))
    errors.Add($"Missing categories.yaml at {categoriesFile}");
else
{
    try
    {
        var yaml = File.ReadAllText(categoriesFile);
        var list = deserializer.Deserialize<List<Dictionary<string, object?>>>(yaml) ?? new();
        var seenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var cat in list)
        {
            string Get(string k) => cat.TryGetValue(k, out var v) && v != null ? v.ToString()!.Trim() : "";
            var name = Get("name");
            var @short = Get("short");
            var title = Get("title");
            if (string.IsNullOrEmpty(name)) errors.Add("Category missing 'name'");
            if (string.IsNullOrEmpty(@short)) errors.Add($"Category '{name}' missing 'short'");
            if (string.IsNullOrEmpty(title)) errors.Add($"Category '{name}' missing 'title'");
            if (!string.IsNullOrEmpty(name) && !seenNames.Add(name)) errors.Add($"Duplicate category name '{name}'");
        }
    }
    catch (Exception ex)
    {
        errors.Add($"Failed to parse categories.yaml: {ex.Message}");
    }
}

// Validate letter directories & extension files
if (Directory.Exists(catalogDir))
{
    foreach (var letterDir in Directory.GetDirectories(catalogDir))
    {
        var letter = Path.GetFileName(letterDir);
        if (letter.Length != 1 || !char.IsLetter(letter[0])) continue;
        // Enforce the new layout strictly: no legacy files directly under the letter dir
        // and each extension must be a subdirectory containing `index.md`.
        var directYamlFiles = Directory.GetFiles(letterDir, "*.yaml").Concat(Directory.GetFiles(letterDir, "*.yml"));
        if (directYamlFiles.Any())
        {
            foreach (var f in directYamlFiles)
                errors.Add($"Legacy YAML file found in {letterDir}: {f}. Migrate to subdirectory with index.md.");
        }

        foreach (var extSubDir in Directory.GetDirectories(letterDir))
        {
            var idxMd = Path.Combine(extSubDir, "index.md");
            if (!File.Exists(idxMd))
            {
                errors.Add($"Missing index.md in extension directory {extSubDir}");
                continue;
            }

            try
            {
                var content = File.ReadAllText(idxMd);
                // Extract YAML frontmatter from markdown file
                var yaml = content;
                if (content.StartsWith("---"))
                {
                    var endIdx = content.IndexOf("---", 3);
                    if (endIdx > 0)
                        yaml = content.Substring(3, endIdx - 3);
                }
                var data = deserializer.Deserialize<object?>(yaml);
                if (data == null) errors.Add($"Empty YAML frontmatter: {idxMd}");
            }
            catch (Exception ex)
            {
                errors.Add($"Failed to parse {idxMd}: {ex.Message}");
            }
        }
    }
}

if (errors.Count > 0)
{
    Console.Error.WriteLine("YAML schema validation failed:");
    foreach (var e in errors.Distinct()) Console.Error.WriteLine(" - " + e);
    return 1;
}

Console.WriteLine("YAML schema validation passed.");
return 0;