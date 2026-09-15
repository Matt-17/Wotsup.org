---
overview: ".ndjson files are Newline Delimited JSON files: text files containing one JSON value per line, also known as JSON Lines (.jsonl), suited to streaming and log-style data."
extensions:
  - name: "Newline Delimited JSON (NDJSON / JSON Lines)"
    description: "Text format with one JSON value per line, used for streaming and record-oriented data (also .jsonl)"
    categories:
    - data-format
    - internet
    author: "NDJSON specification contributors"
    link: "https://github.com/ndjson/ndjson-spec"
---

## Newline Delimited JSON (NDJSON)

NDJSON is a convention for storing a sequence of JSON values in a text file or
stream, with exactly one value per line, usually a JSON object. A closely related
convention, JSON Lines, uses the extension `.jsonl` and the same layout; the two
are, for practical purposes, interchangeable.

Each line must be a valid, self-contained JSON text, and lines are separated by a
newline character (`\n`, with `\r\n` tolerated by parsers). Because records are
separated by line breaks, a JSON value on a line may not contain raw newlines
(they appear escaped as `\n` inside strings). This is what distinguishes NDJSON
from a single JSON array: a file can be read, filtered, split, or appended to one
record at a time without parsing the whole document.

### Adoption

NDJSON is widely used for log files, data exports, and streaming APIs. Many
databases and analytics tools import and export it, and command-line tools such
as `jq` process it line by line. The encoding is UTF-8. A commonly used media
type is `application/x-ndjson`.

### Preservation And Security Notes

Plain-text, line-oriented files are easy to inspect, compress, and diff, which
suits long-term storage, but NDJSON has no schema or type enforcement, so
records in one file can have differing structures. Consumers should handle
malformed lines and very long lines defensively, and apply the usual JSON
precautions (deeply nested input, duplicate keys, and number precision) when
parsing untrusted data.

### Further Reading

- NDJSON specification: `https://github.com/ndjson/ndjson-spec`
- JSON Lines: `https://jsonlines.org/`
