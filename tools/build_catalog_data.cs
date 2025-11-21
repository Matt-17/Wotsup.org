#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_catalog_data.cs
// Flatten catalog/<letter>/<ext>/(index.md|index.yaml|ext.yaml) into src/_data/catalog_flat.yml
// New preferred format: index.md with YAML frontmatter containing:
// ---
// extension: pdf
// meanings:
//   - name: Portable Document Format
//     categories:
//     - graphics
//     description: ...
//   - name: Photo Data File
//     categories:
//     - graphics
//     description: ...
// aliases: [ pdff ]
// ---
// (Markdown body follows)
// Run with: dotnet build_catalog_data.cs

#pragma warning disable IL3050 // AOT warnings not applicable to build-time tools

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

// Determine root directory from current working directory
var rootDir = Directory.GetCurrentDirectory();

var dataDir = Path.Combine(rootDir, "src", "_data");
var outFile = Path.Combine(dataDir, "catalog_flat.yml");
var catalogDir = Path.Combine(rootDir, "catalog");
var categoriesFile = Path.Combine(catalogDir, "categories.yaml");
var siteFilesDir = Path.Combine(rootDir, "src", "files");

var entries = new List<Dictionary<string, object?>>();
int filesCopied = 0;

if (!Directory.Exists(catalogDir))
{
    Console.WriteLine($"No catalog directory found at {catalogDir} — nothing to do.");
    return 0;
}

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

// Load categories for reference
var categories = new Dictionary<string, Dictionary<string, object?>>();
if (File.Exists(categoriesFile))
{
    try
    {
        var catYaml = File.ReadAllText(categoriesFile);
        var catList = deserializer.Deserialize<List<Dictionary<string, object?>>>(catYaml);
        if (catList != null)
        {
            foreach (var cat in catList)
            {
                if (cat.TryGetValue("name", out var name) && name != null)
                {
                    categories[name.ToString()!] = cat;
                }
            }
        }
        Console.WriteLine($"Loaded {categories.Count} categories from {categoriesFile}");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: Failed to load categories: {ex.Message}");
    }
}

// Process each letter directory (use folder name as letter, no alphabetic restriction)
foreach (var letterDir in Directory.GetDirectories(catalogDir).OrderBy(d => d))
{
    var letter = Path.GetFileName(letterDir);

    // Skip invalid folder names
    if (string.IsNullOrEmpty(letter))
        continue;

    // Support layouts:
    // 1. New: catalog/<letter>/<ext>/index.md (frontmatter + body)
    // 2. Transitional: catalog/<letter>/<ext>/index.yaml (YAML list or mapping)
    // 3. Legacy: catalog/<letter>/<ext>.yaml (YAML list or mapping)
    var filesToProcess = new List<(string file, string extName)>();

    // Check for extension subdirectories with index.md / index.yaml
    foreach (var extSubDir in Directory.GetDirectories(letterDir).OrderBy(d => d))
    {
        var extName = Path.GetFileName(extSubDir);
        var indexYaml = Path.Combine(extSubDir, "index.yaml");
        var indexMd = Path.Combine(extSubDir, "index.md");
        if (File.Exists(indexMd))
            filesToProcess.Add((indexMd, extName));
        else if (File.Exists(indexYaml))
            filesToProcess.Add((indexYaml, extName));

        // Copy all non-index files from catalog to src/files
        var targetFilesDir = Path.Combine(siteFilesDir, letter, extName);
        foreach (var catalogFile in Directory.GetFiles(extSubDir))
        {
            var fileName = Path.GetFileName(catalogFile);
            // Skip index files (metadata, not downloadable content)
            if (fileName.Equals("index.md", StringComparison.OrdinalIgnoreCase) ||
                fileName.Equals("index.yaml", StringComparison.OrdinalIgnoreCase))
                continue;

            Directory.CreateDirectory(targetFilesDir);
            var targetPath = Path.Combine(targetFilesDir, fileName);
            try
            {
                File.Copy(catalogFile, targetPath, overwrite: true);
                filesCopied++;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Warning: Failed to copy {catalogFile} to {targetPath}: {ex.Message}");
            }
        }
    }

    // Also check for legacy direct YAML files (catalog/<letter>/<ext>.yaml)
    foreach (var yamlFile in Directory.GetFiles(letterDir, "*.yaml").OrderBy(f => f))
    {
        var extName = Path.GetFileNameWithoutExtension(yamlFile);
        filesToProcess.Add((yamlFile, extName));
    }

    foreach (var (file, extName) in filesToProcess)
    {
        try
        {
            var isMarkdown = file.EndsWith(".md", StringComparison.OrdinalIgnoreCase);
            string? body = null;
            Dictionary<string, object?>? frontmatter = null;
            if (isMarkdown)
            {
                // Extract frontmatter between leading --- lines
                var lines = File.ReadAllLines(file);
                if (lines.Length >= 3 && lines[0].Trim() == "---")
                {
                    int fmEnd = -1;
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (lines[i].Trim() == "---") { fmEnd = i; break; }
                    }
                    if (fmEnd == -1)
                    {
                        Console.Error.WriteLine($"Skipping {file}: frontmatter not closed with ---");
                        continue;
                    }
                    var fmLines = lines.Skip(1).Take(fmEnd - 1).ToArray();
                    var fmText = string.Join("\n", fmLines);
                    try
                    {
                        frontmatter = deserializer.Deserialize<Dictionary<string, object?>>(fmText) ?? new();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Skipping {file}: failed to parse frontmatter: {ex.Message}");
                        continue;
                    }
                    body = string.Join("\n", lines.Skip(fmEnd + 1));
                }
                else
                {
                    Console.Error.WriteLine($"Skipping {file}: missing leading frontmatter delimiter ---");
                    continue;
                }
            }
            else
            {
                // Pure YAML file. Only support the new 'extensions' key.
                var yamlContent = File.ReadAllText(file);
                var parsed = deserializer.Deserialize<object>(yamlContent);
                frontmatter = new Dictionary<string, object?>();
                if (parsed != null)
                {
                    frontmatter["extensions"] = parsed;
                }
                body = null;
            }

            if (frontmatter == null)
            {
                Console.Error.WriteLine($"Skipping {file}: no frontmatter parsed");
                continue;
            }

            // Determine extensions list. Ignore any legacy 'meanings' key silently — we only rely on 'extensions'.
            object? meaningsRaw = null;
            if (!frontmatter.TryGetValue("extensions", out var extRaw))
            {
                // No 'extensions' present — skip this file.
                continue;
            }
            meaningsRaw = extRaw;
            List<Dictionary<object, object>> meaningList = new();
            if (meaningsRaw is IEnumerable<object> seq)
            {
                foreach (var m in seq)
                {
                    if (m is Dictionary<object, object> md) meaningList.Add(md);
                    else Console.Error.WriteLine($"Warning: skipping non-mapping meaning in {file}");
                }
            }
            else if (meaningsRaw is Dictionary<object, object> singleMeaning)
            {
                meaningList.Add(singleMeaning);
            }
            else if (meaningsRaw == null)
            {
                // Fallback: treat entire frontmatter (minus known keys) as one meaning if legacy structure
                var legacy = new Dictionary<object, object>();
                foreach (var kv in frontmatter)
                {
                    if (kv.Key == "extension" || kv.Key == "aliases") continue;
                    legacy[kv.Key] = kv.Value!;
                }
                if (legacy.Count > 0) meaningList.Add(legacy);
            }

            if (meaningList.Count == 0)
            {
                Console.Error.WriteLine($"Skipping {file}: no meanings found");
                continue;
            }

            // Aliases (apply to each meaning entry for context)
            var aliases = new List<string>();
            if (frontmatter.TryGetValue("aliases", out var aliasesObj) && aliasesObj is IEnumerable<object> aliasSeq)
            {
                foreach (var a in aliasSeq) if (a != null) aliases.Add(a.ToString()!);
            }

            int meaningIndex = 0;
            foreach (var meaning in meaningList)
            {
                meaningIndex++;
                var entry = new Dictionary<string, object?>
                {
                    ["ext"] = extName,
                    ["slug"] = extName,
                    ["letter"] = letter,
                    ["source_file"] = Path.GetRelativePath(rootDir, file),
                    ["entry_index"] = meaningIndex
                };

                foreach (var kvp in meaning)
                {
                    var key = kvp.Key?.ToString();
                    if (!string.IsNullOrEmpty(key)) entry[key] = kvp.Value;
                }

                // If 'file:' is present, keep it and also add the full download path
                // The 'file:' field indicates this is a local download, not an external link
                if (entry.TryGetValue("file", out var fileValue) && fileValue != null && !string.IsNullOrWhiteSpace(fileValue.ToString()))
                {
                    var fileName = fileValue.ToString()!.Trim();
                    // Add download_url for the full path, keep 'file' to indicate it's a download
                    entry["download_url"] = $"/files/{letter}/{extName}/{fileName}";
                }

                if (aliases.Count > 0) entry["aliases"] = aliases;

                // Normalize category(s): support single scalar or a sequence. Always provide
                // a `categories` list (for multi-category support) and keep `category` as
                // a backward-compatible first-choice slug.
                var catsList = new List<string>();
                if (entry.TryGetValue("category", out var catValue) && catValue != null)
                {
                    if (catValue is IEnumerable<object> cseq)
                    {
                        foreach (var o in cseq)
                        {
                            if (o == null) continue;
                            var s = o.ToString()!.Trim();
                            if (!string.IsNullOrEmpty(s)) catsList.Add(s);
                        }
                    }
                    else
                    {
                        var s = catValue.ToString()!.Trim();
                        if (!string.IsNullOrEmpty(s)) catsList.Add(s);
                    }
                }

                // If frontmatter used `categories` key directly, include those too
                if (entry.TryGetValue("categories", out var catsObj) && catsObj is IEnumerable<object> catsSeq2)
                {
                    foreach (var o in catsSeq2)
                    {
                        if (o == null) continue;
                        var s = o.ToString()!.Trim();
                        if (!string.IsNullOrEmpty(s) && !catsList.Contains(s)) catsList.Add(s);
                    }
                }

                if (catsList.Count == 0)
                    catsList.Add("misc");

                entry["categories"] = catsList;
                // Keep legacy `category` field for backwards compatibility (first entry)
                entry["category"] = catsList[0];

                // Fill category metadata (short/title) from the first matching category
                var catName = catsList.Count > 0 ? catsList[0] : null;
                if (!string.IsNullOrEmpty(catName) && categories.TryGetValue(catName, out var catInfo))
                {
                    if (catInfo.TryGetValue("short", out var shortDesc)) entry["category_short"] = shortDesc;
                    if (catInfo.TryGetValue("title", out var title)) entry["category_title"] = title;
                }

                if (entry.TryGetValue("alternative", out var altValue) && altValue != null)
                {
                    entry["is_alternative"] = true;
                    entry["alternative_to"] = altValue.ToString();
                }

                entries.Add(entry);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to read {file}: {ex.Message}");
        }
    }
}

// Sort by extension then entry index
entries = entries
    .OrderBy(e => e.TryGetValue("ext", out var ext) && ext != null ? ext.ToString()!.ToLower() : "")
    .ThenBy(e => e.TryGetValue("entry_index", out var idx) && idx != null ? Convert.ToInt32(idx) : 0)
    .ToList();

// Ensure output directory exists
Directory.CreateDirectory(Path.GetDirectoryName(outFile)!);

var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
    .Build();

var yaml = serializer.Serialize(entries);
File.WriteAllText(outFile, yaml);

Console.WriteLine($"Generated {outFile} with {entries.Count} entries. Copied {filesCopied} files to {siteFilesDir}.");
return 0;
