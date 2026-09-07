---
overview: ".otf files are OpenType fonts: scalable font files that may contain either PostScript-style (CFF) or TrueType outlines together with advanced typographic layout tables."
extensions:
  - name: "OpenType font format"
    description: "Scalable font format with CFF or TrueType outlines and advanced layout features"
    categories:
    - fonts
    author: "Microsoft / Adobe"
    link: "https://learn.microsoft.com/en-us/typography/opentype/spec/"
---

## OpenType (OTF)

OpenType is a scalable font format developed by Microsoft and Adobe as a
successor to TrueType and PostScript Type 1 fonts. It has since been
standardized as ISO/IEC 14496-22 (Open Font Format). The `.otf` extension is
conventionally used when the font contains PostScript-flavored CFF outlines,
while TrueType-flavored OpenType fonts often keep the `.ttf` extension.

### Structure

OpenType uses the sfnt wrapper: a table directory followed by tables that hold
the data. The first four bytes identify the outline type: `OTTO` for CFF or
CFF2 outlines, or `00 01 00 00` for TrueType outlines. Common tables include
`cmap` (character to glyph mapping), `head`, `hhea`, `hmtx`, `name`, `OS/2`, and
`CFF ` (or `glyf`/`loca` for TrueType outlines). Layout tables such as `GSUB`,
`GPOS`, and `GDEF` provide ligatures, kerning, and script-specific shaping.
Variable fonts add tables such as `fvar` and `gvar`. A font collection uses
the `.ttc` or `.otc` extension.

### Adoption

OpenType is the standard desktop and web font format, supported by operating
systems, browsers, and design software. The media type is `font/otf`. For web
delivery, fonts are usually repackaged as WOFF or WOFF2.

### Preservation And Security Notes

Preserve the original font file together with its license, since embedding and
redistribution rights are recorded in the `OS/2` and `name` tables and are
governed by the license. Font parsers handle complex binary structures and have
a history of vulnerabilities, so untrusted fonts should be processed by patched,
sandboxed libraries.

### Further Reading

- OpenType specification (Microsoft): `https://learn.microsoft.com/en-us/typography/opentype/spec/`
- OpenType font file organization: `https://learn.microsoft.com/en-us/typography/opentype/spec/otff`
