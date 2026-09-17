---
overview: ".arrow files are Apache Arrow IPC files (also called Feather V2): a binary file format that stores columnar tables in the Arrow in-memory layout for fast, zero-copy access."
extensions:
  - name: "Apache Arrow IPC File (Feather V2)"
    description: "Columnar binary file format storing Arrow record batches (also used with .feather)"
    categories:
    - data-format
    - databases
    author: "Apache Software Foundation"
    link: "https://arrow.apache.org/docs/format/Columnar.html"
---

## Apache Arrow IPC File

Apache Arrow defines a language-independent columnar memory format for tabular
data. The Arrow IPC file format is the on-disk serialization of that layout: it
writes record batches in essentially the same form they have in memory, so a
reader can memory-map a file and use the data without a costly parsing or
deserialization step. Files commonly use the extension `.arrow` or `.feather`; the
Feather V2 format is the Arrow IPC file format.

The file format begins with the magic string `ARROW1` (padded to 8 bytes),
followed by the schema message and then a series of record batch (and optional
dictionary batch) messages, and ends with a footer containing the schema and the
locations of each block, followed by the footer length and the magic string
`ARROW1` again. The footer allows random access to individual record batches. A
related streaming variant, the IPC stream format, has no footer and is meant for
sequential reads and sending data over pipes and sockets; it is often stored
with the extension `.arrows`. Message metadata is encoded with FlatBuffers, and
buffers can optionally be compressed with LZ4 frame or Zstandard.

### Adoption

Arrow is implemented in C++, Python, R, Java, Rust, Go, JavaScript, and other
languages, and is used by pandas, Polars, DuckDB, and many data tools as a common
exchange layer. Compared with Parquet, Arrow files favor read speed and
interoperability over compactness, so Parquet is more usual for long-term
storage.

### Preservation And Security Notes

The format is open and documented and the schema is embedded in each file. When
reading untrusted files, validate buffer lengths and offsets before use, as
zero-copy readers rely on them being consistent.

### Further Reading

- Arrow columnar format specification (including IPC formats): `https://arrow.apache.org/docs/format/Columnar.html`
- Apache Arrow FAQ: `https://arrow.apache.org/faq/`
