#!/usr/bin/env pwsh
# tools/clean.ps1
# Remove all generated data files and pages

$ErrorActionPreference = "Stop"
$rootDir = Split-Path -Parent $PSScriptRoot

Write-Host "=== Cleaning Generated Data ===" -ForegroundColor Cyan
Write-Host ""

$itemsToRemove = @(
    # Generated data files
    @{Path = "src\_data"; Type = "Directory"},
    # Generated pages (letter pages in extensions, category pages in categories)
    @{Path = "src\extensions"; Type = "Directory"},
    @{Path = "src\categories"; Type = "Directory"},
    @{Path = "src\files"; Type = "Directory"},
    
    # Jekyll build output
    @{Path = "src\_site"; Type = "Directory"},
    @{Path = "src\.jekyll-cache"; Type = "Directory"}
)

$removed = 0
$notFound = 0

foreach ($item in $itemsToRemove) {
    $fullPath = Join-Path $rootDir $item.Path
    
    if (Test-Path $fullPath -PathType Container) {
        Write-Host "Removing directory: $($item.Path)" -ForegroundColor Yellow
        Remove-Item -Path $fullPath -Recurse -Force
        $removed++
    } else {
        Write-Host "Not found: $($item.Path)" -ForegroundColor Gray
        $notFound++
    }   
}

Write-Host ""
Write-Host "=== Clean Complete ===" -ForegroundColor Green
Write-Host "Removed: $removed items" -ForegroundColor Cyan
Write-Host "Not found: $notFound items" -ForegroundColor Gray
Write-Host ""
Write-Host "To rebuild, run:" -ForegroundColor Cyan
Write-Host "  .\tools\build.ps1"
Write-Host ""
