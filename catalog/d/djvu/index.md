---
overview: ".djvu files are DjVu documents: an image format built for scanned pages, using layered separation and specialized compression to store high-resolution scans of text and drawings at small file sizes."
extensions:
  - name: "Complete DjVu specification (in DJVU so you need the plugin)"
    description: "Complete DjVu specification (in DJVU so you need the plugin)"
    categories:
    - 2d-graphics
    author: "AT&T"
    link: "http://www.djvuzone.org/djvu/djvu/djvuspec/001.djvu"
    deprecated: true
---

## DjVu

DjVu (pronounced "déjà vu") is an image format developed at AT&T Labs
specifically for distributing scanned documents. Its goal is to make
high-resolution scans of books, journals, and manuscripts small enough to
download and view page-by-page, where general-purpose formats like TIFF or PDF
of the same scans would be far larger. It became popular for digital libraries
and archives of scanned material.

The key idea is layered separation. DjVu splits a scanned page into a sharp,
bi-level mask for text and line art (compressed with the JB2 method, which reuses
repeated character shapes) and smooth foreground and background layers for color
and continuous-tone content (compressed with the IW44 wavelet method). Compressing
each layer with a method suited to its content yields much smaller files at a
given quality. A DjVu file can also carry a hidden OCR text layer for searchable,
selectable text, plus an outline and annotations, and multiple pages can be bundled
in one document.

### Status And Preservation Notes

DjVu is an open format with free viewers and encoders (the DjVuLibre project), but
it is less universally supported than PDF, so long-term access may depend on
keeping compatible software available. For preservation of scanned collections,
DjVu offers strong compression, though migrating to or also retaining a
standardized form such as PDF/A is a common risk-reduction strategy; keep any OCR
text layer with the images.

### Security Notes

As a structured binary format with multiple embedded compressed streams, a DjVu
decoder should validate chunk sizes and image dimensions from untrusted files
before allocating buffers, to avoid out-of-bounds reads or excessive memory use.

### Further Reading

- DjVuLibre project: `https://djvu.sourceforge.net/`
