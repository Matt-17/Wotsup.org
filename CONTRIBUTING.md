# Contributing to Wotsup.org

Contributions that improve the accuracy, availability, or technical depth of the catalog are welcome. Small, source-backed pull requests are easiest to review.

## Good Ways to Help

- Recover a specification listed on the [undocumented formats backlog](https://wotsup.org/undocumented-formats/).
- Add detailed format notes, signatures, structures, or implementation guidance.
- Replace a broken reference with an authoritative source.
- Correct inaccurate descriptions, categories, attribution, or aliases.
- Add a format that is not yet represented in the catalog.

If you found material but are unsure how it should be used, open a [missing-specification issue](https://github.com/Matt-17/Wotsup.org/issues/new?template=missing-specification.yml).

## Catalog Entries

Authoritative content lives at:

```text
catalog/<letter>/<extension>/index.md
```

Use lowercase directory names and categories defined in `catalog/categories.yaml`. A minimal entry looks like this:

```markdown
---
overview: ".abc is used for Example Binary Container files."
extensions:
  - name: "Example Binary Container"
    description: "Binary interchange format used by Example applications."
    categories:
      - data-format
    author: "Example Organization"
    link: "https://example.org/specification"
---

## Example Binary Container

Add identification details, file structure, compatibility notes, and references here.
```

Put redistributable reference files beside `index.md` and reference them with `file:`. Include provenance, attribution, and license information. Link material that cannot be redistributed instead of copying it into the repository.

## Validation

Run from the repository root:

```powershell
dotnet tools/validate_yaml_schema.cs
dotnet tools/validate_catalog.cs
./tools/build.ps1
./tools/check_generated_integrity.ps1
git diff --check
```

For site or dependency changes, also run:

```powershell
cd src
bundle exec jekyll doctor
bundle exec jekyll build
```

Do not edit generated files in `src/_data/`, `src/extensions/`, `src/categories/`, `src/letters/`, or `src/files/`.

## Pull Requests

- Keep each pull request focused on one format or one related change.
- Explain what changed and why.
- Cite primary or authoritative sources.
- Include license and redistribution notes for added files.
- List the validation commands you ran.
