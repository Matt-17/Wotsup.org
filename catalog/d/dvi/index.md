---
overview: ".dvi files are DeVice Independent documents produced by TeX: a compact, page-oriented description of typeset pages that references fonts and positions rather than embedding them, meant to be rendered by a separate driver."
extensions:
  - name: "TeX DVI (DeVice Independent) format"
    description: "Page-oriented binary output of the TeX typesetting system"
    categories:
    - documents
    author: "David R. Fuchs / Donald E. Knuth (TeX project)"
    link: "https://en.wikipedia.org/wiki/Device_independent_file_format"
    file: dvistd0.zip
---

## TeX DVI (DeVice Independent)

DVI is the traditional output format of the TeX typesetting system. When TeX
processes a source document it does not draw pixels or embed fonts; instead it
emits a `.dvi` file, a compact binary stream of commands that says, in effect,
"place this character from this font at this position on this page." The name
"device independent" reflects that the result describes the typeset layout
abstractly, leaving actual rendering to a downstream driver.

A DVI file is a sequence of opcodes framed by a preamble and postamble. The
preamble records the magnification and a comment; the body contains page
`bop`/`eop` groups with commands to set characters, move the current point,
select fonts, and draw rules; and the postamble summarizes font definitions and
the largest page dimensions to support random access. Fonts are referenced by
name and metrics (from TFM files) rather than being embedded in the DVI itself.

### Rendering And Drivers

Because a DVI file only references fonts and positions, it must be paired with a
driver that resolves those references for a target device. Historically that
meant tools like `dvips` to produce PostScript, `dvipdfm`/`dvipdfmx` to produce
PDF, `xdvi` to display on screen, and printer-specific drivers. The visual
result therefore depends on the fonts available to the driver, which is the
key consideration when moving DVI files between systems.

In modern workflows DVI has largely been superseded by direct PDF output from
`pdfTeX`, `XeTeX`, and `LuaTeX`, which embed fonts and produce self-contained
documents. DVI is still generated and used within TeX toolchains and remains
important for legacy documents and for its transparent, well-documented format.

### Preservation Notes

A DVI file is not self-contained: faithful reproduction depends on the exact
fonts (and their TFM metrics) and on any figures included via specials, such as
embedded PostScript. For preservation, keep the DVI together with the required
fonts and included graphics, or produce a self-contained PDF derivative while
retaining the original DVI and TeX sources.

### Security Notes

DVI `\special` commands can embed device-specific instructions, including
references to external files and PostScript to be passed through to a driver.
Renderers and print pipelines that process untrusted DVI should constrain how
specials and external references are handled rather than executing them
blindly.

### Further Reading

- Device independent file format overview: `https://en.wikipedia.org/wiki/Device_independent_file_format`
- The DVI Driver Standard and TeX documentation: `https://www.tug.org/`
