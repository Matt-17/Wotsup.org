---
extensions:
  - name: "ZIP File Format Specification version 6.3.10"
    description: "Current public PKWARE APPNOTE, revised November 1, 2022"
    categories:
    - archive
    author: "PKWARE Inc."
    link: "https://pkware.cachefly.net/webdocs/casestudies/APPNOTE.TXT"

  - name: "ZIP File Format (1998, historical)"
    description: "Historical ZIP File Format reference from 1998"
    categories:
    - archive
    author: "PKWARE Inc."
    file: zip_form.zip_

  - name: "ZIP File Format Specification version 4.5 (historical)"
    description: "Historical ZIP File Format Specification version 4.5"
    categories:
    - archive
    author: "PKWARE Inc."
    file: zip45.zip

  - name: "ZIP File Format Specification version 6.3.0 (historical)"
    description: "Historical ZIP File Format Specification version 6.3.0"
    categories:
    - archive
    author: "PKWARE Inc."
    file: zip63.zip
---

## Deep Dive

ZIP is both an archive format and a lightweight container format. It is best
known for bundling files with optional compression, but it also underpins many
application formats, including Office Open XML documents, Java archives, EPUB
books, OpenDocument files, Android packages, and some browser extension
packages. That broad reuse makes ZIP one of the most important formats to
understand when preserving, repairing, or inspecting modern files.

## How ZIP Is Organized

A ZIP file is built from per-file local headers, compressed file data, optional
data descriptors, a central directory, and an end-of-central-directory record.
The local headers allow streaming writers to emit each member as it is produced.
The central directory near the end of the file acts as the primary index used by
normal readers: it records names, offsets, sizes, compression methods,
timestamps, comments, extra fields, and other metadata.

This design is why many ZIP readers search from the end of the file first. If
the central directory is damaged, some recovery tools can still scan local file
headers, but filename metadata, comments, extra fields, and duplicate-entry
handling may no longer be reliable.

## Identification

Common ZIP signatures begin with the ASCII letters `PK`, named after Phil Katz.
Useful signatures include `50 4B 03 04` for a local file header, `50 4B 01 02`
for a central directory header, and `50 4B 05 06` for the end-of-central-
directory record. Other important signatures include `50 4B 07 08` for a data
descriptor when present, `50 4B 06 06` for the ZIP64 end-of-central-directory
record, and `50 4B 06 07` for the ZIP64 locator. Empty archives may contain
only the end record.

Do not rely only on the `.zip` extension. ZIP-based package formats often use
their own extension and may require specific internal files, such as
`[Content_Types].xml` in Office Open XML or `META-INF/MANIFEST.MF` in many Java
archives.

## Compression And Compatibility

The most common compression method is Deflate, but the ZIP specification has
grown to include stored entries, ZIP64 extensions for large files, and optional
methods or encryption schemes that not every reader supports. For maximum
interoperability, avoid exotic compression methods unless the target software is
known to support them.

ZIP64 is especially important for preservation. It is required when file sizes,
compressed sizes, archive offsets, central-directory sizes, or entry counts
exceed the classic ZIP field limits. Older tools may reject ZIP64 archives or
silently mishandle them.

## Preservation And Security Notes

ZIP archives should be validated for central-directory consistency, duplicate
filenames, path traversal entries such as `../`, absolute paths, malformed extra
fields, and decompression bombs. Preservation workflows should record both the
archive checksum and member-level checksums when possible. For ZIP-derived
formats, also validate the format-specific manifest and required directory
layout rather than treating the file as a generic archive only.

## Further Reading

- PKWARE APPNOTE 6.3.10: `https://pkware.cachefly.net/webdocs/casestudies/APPNOTE.TXT`
- IANA media type registration for `application/zip`
- Related container formats: JAR, EPUB, Office Open XML, OpenDocument, APK
