---
overview: ".woff2 files are Web Open Font Format 2.0 fonts: Brotli-compressed wrappers around TrueType or OpenType fonts, now the usual format for web font delivery."
extensions:
  - name: "Web Open Font Format (WOFF) 2.0"
    description: "Brotli-compressed sfnt font wrapper with font-specific table transforms, a W3C Recommendation"
    categories:
    - fonts
    - internet
    author: "W3C"
    link: "https://www.w3.org/TR/WOFF2/"
---

## WOFF2

WOFF2 is the second version of the Web Open Font Format, published by the W3C.
Like WOFF 1.0 it repackages an sfnt-based font (TrueType or OpenType) for web
delivery, but it achieves noticeably smaller files by using Brotli compression
and by preprocessing some font tables before compression.

### Structure

A WOFF2 file starts with the signature `wOF2`. The header records the font
flavor and sizes and is followed by a compact table directory. All table data
is compressed together as one Brotli stream rather than table by table. Certain
tables, notably the glyph data (`glyf` and `loca`), can be stored in a
transformed form that is more compressible and is reversed on decoding. WOFF2
also supports font collections, and like WOFF it can carry an optional metadata
block and private data.

### Adoption

All current major browsers support WOFF2 through CSS `@font-face`, and it is
usually the only web font format that a modern site needs to provide. The media
type is `font/woff2` (RFC 8081). Many font tools and the open-source `woff2`
reference implementation can create and read it.

### Preservation And Security Notes

WOFF2 is a delivery format. Keep the original OpenType or TrueType source and
its license for archiving, because the WOFF2 file is derived from it and
conversion may drop or alter tables. As with all font parsers, decoders should
check declared sizes, table offsets, and transform data when handling untrusted
files.

### Further Reading

- WOFF File Format 2.0 (W3C): `https://www.w3.org/TR/WOFF2/`
- RFC 8081, font media types: `https://www.rfc-editor.org/rfc/rfc8081`
