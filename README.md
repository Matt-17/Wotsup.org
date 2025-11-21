# Wotsup.org Repository

A modern, data-driven static site that preserves the classic Wotsit.org format specifications and resources, rebuilt with Jekyll and lightweight build tooling.

## Overview
- Purpose: Preserve and serve 300–500+ file format references in a clean static site.
- Stack: Jekyll 4, Ruby/Bundler, Liquid templates, YAML data, PowerShell + small C# utilities.
- Data: Human-authored YAML in `catalog/` flattens into `src/_data/*.yml` for rendering.
- Outputs: A ready-to-deploy static site in `src/_site/`.

## Quick Start (with PowerShell scripts)
```powershell
# From repo root
# 1) Optional clean
./tools/clean.ps1

# 2) Build all site data (categories, catalog flatten, letters, pages)
./tools/build.ps1

# 3) Serve Jekyll locally
bundle install
bundle exec jekyll serve
# Visit http://localhost:4000
```

## Data & Build Workflow
- Authoring source:
  - `catalog/categories.yaml` — canonical category list.
  - `catalog/<Letter>/*.yaml` — extension metadata grouped by first letter.
- Generated data (not hand-edited):
  - `src/_data/categories.yml` — from catalog categories.
  - `src/_data/catalog_flat.yml` — flattened extensions index.
  - `src/_data/letters.yml` — letters present in the catalog.
- Generated pages:
  - `src/extensions/*.md` — letter pages referencing shared includes.
  - `src/categories.md` — categories index.
- Tooling entrypoints (PowerShell/C#):
  - `tools/build.ps1` — orchestrates the correct generator order.
  - `tools/build_categories.cs`, `build_catalog_data.cs`, `build_letters.cs`, etc.
  - Integrity and utility: `tools/check_generated_integrity.ps1`.

Notes
- Generators write into `src/_data/` and `src/` as required; Jekyll reads those on build.
- The site templates deliberately skip empty categories and normalize letter filtering.

## Project Structure (high level)
- `catalog/` — Source YAML for categories and per-letter extension data.
- `src/` — Jekyll site (layouts, includes, pages, assets, `_data/`).
- `tools/` — Build scripts (PowerShell) and small generators (C#).

## Contributing
- Author new formats via YAML under `catalog/<Letter>/` and run the build.
- For Jekyll pages and site UI, see:
  - `src/contributing.md`
  - `src/how-to.md`
- Keep PRs focused: data-only changes vs template/build changes.

## Common Tasks
- Regenerate data only:
```powershell
./tools/build.ps1
```
- Full clean + rebuild:
```powershell
./tools/clean.ps1
./tools/build.ps1
cd src; 
bundle exec jekyll build
```
