---
overview: ".woff files are Web Open Font Format 1.0 fonts: compressed wrappers around TrueType or OpenType fonts intended for use on web pages."
extensions:
  - name: "Web Open Font Format (WOFF) 1.0"
    description: "zlib-compressed sfnt font wrapper for web delivery, a W3C Recommendation"
    categories:
    - fonts
    - internet
    author: "W3C"
    link: "https://www.w3.org/TR/WOFF/"
---

## WOFF

The Web Open Font Format (WOFF) 1.0 is a container for fonts delivered over the
web. It was published as a W3C Recommendation. A WOFF file is not a new font
design: it repackages an existing sfnt-based font (TrueType or OpenType) so that
it is smaller and easier to serve.

### Structure

A WOFF file starts with the signature `wOFF`. The header records the flavor of
the underlying font (for example TrueType or CFF outlines), the total sizes, and
the number of tables. Each font table is compressed individually with zlib
(DEFLATE) when that saves space, and the original table directory is stored so
the original sfnt font can be rebuilt exactly. The file may also carry an
optional XML metadata block, which can describe the font's vendor and license, and
an optional private data block.

### Adoption

WOFF is supported by all current browsers through the CSS `@font-face` rule.
The media type is `font/woff` (registered in RFC 8081). WOFF2, which uses
Brotli and gives better compression, has largely replaced it, but WOFF is still
used as a fallback for older clients.

### Preservation And Security Notes

WOFF does not change the license of the font and does not provide protection
against copying. Keep the original OpenType/TrueType source file for archival
purposes, since the WOFF wrapper can be regenerated from it. Decompression
and table parsing should validate sizes to avoid resource exhaustion or
memory errors.

### Further Reading

- WOFF File Format 1.0 (W3C): `https://www.w3.org/TR/WOFF/`
- RFC 8081, font media types: `https://www.rfc-editor.org/rfc/rfc8081`
