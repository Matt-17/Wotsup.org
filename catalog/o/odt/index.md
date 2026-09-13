---
overview: ".odt files are OpenDocument Text files: the OASIS/ISO standard XML-in-ZIP format used by LibreOffice and Apache OpenOffice for word-processing documents."
extensions:
  - name: "OpenDocument Text (.odt)"
    description: "ZIP-packaged XML word-processing format from the OpenDocument Format (ODF) standard (OASIS / ISO/IEC 26300)"
    categories:
    - documents
    author: "OASIS"
    link: "https://docs.oasis-open.org/office/v1.2/OpenDocument-v1.2.html"
---

## OpenDocument Text (.odt)

The .odt extension is the word-processing member of the OpenDocument Format (ODF), an open
XML-based office format family developed by OASIS and also published as ISO/IEC
26300. ODF is the native format of LibreOffice and Apache OpenOffice and is
supported by many other office suites, so .odt is a vendor-neutral way to store and
exchange word-processing documents.

An ODF file is a ZIP package. By convention the first entry is an uncompressed
file named `mimetype` containing the media type (`application/vnd.oasis.opendocument.text`
for .odt), which lets tools identify the file without parsing the XML. The package
also holds `content.xml` (the document body), `styles.xml`, `meta.xml`
(metadata), `settings.xml`, a `META-INF/manifest.xml` listing all parts, and
embedded media. The text content is in `content.xml` as paragraphs, headings, lists, and tables.

### Tooling And Interoperability

LibreOffice, Apache OpenOffice, Calligra, and many libraries read and write ODF, and
several other applications (including Microsoft Office and Google Workspace)
import and export it with varying fidelity. Complex formatting, macros, and
application-specific features may not round-trip exactly between suites.

### Preservation And Security Notes

Because it is an open, standardized, and documented format, ODF is widely
recommended for long-term storage of editable documents; keep a PDF/A rendition
if fixed layout matters. Documents can contain macros, scripts, and links to
external resources, so untrusted files should be opened with macros disabled. When
extracting the ZIP container, guard against decompression bombs and path
traversal.

### Further Reading

- OpenDocument v1.2 specification (OASIS): `https://docs.oasis-open.org/office/v1.2/OpenDocument-v1.2.html`
- OpenDocument v1.3, Part 1 Introduction: `https://docs.oasis-open.org/office/OpenDocument/v1.3/OpenDocument-v1.3-part1-introduction.html`
