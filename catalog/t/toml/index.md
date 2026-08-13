---
overview: ".toml files are TOML configuration documents: a plain-text config format designed to be obvious and unambiguous, mapping to a hash table with typed values, tables, and arrays."
extensions:
  - name: "Tom's Obvious Minimal Language (TOML)"
    description: "Readable, strongly typed configuration file format that maps to a hash table"
    categories:
    - data-format
    author: "Tom Preston-Werner"
    link: "https://toml.io/"
---

## TOML

TOML ("Tom's Obvious, Minimal Language") is a configuration file format designed to
be easy for people to read and write while mapping cleanly and unambiguously onto a
hash table (dictionary) in code. It was created in reaction to the ambiguities of
older config approaches: where INI files are underspecified and YAML's whitespace
rules and implicit typing can surprise users, TOML aims to be explicit and
predictable. It has become especially common in developer tooling — for example as
the format for Rust's `Cargo.toml` and Python's `pyproject.toml`.

A TOML document is a set of key/value pairs. Values are strongly typed: strings,
integers, floats, booleans, first-class date and time types, arrays, and inline
tables. Sections are introduced by "tables" written as `[table]` headers (and
`[[array-of-tables]]` for repeated sections), which nest to build hierarchy. The
syntax is line-oriented and supports comments with `#`, both of which aid
human editing and version-control diffs.

### Comparison And Use

TOML occupies a middle ground: more structured and typed than INI, more explicit and
less error-prone for hand editing than YAML, and more configuration-friendly than
JSON (which lacks comments and dates). It is best suited to configuration rather than
to large data payloads or deeply nested data, where JSON or YAML may fit better.

### Preservation And Security Notes

TOML is open (with a formal, versioned specification), UTF-8 text, and
human-readable, which suits it well for preserving configuration. Parsers handling
untrusted input should reject duplicate keys and malformed structures per the spec
and, as always, avoid evaluating values as code.

### Further Reading

- TOML specification and overview: `https://toml.io/`
