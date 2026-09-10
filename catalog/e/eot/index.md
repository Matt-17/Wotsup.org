---
overview: ".eot files are Embedded OpenType fonts: a Microsoft font format for embedding fonts in web pages, supported only by Internet Explorer and now obsolete."
extensions:
  - name: "Embedded OpenType (EOT)"
    description: "Compact font format for web embedding with optional compression and obfuscation"
    categories:
    - fonts
    - internet
    author: "Microsoft"
    link: "https://www.w3.org/submissions/EOT/"
---

## EOT

Embedded OpenType (EOT) is a font format that Microsoft introduced for
embedding fonts in web pages, supported by Internet Explorer. Microsoft
submitted it to the W3C as a Member Submission, but it was never adopted as a
standard. Other browsers chose WOFF instead.

### Structure

An EOT file consists of a header followed by font data. The header holds
fields such as the font name strings, version, and character set, and a magic
number (`0x504C`). The font data is a TrueType or OpenType font that can be
compressed with MicroType Express (MTX) compression and optionally obfuscated
with a simple XOR. The header can also list the web sites the font is allowed
to be used on, which was Microsoft's way of supporting font licensing
restrictions.

### Adoption

EOT was needed to support old Internet Explorer versions in `@font-face`.
Current Microsoft Edge and all other browsers use WOFF and WOFF2 instead, so
EOT is only found in legacy sites and style sheets. Several font converters can
create and read it.

### Preservation And Security Notes

Because EOT may be compressed and obfuscated, it is best to convert it to
a plain TrueType or OpenType file for preservation and keep that along with any
license information. As with all font parsers, a decoder should check the
declared sizes and offsets in the header.

### Further Reading

- Embedded OpenType (EOT) File Format, W3C Member Submission: `https://www.w3.org/submissions/EOT/`
