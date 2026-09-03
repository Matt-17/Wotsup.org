---
overview: ".kra files are Krita documents: the native layered painting format of the Krita digital painting application, stored as a ZIP archive."
extensions:
  - name: "Krita document (KRA)"
    description: "Native layered document format of Krita, a ZIP package with XML and layer data"
    categories:
    - 2d-graphics
    author: "Krita Foundation"
    link: "https://docs.krita.org/en/general_concepts/file_formats/file_kra.html"
---

## KRA

KRA is the native file format of Krita, a free and open source painting
program. It preserves everything Krita can edit, including multiple layers,
masks, filter and vector layers, animation frames, color profiles, and
document metadata, so it is the format to use for working files, while
flattened formats such as PNG or JPEG are used for sharing.

### Technical Structure

A KRA file is a ZIP archive. Following the OpenDocument-style convention,
the first entry is an uncompressed `mimetype` file containing
`application/x-krita`. The archive also contains `maindoc.xml`, which describes
the image size, color space, and layer stack, `documentinfo.xml` with
metadata, and a folder with the data for each layer. Layer pixel data uses
Krita's own tiled format. A `mergedimage.png` holds the flattened image and a
`preview.png` holds a thumbnail, so other tools can display the content
without decoding the layers.

### Adoption And Tooling

Krita reads and writes KRA on Windows, macOS, and Linux. Some other
applications can import it, and file managers and thumbnailers can use the
embedded preview. Because the container is a ZIP file, a KRA file can be
inspected with common archive tools.

### Preservation Notes

For long-term storage, keep the KRA together with a flattened export such
as PNG, since only Krita fully interprets the layer structures and some
features depend on the Krita version. Record the Krita version, color
space, and bit depth. As with any ZIP-based format, readers should guard
against oversized or malformed entries when handling untrusted files.

### Further Reading

- Krita manual, KRA format: `https://docs.krita.org/en/general_concepts/file_formats/file_kra.html`
