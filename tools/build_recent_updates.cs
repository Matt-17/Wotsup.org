#!/usr/bin/env dotnet
#:package YamlDotNet@16.2.0
// tools/build_recent_updates.cs
// Scan catalog/<letter>/<ext> folders by git commit history and emit recent update dates to src/_data/recent_updates.yml
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
// Homepage should show the latest distinct dates that have visible catalog updates.
var maxDays = 5;
var maxEntriesPerDate = 10;
var maxCommitsToScan = 1000;

var serializer = new SerializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
    .Build();

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var updates = new List<Dictionary<string, object?>>();

// Load catalog_flat name map (slug -> name) if available to show human-friendly names
var catalogFlatFile = Path.Combine(rootDir, "src", "_data", "catalog_flat.yml");
var nameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
if (File.Exists(catalogFlatFile))
{
    try
    {
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

if (!Directory.Exists(catalogDir))
{
    Console.WriteLine($"No catalog at {catalogDir}. Skipping recent updates.");
}
else if (IsShallowRepository(rootDir))
{
    Console.Error.WriteLine("Error: recent updates require full git history. Re-run after fetching with fetch-depth: 0 or unshallowing the clone.");
    return 1;
}
else
{
    var recentChanges = GetRecentCatalogChanges(rootDir, maxDays, maxCommitsToScan);
    var visibleChanges = recentChanges
        .GroupBy(s => s.lastChange.ToString("yyyy-MM-dd"))
        .OrderByDescending(g => g.Max(s => s.lastChange))
        .SelectMany(g =>
        {
            var ordered = g
                .OrderByDescending(s => s.lastChange)
                .ThenBy(s => s.letter, StringComparer.OrdinalIgnoreCase)
                .ThenBy(s => s.ext, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return ordered.Take(maxEntriesPerDate).Select(s => (change: s, dateUpdateCount: ordered.Count));
        });

    foreach (var item in visibleChanges)
    {
        var s = item.change;
        var path = Path.Combine(catalogDir, s.letter, s.ext);
        if (!Directory.Exists(path))
            continue;

        var displayName = GetCatalogDisplayName(path) ?? (nameMap.TryGetValue(s.ext, out var nm) ? nm : s.ext);

        updates.Add(new Dictionary<string, object?>
        {
            ["letter"] = s.letter,
            ["slug"] = s.ext,
            ["path"] = Path.GetRelativePath(rootDir, path).Replace('\\', '/'),
            ["name"] = displayName,
            ["last_change_utc"] = s.lastChange.ToUniversalTime().ToString("o"),
            ["last_change_date"] = s.lastChange.ToString("yyyy-MM-dd"),
            ["change_type"] = s.changeType,
            ["date_update_count"] = item.dateUpdateCount,
            ["url"] = $"/extensions/{s.letter}/{s.ext}/"
        });
    }
}

List<(string letter, string ext, DateTimeOffset lastChange, string changeType)> GetRecentCatalogChanges(
    string repoRoot,
    int daysToInclude,
    int commitScanLimit)
{
    var changes = new Dictionary<string, (string letter, string ext, DateTimeOffset lastChange, string changeType)>(
        StringComparer.OrdinalIgnoreCase);
    var includedDates = new HashSet<DateTime>();
    var scannedCatalogCommits = 0;

    try
    {
        var psi = new ProcessStartInfo(
            "git",
            $"log --all --author-date-order --name-status --format=@@commit@@%x09%aI --max-count={commitScanLimit} -- catalog")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = repoRoot
        };

        using var p = Process.Start(psi);
        if (p == null)
            return changes.Values.ToList();

        var output = p.StandardOutput.ReadToEnd();
        var error = p.StandardError.ReadToEnd();
        p.WaitForExit();

        if (p.ExitCode != 0)
        {
            Console.Error.WriteLine($"Warning: git log failed while building recent updates: {error.Trim()}");
            return changes.Values.ToList();
        }

        DateTimeOffset currentCommit = default;
        var currentCommitChanges = new Dictionary<string, (string letter, string ext, List<string> statuses)>(
            StringComparer.OrdinalIgnoreCase);
        var stop = false;

        void FlushCommit()
        {
            if (currentCommit == default || currentCommitChanges.Count == 0 || stop)
                return;

            var newItems = currentCommitChanges.Values
                .Where(item => !changes.ContainsKey($"{item.letter}/{item.ext}"))
                .ToList();

            if (newItems.Count == 0)
                return;

            var commitDate = currentCommit.Date;
            if (!includedDates.Contains(commitDate) && includedDates.Count >= daysToInclude)
            {
                stop = true;
                return;
            }

            includedDates.Add(commitDate);
            scannedCatalogCommits++;

            foreach (var item in newItems)
            {
                var key = $"{item.letter}/{item.ext}";
                var changeType = item.statuses.Count > 0 && item.statuses.All(s => s.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                    ? "added"
                    : "updated";

                changes[key] = (item.letter, item.ext, currentCommit, changeType);
            }
        }

        foreach (var rawLine in output.Split('\n'))
        {
            var line = rawLine.TrimEnd('\r');
            if (line.Length == 0)
                continue;

            if (line.StartsWith("@@commit@@", StringComparison.Ordinal))
            {
                FlushCommit();
                if (stop)
                    break;

                currentCommitChanges.Clear();
                currentCommit = default;

                var parts = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2 &&
                    DateTimeOffset.TryParse(parts[1], null, DateTimeStyles.RoundtripKind, out var parsedDate))
                {
                    currentCommit = parsedDate;
                }
                continue;
            }

            if (TryParseCatalogStatusLine(line, out var status, out var letter, out var ext))
            {
                var key = $"{letter}/{ext}";
                if (!currentCommitChanges.TryGetValue(key, out var existing))
                {
                    existing = (letter, ext, new List<string>());
                    currentCommitChanges[key] = existing;
                }
                existing.statuses.Add(status);
            }
        }

        FlushCommit();

        if (scannedCatalogCommits == 0)
            Console.Error.WriteLine("Warning: no catalog changes found in git history; recent updates will be empty.");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Warning: failed to build recent updates from git history: {ex.Message}");
    }

    return changes.Values.ToList();
}

string? GetCatalogDisplayName(string entryDir)
{
    var indexMd = Path.Combine(entryDir, "index.md");
    if (!File.Exists(indexMd))
        return null;

    try
    {
        var lines = File.ReadAllLines(indexMd);
        if (lines.Length < 3 || lines[0].Trim() != "---")
            return null;

        var fmEnd = -1;
        for (var i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "---")
            {
                fmEnd = i;
                break;
            }
        }

        if (fmEnd == -1)
            return null;

        var frontMatter = string.Join("\n", lines.Skip(1).Take(fmEnd - 1));
        var metadata = deserializer.Deserialize<Dictionary<string, object?>>(frontMatter);
        if (metadata == null)
            return null;

        if (metadata.TryGetValue("extensions", out var extensionsValue) &&
            TryGetFirstExtensionName(extensionsValue, out var extensionName))
        {
            return extensionName;
        }

        foreach (var key in new[] { "title" })
        {
            if (metadata.TryGetValue(key, out var value) && value != null)
            {
                var text = value.ToString()?.Trim();
                if (!string.IsNullOrWhiteSpace(text))
                    return text;
            }
        }
    }
    catch
    {
        return null;
    }

    return null;
}

bool TryGetFirstExtensionName(object? value, out string name)
{
    name = "";

    if (value is IEnumerable<object> sequence)
    {
        foreach (var item in sequence)
            return TryGetMappingText(item, "name", out name) || TryGetMappingText(item, "title", out name);
    }

    return TryGetMappingText(value, "name", out name) || TryGetMappingText(value, "title", out name);
}

bool TryGetMappingText(object? value, string key, out string text)
{
    text = "";

    if (value is IDictionary<object, object> objectDict)
    {
        foreach (var item in objectDict)
        {
            if (string.Equals(item.Key?.ToString(), key, StringComparison.OrdinalIgnoreCase) && item.Value != null)
            {
                text = item.Value.ToString()?.Trim() ?? "";
                return !string.IsNullOrWhiteSpace(text);
            }
        }
    }

    if (value is IDictionary<string, object?> stringDict &&
        stringDict.TryGetValue(key, out var stringValue) &&
        stringValue != null)
    {
        text = stringValue.ToString()?.Trim() ?? "";
        return !string.IsNullOrWhiteSpace(text);
    }

    return false;
}

bool IsShallowRepository(string repoRoot)
{
    try
    {
        var psi = new ProcessStartInfo("git", "rev-parse --is-shallow-repository")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = repoRoot
        };

        using var p = Process.Start(psi);
        if (p == null)
            return false;

        var output = p.StandardOutput.ReadToEnd();
        p.StandardError.ReadToEnd();
        p.WaitForExit();

        return p.ExitCode == 0 && output.Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
    }
    catch
    {
        return false;
    }
}

bool TryParseCatalogStatusLine(string line, out string status, out string letter, out string ext)
{
    status = "";
    letter = "";
    ext = "";

    var parts = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < 2)
        return false;

    status = parts[0].Trim();
    var path = parts[^1].Trim().Replace('\\', '/');
    if (!path.StartsWith("catalog/", StringComparison.OrdinalIgnoreCase))
        return false;

    var pathParts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
    if (pathParts.Length < 3)
        return false;

    letter = pathParts[1];
    ext = pathParts[2];
    return !string.IsNullOrWhiteSpace(letter) && !string.IsNullOrWhiteSpace(ext);
}

Directory.CreateDirectory(Path.GetDirectoryName(outFile)!);
var outYaml = serializer.Serialize(updates);
File.WriteAllText(outFile, outYaml);
Console.WriteLine($"Generated {outFile} with {updates.Count} recent updates.");
return 0;
