# Wotsup.org

<p align="center">
  <a href="https://wotsup.org/">
    <img src="src/assets/img/wotsup_560x320.png" width="420" alt="Wotsup.org">
  </a>
</p>

<p align="center">
  <strong>An open catalog of file format specifications, data structures, and implementation notes.</strong>
</p>

<p align="center">
  <a href="https://wotsup.org/">Browse the catalog</a> ·
  <a href="https://wotsup.org/undocumented-formats/">Find undocumented formats</a> ·
  <a href="https://wotsup.org/contributing/">Contribute</a>
</p>

<p align="center">
  <a href="https://github.com/Matt-17/Wotsup.org/actions/workflows/pr-check.yml"><img src="https://github.com/Matt-17/Wotsup.org/actions/workflows/pr-check.yml/badge.svg" alt="PR Build Check"></a>
  <a href="https://github.com/Matt-17/Wotsup.org/actions/workflows/jekyll-build.yml"><img src="https://github.com/Matt-17/Wotsup.org/actions/workflows/jekyll-build.yml/badge.svg?branch=master" alt="Deploy to Production"></a>
</p>

Wotsup.org helps developers, digital archivists, reverse engineers, and curious people find the technical information needed to understand files. The catalog combines preserved reference material with modern, community-maintained format notes.

## What You Can Find

- File format specifications and implementation references
- Data structures, signatures, compatibility notes, and decoding guidance
- Historical formats that are difficult to research elsewhere
- A public backlog of formats whose original documentation is still missing

The catalog is intentionally broader than a list of filename extensions. Entries may cover containers, protocols, hardware-related data, interchange formats, and other structured data.

## Help Recover Missing Knowledge

Some references known to the catalog have been lost or are no longer available. The [undocumented formats backlog](https://wotsup.org/undocumented-formats/) collects entries for which Wotsup currently has no preserved specification, active source, or detailed format notes.

You can help by:

- locating a specification or authoritative technical reference;
- contributing original format notes or data structures;
- providing legally redistributable reference files;
- correcting an inaccurate entry or replacing a broken link.

[Open a missing-specification issue](https://github.com/Matt-17/Wotsup.org/issues/new?template=missing-specification.yml) or submit a focused pull request.

## Contributing

Catalog content lives in `catalog/`. Each entry uses Markdown with YAML front matter:

```text
catalog/<letter>/<extension>/index.md
```

Attached specifications belong beside the entry and are referenced with `file:`. External primary sources use `link:`. Include source, attribution, and license information whenever possible.

See the [contribution guide](https://wotsup.org/contributing/) for the complete workflow.

## Local Development

Requirements:

- .NET SDK 10.x
- Ruby 3.3 with Bundler
- PowerShell 7+

```powershell
./tools/build.ps1

cd src
bundle install
bundle exec jekyll serve
```

The local site is available at `http://localhost:4000`.

## Validation

Run the repository checks from the project root:

```powershell
dotnet tools/validate_yaml_schema.cs
dotnet tools/validate_catalog.cs
./tools/build.ps1
./tools/check_generated_integrity.ps1

cd src
bundle exec jekyll doctor
bundle exec jekyll build
```

Generated content under `src/_data/`, `src/extensions/`, `src/categories/`, `src/letters/`, and `src/files/` must not be edited manually.

## Project Structure

| Path | Purpose |
| --- | --- |
| `catalog/` | Authoritative catalog entries and preserved files |
| `src/` | Jekyll layouts, pages, assets, and generated site data |
| `tools/` | Catalog generators and validators |
| `.github/` | Continuous integration and contribution templates |

## Project Background

Wotsup.org includes material preserved from the former Wotsit.org collection, but it is maintained as an independent, evolving catalog. The goal is not only to preserve historical references, but also to improve entries, add current specifications, and make technical format knowledge easier to discover and contribute to.

## License and Attribution

Specifications and attached documents may have their own authors, copyright terms, and licenses. Preserve attribution and verify redistribution rights when contributing files. Repository code and catalog metadata follow the licensing information provided in this repository.
