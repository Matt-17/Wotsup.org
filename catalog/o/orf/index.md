---
overview: ".orf files are Olympus RAW Format images: proprietary camera raw files written by Olympus and OM System digital cameras, using a TIFF-like structure."
extensions:
  - name: "Olympus RAW Format (ORF)"
    description: "Olympus and OM System TIFF-like raw image format"
    categories:
    - 2d-graphics
    author: "Olympus"
    link: "https://libopenraw.freedesktop.org/formats/orf/"
---

## ORF

ORF is the raw file format of Olympus digital cameras, including the E-series
DSLRs and the Micro Four Thirds OM-D and PEN lines. OM Digital Solutions,
which took over Olympus's camera business, continues to use it in OM System
cameras. A raw file keeps unprocessed sensor data so that exposure, white
balance, and color can be adjusted later.

### Technical Structure

ORF is built on the TIFF structure but with a modified header. Instead of
the standard TIFF magic number, ORF files commonly begin with `IIRO` (or
`IIRS` on some models) followed by an offset to the first image file
directory, so general TIFF readers may reject them. The file contains Exif
data, Olympus maker notes, a JPEG preview, thumbnails, and the raw image
data, whose compression is Olympus specific and varies between camera
models.

### Specification And Tooling

Olympus has not published a complete specification, so support depends on
reverse-engineered information found in projects such as libopenraw and
ExifTool's Olympus tag tables. Raw converters such as Adobe Camera Raw,
darktable, and RawTherapee, and libraries like LibRaw, can read ORF. New
cameras generally need updated software to decode their files.

### Preservation Notes

For long-term storage, keep the original ORF and consider a documented
derivative such as DNG or a lossless TIFF. Note the camera model and
firmware, since decoding depends on model-specific details. Parsers should
not assume a standard TIFF header when identifying ORF files.

### Further Reading

- libopenraw ORF notes: `https://libopenraw.freedesktop.org/formats/orf/`
- ExifTool Olympus tags: `https://exiftool.org/TagNames/Olympus.html`
