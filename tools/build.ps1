#!/usr/bin/env pwsh
# tools/build.ps1
# Run all data generators in correct order

param(
    [switch]$IncludeUpdates
)

# Accept legacy `--includeUpdates` style (double-dash) when invoked from some shells
if ($args -contains '--includeUpdates') { $IncludeUpdates = $true }

$ErrorActionPreference = "Stop"
$rootDir = Split-Path -Parent $PSScriptRoot

Write-Host "=== Building Wotsup Data ===" -ForegroundColor Cyan
Write-Host ""

# Ensure tools run from the repository root so relative paths resolve
Push-Location $rootDir
try {  
    $numberOfSteps = 8
    if (-not $IncludeUpdates) { $numberOfSteps = 7 }
    # 1. Flatten catalog data first (provides catalog_flat.yml)
    Write-Host "[1/$numberOfSteps] Flattening catalog data..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_catalog_data.cs"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 2. Generate categories.yml from catalog + filter by catalog_flat
    Write-Host "[2/$numberOfSteps] Generating categories..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_categories.cs"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # Determine pagination size from src/_config.yml (if present)
    $perPage = 25
    $cfgPath = Join-Path $rootDir 'src'
    $cfgPath = Join-Path $cfgPath '_config.yml'
    if (Test-Path $cfgPath) {
        try {
            $cfgText = Get-Content -Raw -Path $cfgPath
            # Only honor the explicit pagination_size key
            $m = [regex]::Match($cfgText, '(?m)^\s*pagination_size\s*:\s*(\d+)')
            if ($m.Success) { $perPage = [int]$m.Groups[1].Value }
        } catch { }
    }

    # 3. Generate category pages (after categories.yml exists)
    Write-Host "[3/$numberOfSteps] Generating category pages (perPage=$perPage)..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_category_pages.cs" $perPage
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 4. Generate extension detail pages
    Write-Host "[4/$numberOfSteps] Generating extension pages..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_extension_pages.cs"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 5. Generate pagination for the full extensions list
    Write-Host "[5/$numberOfSteps] Generating extensions pagination pages..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_extensions_pages.cs"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 6. Generate letter pages
    Write-Host "[6/$numberOfSteps] Generating letter pages (perPage=$perPage)..." -ForegroundColor Yellow
    # Export as env var for any tools which may prefer it
    $env:PAGINATION_SIZE = $perPage
    dotnet "$rootDir/tools/build_letters.cs" $perPage
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 7. Compute site stats for homepage metrics
    Write-Host "[7/$numberOfSteps] Generating site stats..." -ForegroundColor Yellow
    dotnet "$rootDir/tools/build_site_stats.cs"
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

    # 8. Generate recent updates from catalog (optional, can be slow)
    if ($IncludeUpdates) {
        Write-Host "[$numberOfSteps/$numberOfSteps] Generating recent updates..." -ForegroundColor Yellow
        dotnet "$rootDir/tools/build_recent_updates.cs"
        if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
    }
    else {
        Write-Host "[Skipped] Recent updates step skipped (use -IncludeUpdates to enable)." -ForegroundColor Yellow
    }

    Write-Host "[$numberOfSteps/$numberOfSteps] Build pipeline complete." -ForegroundColor Yellow

    Write-Host ""
    Write-Host "=== Build Complete ===" -ForegroundColor Green
    Write-Host ""
    Write-Host "To build the Jekyll site:" -ForegroundColor Cyan
    Write-Host "  cd src"
    Write-Host "  bundle exec jekyll build"
    Write-Host ""
    Write-Host "To include the (slow) recent-updates generation in this pipeline, run:" -ForegroundColor Cyan
    Write-Host "  .\tools\build.ps1 -IncludeUpdates" -ForegroundColor Cyan
    Write-Host "or (some shells) use: .\tools\build.ps1 --includeUpdates" -ForegroundColor Cyan
    Write-Host ""
}
finally {
	Pop-Location
}
