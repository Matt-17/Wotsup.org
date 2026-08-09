---
overview: ".json files are JavaScript Object Notation: a lightweight, text-based data-interchange format of nested objects, arrays, and scalar values, ubiquitous in web APIs, configuration, and data storage."
extensions:
  - name: "JavaScript Object Notation (JSON)"
    description: "Lightweight text-based data interchange format of objects, arrays, and values"
    categories:
    - data-format
    - internet
    author: "Douglas Crockford / ECMA / IETF"
    link: "https://www.json.org/"
---

## JavaScript Object Notation (JSON)

JSON is the most widely used text format for exchanging structured data between
systems, especially over web APIs. It grew out of JavaScript's object literal
syntax but is language-independent, and virtually every programming environment has
built-in or standard-library support for reading and writing it. Its popularity
comes from being simple, human-readable, and a close match to the data structures
programmers already use.

A JSON document is a value: an object (an unordered set of name/value pairs written
in braces), an array (an ordered list in brackets), a string, a number, `true`,
`false`, or `null`. These compose recursively, so complex hierarchies are expressed
by nesting. Strings are always double-quoted and Unicode; the grammar is small and
strict, which makes JSON fast and predictable to parse. It is standardized by both
ECMA (ECMA-404) and the IETF (RFC 8259), which specifies UTF-8 as the interchange
encoding.

### Strengths And Limits

JSON deliberately omits features to stay simple: it has no comments, no date type
(dates are conventionally strings), no schema built in (JSON Schema is a separate
standard), and numbers are decimal with no distinction between integer and float,
which can cause precision issues with very large integers. For configuration where
comments matter, related formats such as JSON5, YAML, or TOML are often preferred.

### Preservation And Security Notes

JSON is excellent for preservation and interchange: open, text-based, UTF-8, and
self-describing. When parsing untrusted JSON, guard against extremely deep nesting
(stack exhaustion) and very large numbers or strings, and never evaluate JSON as
code — use a real parser rather than a language `eval`. The media type is
`application/json`.

### Further Reading

- Introducing JSON: `https://www.json.org/`
- RFC 8259 (The JSON Data Interchange Format): `https://datatracker.ietf.org/doc/html/rfc8259`
