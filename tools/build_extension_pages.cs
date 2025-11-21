#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_extension_pages.cs
// Generate per-extension pages in src/extensions/<letter>/<ext>/index.md from catalog files (index.md preferred)
// Run with: dotnet tools/build_extension_pages.cs
// Path rationale: nesting under the letter avoids collision if an extension name equals a letter
// (e.g. an extension 'p' would collide with letter page 'p.md'). Alternative designs could use
// a prefix (e.g. /extensions/ext/pdf) or a different collection, but letter nesting keeps URLs short.
#pragma warning disable IL3050 // Dynamic code warnings not relevant for build-time scripts

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(rootDir, "catalog");
var outDir = Path.Combine(rootDir, "src", "extensions");
Directory.CreateDirectory(outDir);

// Cleanup legacy flat extension directories (src/extensions/<ext>) from previous runs
foreach (var legacyDir in Directory.GetDirectories(outDir))
{
    var name = Path.GetFileName(legacyDir);
    // Legacy extension dirs had length > 1; keep single-letter dirs (they are letter pages after build_letters.cs)
    if (name.Length > 1 && !Directory.GetDirectories(legacyDir).Any(d => Path.GetFileName(d).Length == 1))
    {
        try { Directory.Delete(legacyDir, true); } catch { /* ignore */ }
    }
}

if (!Directory.Exists(catalogDir))
{
    Console.WriteLine($"No catalog directory at {catalogDir} – nothing to do.");
    return 0;
}

var deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

int created = 0, updated = 0, skipped = 0;

foreach (var letterDir in Directory.GetDirectories(catalogDir).OrderBy(d => d))
{
    var letter = Path.GetFileName(letterDir);
    if (string.IsNullOrWhiteSpace(letter)) continue;
    foreach (var extDir in Directory.GetDirectories(letterDir).OrderBy(d => d))
    {
        var ext = Path.GetFileName(extDir);
        var sourceMd = Path.Combine(extDir, "index.md");
        var sourceYaml = Path.Combine(extDir, "index.yaml");
        string? frontmatterText = null;
        string? bodyText = null;
        if (File.Exists(sourceMd))
        {
            var lines = File.ReadAllLines(sourceMd);
            if (lines.Length >= 3 && lines[0].Trim() == "---")
            {
                int fmEnd = -1;
                for (int i = 1; i < lines.Length; i++) if (lines[i].Trim() == "---") { fmEnd = i; break; }
                if (fmEnd == -1) { Console.Error.WriteLine($"Skipping {sourceMd}: unclosed frontmatter"); skipped++; continue; }
                frontmatterText = string.Join("\n", lines.Skip(1).Take(fmEnd - 1));
                bodyText = string.Join("\n", lines.Skip(fmEnd + 1));
            }
            else
            {
                Console.Error.WriteLine($"Skipping {sourceMd}: missing frontmatter"); skipped++; continue;
            }
        }
        else if (File.Exists(sourceYaml))
        {
            // Promote pure YAML into frontmatter under meanings
            var yamlContent = File.ReadAllText(sourceYaml);
            frontmatterText = $"extension: {ext}\nmeanings: {yamlContent}"; // naive embed; expects list or mapping
            bodyText = "";
        }
        else
        {
            Console.Error.WriteLine($"No index.md or index.yaml for {ext} under {letterDir}"); skipped++; continue;
        }

        // Ensure extension key exists in frontmatter; add if missing
        try
        {
            var fmObj = deserializer.Deserialize<Dictionary<string, object?>>(frontmatterText!) ?? new();
            if (!fmObj.ContainsKey("extension")) fmObj["extension"] = ext;
            if (!fmObj.ContainsKey("letter")) fmObj["letter"] = letter; // convenience
            // Re-serialize sanitized frontmatter
            var serializer = new SerializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
            frontmatterText = serializer.Serialize(fmObj).TrimEnd();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to parse frontmatter for {ext}: {ex.Message}"); skipped++; continue;
        }

        var outLetterDir = Path.Combine(outDir, letter);
        Directory.CreateDirectory(outLetterDir);
        var outExtDir = Path.Combine(outLetterDir, ext);
        Directory.CreateDirectory(outExtDir);
        var outFile = Path.Combine(outExtDir, "index.md");

        // Inject permalink to ensure URL /extensions/<letter>/<ext>/
        var newContent = $"---\nlayout: extension\npermalink: /extensions/{letter}/{ext}/\n{frontmatterText}\n---\n\n{bodyText}";
        if (!File.Exists(outFile))
        {
            File.WriteAllText(outFile, newContent);
            created++;
        }
        else
        {
            var existing = File.ReadAllText(outFile);
            if (existing != newContent)
            {
                File.WriteAllText(outFile, newContent);
                updated++;
            }
            else
            {
                skipped++;
            }
        }
    }
}

Console.WriteLine($"Generated/updated extension pages. Created: {created}, Updated: {updated}, Skipped: {skipped}");
return 0;
