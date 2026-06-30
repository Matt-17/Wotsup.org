# Wotsup.org

[![PR Build Check](https://github.com/Matt-17/Wotsup.org/actions/workflows/pr-check.yml/badge.svg)](https://github.com/Matt-17/Wotsup.org/actions/workflows/pr-check.yml)
[![Deploy to Production](https://github.com/Matt-17/Wotsup.org/actions/workflows/jekyll-build.yml/badge.svg?branch=master)](https://github.com/Matt-17/Wotsup.org/actions/workflows/jekyll-build.yml)

**Live site:** [wotsup.org](https://wotsup.org/)

**Browse:** [extensions](https://wotsup.org/extensions/) | [how to use](https://wotsup.org/how-to/) | [contributing guide](https://wotsup.org/contributing/) | [GitHub actions](https://github.com/Matt-17/Wotsup.org/actions)

Wotsup.org is a static catalog of file format specifications and related implementation references. The repository keeps the human-authored catalog in Markdown/YAML and generates the Jekyll pages, data files, and downloadable file tree used by the live site.

## Current Workflow Status

- **PR Build Check** runs on pull requests to `master`. It validates catalog schema, audits the catalog, checks generated output integrity, builds the generated pages, runs `jekyll doctor`, builds the Jekyll site, and runs `bundler-audit`.
- **Deploy to Production** runs on pushes to `master`. It validates the catalog, runs the production generator path with recent updates enabled, builds the Jekyll site, packages `src/_site/`, and deploys it with the configured GitHub Actions secrets.
- Local development should mirror the PR workflow before opening a pull request. Use the commands in [Validation](#validation) when you touch catalog data, generator code, layouts, or dependencies.

## Repository Layout

- `catalog/categories.yaml` is the canonical category list.
- `catalog/<letter>/<extension>/index.md` contains each authored extension entry, using YAML front matter plus optional Markdown body content.
- `catalog/<letter>/<extension>/*` may contain attached specification files referenced from front matter with `file:`.
- `src/` contains the Jekyll site: layouts, includes, styles, static pages, and generated data.
- `tools/` contains the PowerShell and file-based C# generators and validators.
- Generated output is written to `src/_data/`, `src/extensions/`, `src/categories/`, `src/letters/`, `src/files/`, and `src/_site/`. Do not hand-edit generated files.

## Prerequisites

- .NET SDK 10.x for the file-based C# tools used by CI.
- Ruby 3.3 with Bundler for Jekyll.
- PowerShell 7+ for the `tools/*.ps1` scripts.

Install Ruby dependencies from the Jekyll project directory:

```powershell
cd src
bundle install
cd ..
```

## Quick Start

```powershell
# From the repository root
./tools/build.ps1

cd src
bundle exec jekyll serve
```

Open [http://localhost:4000](http://localhost:4000) after the server starts.

## Catalog Workflow

1. Edit or add an extension entry under `catalog/<letter>/<extension>/index.md`.
2. Keep category names lowercase and matching `catalog/categories.yaml`, for example `archive`, `data-format`, or `gis-formats`.
3. Put attached specs or reference files next to the entry and reference them from front matter with `file: filename.ext`.
4. Run the generators with `./tools/build.ps1`.
5. Validate the generated output before committing.

Example entry shape:

```markdown
---
overview: ".zip is used for ZIP archives and ZIP-based container formats."
extensions:
  - name: "ZIP Archive"
    description: "Compressed archive and package container format."
    categories:
      - archive
    author: "PKWARE Inc."
    link: "https://example.com/spec"
---

## ZIP Archive

Add concise notes, identification details, compatibility notes, and references here.
```

## Build Commands

```powershell
# Remove generated data, pages, copied files, and Jekyll output
./tools/clean.ps1

# Regenerate catalog data, pages, letters, and site stats
./tools/build.ps1

# Production-style generation, including slower recent-updates data
./tools/build.ps1 -IncludeUpdates

# Build the static Jekyll site
cd src
bundle exec jekyll build
```

## Validation

Run these from the repository root unless noted:

```powershell
dotnet tools/validate_yaml_schema.cs
dotnet tools/validate_catalog.cs
./tools/build.ps1
./tools/check_generated_integrity.ps1
git diff --check
```

For layout, dependency, or production-path changes, also run:

```powershell
cd src
bundle exec jekyll doctor
bundle exec jekyll build
bundle exec bundler-audit check --update
```

## Contributing

Keep pull requests focused. Separate catalog-data changes from template, generator, or deployment changes when practical. Include source and license notes for added specification files, and mention the validation commands you ran.

Useful links:

- [Live contribution guide](https://wotsup.org/contributing/)
- [How to use Wotsup.org](https://wotsup.org/how-to/)
- [GitHub issues](https://github.com/Matt-17/Wotsup.org/issues)
- [Current GitHub Actions status](https://github.com/Matt-17/Wotsup.org/actions)

## Security Notes

Do not commit deployment credentials, local secrets, or generated deployment packages. The production deploy uses GitHub Actions secrets and repository variables; local configuration should stay limited to .NET, Bundler, and generated build output.
