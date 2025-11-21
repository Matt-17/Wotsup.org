#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_recent_updates.cs
// Scan catalog/<letter>/<ext> folders by git commit history and emit top N recent updates to src/_data/recent_updates.yml
// Run with: dotnet tools/build_recent_updates.cs

#pragma warning disable IL3050

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var rootDir = Directory.GetCurrentDirectory();
var catalogDir = Path.Combine(rootDir, "catalog");
var outFile = Path.Combine(rootDir, "src", "_data", "recent_updates.yml");
// number of recent days to include (all items within each day)
var maxDays = 3;

var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
    .Build();

var updates = new List<Dictionary<string, object?>>();

// Load catalog_flat name map (slug -> name) if available to show human-friendly names
var catalogFlatFile = Path.Combine(rootDir, "src", "_data", "catalog_flat.yml");
var nameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
if (File.Exists(catalogFlatFile))
{
    try
    {
        var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
            .WithNamingConvention(YamlDotNet.Serialization.NamingConventions.UnderscoredNamingConvention.Instance)
            .Build();
        var yaml = File.ReadAllText(catalogFlatFile);
        var items = deserializer.Deserialize<List<Dictionary<string, object?>>>(yaml) ?? new List<Dictionary<string, object?>>();
        foreach (var it in items)
        {
            if (it.TryGetValue("slug", out var sv) && sv != null && it.TryGetValue("name", out var nv) && nv != null)
            {
                var slug = sv.ToString()!;
                var name = nv.ToString()!;
                if (!nameMap.ContainsKey(slug)) nameMap[slug] = name;
            }
        }
    }
    catch
    {
        // ignore parse errors, we'll fallback to slug
    }
}

// Helper: Get all commit dates for a path using git log
List<DateTime> GetGitCommitDates(string repoRoot, string relPath)
{
    var dates = new List<DateTime>();
    try
    {
        var psi = new ProcessStartInfo("git", $"log --format=%aI --all -- \"{relPath}\"")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = repoRoot
        };
        using var p = Process.Start(psi);
        if (p == null) return dates;

        var output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        if (p.ExitCode == 0 && !string.IsNullOrWhiteSpace(output))
        {
            foreach (var line in output.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                if (DateTime.TryParse(line.Trim(), null, DateTimeStyles.RoundtripKind, out var dt))
                {
                    dates.Add(dt.ToUniversalTime());
                }
            }
        }
    }
    catch
    {
        // git not available or error
    }
    return dates;
}

if (!Directory.Exists(catalogDir))
{
    Console.WriteLine($"No catalog at {catalogDir}. Skipping recent updates.");
}
else
{
    // Get all extension directories that were changed in the last N commits
    var changedPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    try
    {
        var psi = new ProcessStartInfo("git", $"log --all --name-only --format= -3")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = rootDir
        };
        using var p = Process.Start(psi);
        if (p != null)
        {
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            foreach (var line in output.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("catalog/", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract letter/ext from catalog/letter/ext/file
                    var parts = trimmed.Split('/');
                    if (parts.Length >= 3)
                    {
                        var letterExt = $"{parts[1]}/{parts[2]}";
                        changedPaths.Add(letterExt);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: failed to get changed paths from git: {ex.Message}");
    }

    // Only process extensions that were actually changed
    var extDirs = Directory.GetDirectories(catalogDir)
        .SelectMany(letterDir => Directory.GetDirectories(letterDir)
            .Select(extDir => new { letter = Path.GetFileName(letterDir), ext = Path.GetFileName(extDir), path = extDir }))
        .Where(d => changedPaths.Contains($"{d.letter}/{d.ext}"))
        .ToList();

    var scored = new List<(string letter, string ext, string path, DateTime lastChangeUtc, string changeType)>();
    foreach (var d in extDirs)
    {
        try
        {
            var relPath = Path.GetRelativePath(rootDir, d.path).Replace('\\', '/');
            DateTime lastChange;
            string changeType = "updated";

            // Try git first
            var commitDates = GetGitCommitDates(rootDir, relPath);
            if (commitDates.Count > 0)
            {
                var sorted = commitDates.OrderBy(dt => dt).ToList();
                lastChange = sorted.Last();
                changeType = commitDates.Count == 1 ? "added" : "updated";
            }
            else
            {
                // Fallback to filesystem
                lastChange = GetFilesystemTime(d.path);
                changeType = "added";
            }

            scored.Add((d.letter!, d.ext!, d.path!, lastChange.ToUniversalTime(), changeType));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Warning: failed to get last change time for {d.path}: {ex.Message}");
        }
    }

    // Group by UTC date (year-month-day) and include all items in the most recent N days
    var grouped = scored
        .GroupBy(s => s.lastChangeUtc.Date)
        .OrderByDescending(g => g.Key)
        .Take(maxDays)
        .SelectMany(g => g.OrderByDescending(s => s.lastChangeUtc))
        .ToList();

    foreach (var s in grouped)
    {
        updates.Add(new Dictionary<string, object?>
        {
            ["letter"] = s.letter,
            ["slug"] = s.ext,
            ["path"] = Path.GetRelativePath(rootDir, s.path),
            ["name"] = nameMap.TryGetValue(s.ext, out var nm) ? nm : s.ext,
            ["last_change_utc"] = s.lastChangeUtc.ToString("o"),
            ["last_change_date"] = s.lastChangeUtc.ToString("yyyy-MM-dd"),
            ["change_type"] = s.changeType,
            ["url"] = $"/extensions/{s.letter}/{s.ext}/"
        });
    }
}

DateTime GetFilesystemTime(string dirPath)
{
    var info = new DirectoryInfo(dirPath);
    var lastChange = info.LastWriteTimeUtc;
    var idxMd = Path.Combine(dirPath, "index.md");
    var idxYaml = Path.Combine(dirPath, "index.yaml");
    var files = new[] { idxMd, idxYaml }.Where(File.Exists).ToList();
    if (files.Count > 0)
    {
        var latestFileTime = files.Select(f => new FileInfo(f).LastWriteTimeUtc).DefaultIfEmpty(lastChange).Max();
        lastChange = latestFileTime > lastChange ? latestFileTime : lastChange;
    }
    return lastChange;
}

Directory.CreateDirectory(Path.GetDirectoryName(outFile)!);
var outYaml = serializer.Serialize(updates);
File.WriteAllText(outFile, outYaml);
Console.WriteLine($"Generated {outFile} with {updates.Count} recent updates.");
return 0;
