# Repository Guidelines

## Project Structure & Module Organization

This repository builds the Wotsup.org static catalog site. Authoritative catalog content lives in `catalog/`: `catalog/categories.yaml` defines category metadata, and each extension belongs under `catalog/<letter>/<extension>/index.md` with YAML front matter plus optional attached files. The Jekyll site lives in `src/`, including layouts in `src/_layouts/`, reusable fragments in `src/_includes/`, styles and images in `src/assets/`, and pages such as `src/index.md`. Build tooling is in `tools/`; generated output is written to `src/_data/`, `src/extensions/`, `src/categories/`, `src/files/`, and `src/_site/`.

## Build, Test, and Development Commands

- `./tools/clean.ps1`: removes generated data, pages, copied files, and Jekyll output.
- `./tools/build.ps1`: regenerates catalog data, category pages, extension pages, letter pages, and site stats.
- `./tools/build.ps1 -IncludeUpdates`: includes the slower recent-updates generation used by production deploys.
- `cd src; bundle install`: installs Ruby dependencies for Jekyll.
- `cd src; bundle exec jekyll serve`: serves the site locally at `http://localhost:4000`.
- `cd src; bundle exec jekyll build`: builds the static site into `src/_site/`.

## Coding Style & Naming Conventions

Use Markdown with YAML front matter for catalog entries. Keep category names lowercase kebab-case, matching values in `catalog/categories.yaml` such as `archive` or `data-format`. Place new extensions in lowercase directory names under the matching first-letter folder, for example `catalog/z/zip/index.md`. PowerShell and C# tooling should stay small, deterministic, and runnable from the repository root. Do not hand-edit generated files in `src/_data/`, `src/extensions/`, `src/categories/`, or `src/files/`.

## Testing Guidelines

Mirror CI before opening a PR. Run `dotnet tools/validate_yaml_schema.cs` for the legacy schema check, then `./tools/check_generated_integrity.ps1` to confirm generator output is idempotent. Use `dotnet tools/validate_catalog.cs` for the stricter read-only catalog audit. For site changes, also run `cd src; bundle exec jekyll doctor` and `cd src; bundle exec jekyll build`. If dependencies changed, run `cd src; bundle exec bundler-audit check --update`.

## Commit & Pull Request Guidelines

Recent commits use short imperative summaries, for example `Added .dbc extension` or `Add HTTPS redirection rules to .htaccess`. Keep commits focused by separating catalog-data changes from template or tooling changes. Pull requests should describe the affected formats or pages, link relevant issues, include source or license notes for added files, and mention validation commands run. Include screenshots when changing visible layout or navigation.

## Security & Configuration Tips

Do not commit deployment credentials or generated deploy artifacts. Production deployment uses GitHub Actions secrets and variables; keep local configuration limited to Bundler, .NET, and generated build output.
