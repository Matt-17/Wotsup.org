#!/usr/bin/env pwsh
# tools/check_generated_integrity.ps1
# Ensure no generated data files (except navigation.yml) are tracked with diffs after regeneration.

Write-Host "Checking generated data integrity..." -ForegroundColor Cyan

$tracked = git ls-files src/_data/*.yml | Where-Object { $_ -notlike '*navigation.yml' }
if ($tracked.Count -gt 0) {
  Write-Host "Unexpected tracked generated files:" -ForegroundColor Red
  $tracked | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
  exit 1
}

# Run generators again for idempotence (use same order as tools/build.ps1)
dotnet tools/build_catalog_data.cs | Out-Null
dotnet tools/build_categories.cs | Out-Null
dotnet tools/build_category_pages.cs | Out-Null
if (Test-Path src/_data/extensions) { dotnet tools/build_extensions_data.cs | Out-Null }
dotnet tools/build_letters.cs | Out-Null

# Check for changes after second run
$pathsToCheck = @()
if (Test-Path "src/_data/") { $pathsToCheck += "src/_data/" }
if (Test-Path "src/letters/") { $pathsToCheck += "src/letters/" }
if (Test-Path "src/extensions/") { $pathsToCheck += "src/extensions/" }
if (Test-Path "src/categories/") { $pathsToCheck += "src/categories/" }

if ($pathsToCheck.Count -eq 0) {
  Write-Host "No generated paths found to check" -ForegroundColor Yellow
  exit 0
}

$diff = git diff --name-only $pathsToCheck
if ($diff) {
  Write-Host "Generator output not idempotent; changed files:" -ForegroundColor Red
  $diff | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
  exit 1
}

Write-Host "Generated data integrity OK" -ForegroundColor Green