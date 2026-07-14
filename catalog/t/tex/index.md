---
overview: ".tex files are TeX source documents: plain-text input for Donald Knuth's TeX typesetting system (and macro packages such as LaTeX) that produce high-quality typeset output, especially for mathematics and technical work."
extensions:
  - name: "TeX, LaTeX, makeindx, Metafont formats"
    description: "TeX, LaTeX, makeindx, Metafont formats"
    categories:
    - documents
    link: "http://www.dante.de/"

  - name: "MusiXTeX, PMX, M-Tx formats"
    description: "MusiXTeX, PMX, M-Tx formats"
    categories:
    - documents
    link: "http://www.gmd.de/Misc/Music/"
    deprecated: true

  - name: "MusiXTeX, PMX, M-Tx formats"
    description: "MusiXTeX, PMX, M-Tx formats"
    categories:
    - audio
    link: "http://www.gmd.de/Misc/Music/"
    deprecated: true
---

## TeX

TeX is a typesetting system created by Donald Knuth, designed to produce
consistently high-quality typeset documents with especially strong handling of
mathematical notation. A `.tex` file is the plain-text source: ordinary text
interspersed with control sequences (commands beginning with a backslash) that
instruct the typesetter how to format the document. TeX is renowned for the
quality of its line-breaking, spacing, and math layout, which is why it is
standard in mathematics, physics, and computer science publishing.

In practice most authors write in a macro package built on TeX rather than plain
TeX. LaTeX is by far the most common, providing higher-level commands for
document structure (sections, figures, cross-references, bibliographies), while
formats like ConTeXt and specialized packages such as MusiXTeX serve other needs.
The related Metafont system, also by Knuth, describes fonts programmatically.

### Processing And Output

A TeX engine processes the source and emits typeset pages. Traditional TeX
produces DVI (device-independent) output that is then converted for a target
device, while modern engines such as pdfTeX, XeTeX, and LuaTeX generate PDF
directly and add support for system fonts and Unicode. A document often depends on
external class and package files, fonts, and included graphics, so the `.tex`
source is rarely self-contained.

### Preservation And Security Notes

TeX source is excellent for preservation because it is open, text-based, and
human-readable, but faithful reproduction depends on the specific engine, packages,
and fonts used; recording those, or keeping a rendered PDF/A derivative alongside
the source, is prudent. Note that TeX is a full programming system and can, if
enabled, read and write files and run external programs, so compiling untrusted
`.tex` should be done with shell-escape disabled and in a sandbox.

### Further Reading

- TeX Users Group (TUG): `https://www.tug.org/`
- The LaTeX Project: `https://www.latex-project.org/`
