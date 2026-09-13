---
overview: ".pptx files are Office Open XML presentations: the modern Microsoft PowerPoint format, a ZIP package (OPC) of XML parts and media describing slides, layouts, and embedded content."
extensions:
  - name: "Office Open XML Presentation (PPTX)"
    description: "ZIP-packaged XML presentation format (Microsoft PowerPoint / ECMA-376 / ISO 29500)"
    categories:
    - documents
    author: "Microsoft / ECMA / ISO"
    link: "https://learn.microsoft.com/openspecs/office_standards/ms-pptx/"
---

## Office Open XML Presentation (PPTX)

PPTX is the default presentation format of Microsoft PowerPoint since PowerPoint
2007 and the successor to the legacy binary `.ppt`. It is part of Office Open XML
(OOXML), standardized as ECMA-376 and ISO/IEC 29500. As with DOCX and XLSX, the
format is an open, inspectable package of XML rather than an opaque binary file.

A PPTX is a ZIP archive following the Open Packaging Conventions (OPC), so it
starts with the usual ZIP signature `PK`. Each slide is a separate XML part under
`ppt/slides/` (for example `ppt/slides/slide1.xml`), while slide layouts, slide
masters, themes, and notes live in their own parts. Images, audio, and video are
stored as separate files under `ppt/media/`, and `.rels` files declare the
relationships between parts. Related extensions are `.pptm` (macro-enabled),
`.ppsx` (slide show), and `.potx` (template).

### Interoperability And Tooling

PPTX is read and written by PowerPoint, LibreOffice Impress, Google Slides, Apple
Keynote (import/export), and many libraries, which makes it a practical exchange
format for editable presentations. Because it is ZIP plus XML, tools can generate
or inspect slides without PowerPoint. Layout and animation fidelity can still vary
between applications, and fonts that are not embedded or installed are substituted.
The media type is
`application/vnd.openxmlformats-officedocument.presentationml.presentation`.

### Preservation And Security Notes

For long-term preservation, keep the editable PPTX and consider a PDF rendition as
a fixed-layout companion. Presentations can contain linked or embedded external
content and, in the `.pptm` variant, VBA macros, so untrusted files should be
opened with macros disabled and external content blocked. When extracting parts
from the ZIP container, guard against decompression bombs and path traversal.

### Further Reading

- PPTX file format specification (Microsoft): `https://learn.microsoft.com/openspecs/office_standards/ms-pptx/`
- ECMA-376 (Office Open XML): `https://www.ecma-international.org/publications-and-standards/standards/ecma-376/`
