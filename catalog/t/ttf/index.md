---
overview: ".ttf files are TrueType fonts: scalable outline fonts defined by quadratic Bézier curves with hinting for sharp rendering at small sizes, the mainstream font format on Windows, macOS, and beyond."
extensions:
  - name: "TTF free source project"
    description: "TTF free source project"
    categories:
    - windows
    - fonts
    link: "http://www.freetype.org/"
    
  - name: "Opentype Spec"
    description: "Opentype Spec"
    categories:
    - windows
    - fonts
    author: "Microsoft Corp."
    link: "https://learn.microsoft.com/typography/opentype/spec/"
    
  - name: "Truetype Spec 1.66"
    description: "Truetype Spec 1.66"
    categories:
    - windows
    - fonts
    author: "Microsoft Corp."
    file: tt166spec.zip
    
  - name: "The TrueType Font File"
    description: "The TrueType Font File"
    categories:
    - fonts
    author: "Apple"
    link: "http://developer.apple.com/textfonts/TTRefMan/RM06/Chap6.html"
    deprecated: true
---

## TrueType Font (TTF)

TrueType is a scalable (outline) font format developed by Apple in the late 1980s
and quickly adopted by Microsoft, becoming the dominant font technology on both
platforms. Rather than storing bitmaps at fixed sizes, a TrueType font defines each
glyph as outlines made of straight lines and quadratic Bézier curves, so the same
font renders cleanly at any size. Its distinguishing strength is a powerful
"hinting" system — instructions executed by the rasterizer — that keeps text crisp
and legible at small sizes and low resolutions.

A TTF file uses the SFNT table-based container: a directory at the start locates a
set of named tables, such as `glyf` (glyph outlines), `cmap` (character-to-glyph
mapping), `head`, `hmtx` (horizontal metrics), `name`, and optional hinting tables.
This structure is shared with OpenType: OpenType is effectively a superset that can
carry either TrueType (`glyf`) or PostScript/CFF outlines and adds advanced
typographic features, which is why TrueType and OpenType fonts are closely related
and often both use the `.ttf` or `.otf` extensions.

### Preservation And Security Notes

TrueType is openly documented and universally supported, making it a safe format for
storing and distributing typefaces; note that fonts carry licensing terms and
embedding permissions (in the `OS/2` table) that should be respected. Because a TTF
contains hinting bytecode executed by the rasterizer, font engines have historically
been an attack surface, so systems that load untrusted fonts should use hardened,
sandboxed, up-to-date rasterizers.

### Further Reading

- OpenType specification (Microsoft): `https://learn.microsoft.com/typography/opentype/spec/`
- Apple TrueType Reference Manual: `https://developer.apple.com/fonts/TrueType-Reference-Manual/`
