---
overview: ".cr2 files are Canon RAW version 2 images: proprietary camera raw files written by Canon EOS digital cameras, based on the TIFF structure."
extensions:
  - name: "Canon RAW 2 (CR2)"
    description: "Canon's TIFF-based raw image format for EOS cameras"
    categories:
    - 2d-graphics
    author: "Canon"
    link: "https://libopenraw.freedesktop.org/formats/cr2/"
---

## CR2

CR2 is the raw image format used by many Canon EOS DSLR and some other
Canon cameras from the mid-2000s on. It replaced the older CRW format and
was in turn succeeded by CR3 in newer Canon cameras. A raw file stores
sensor data with little processing, so photographers can adjust white
balance, exposure, and color later in software.

### Technical Structure

CR2 is built on the TIFF file structure. A file starts with a TIFF header
(`II*\0`, little-endian) followed by an offset to the first image file
directory (IFD). At byte offset 8 follows the signature `CR` and version
bytes, which distinguishes CR2 from plain TIFF. The file contains several
IFDs: a full-size JPEG preview, smaller previews and thumbnails, and an IFD
holding the raw sensor data, which is stored with lossless JPEG compression.
Camera settings and other data are stored in Exif and Canon maker note tags.

### Specification And Tooling

Canon has not published a complete specification, so support in other
software relies on reverse engineering, documented in projects such as
libopenraw and in ExifTool's Canon tag tables. Raw converters including
Canon's own tools, Adobe Camera Raw, darktable, RawTherapee, and the LibRaw
library can read CR2 files. New camera models require updated software,
because details differ between models.

### Preservation Notes

Because the format is proprietary and undocumented, long-term preservation
often involves keeping the original CR2 along with a conversion to DNG
or a rendered TIFF. Record the camera model and firmware, since
interpretation of the raw data depends on model-specific parameters.

### Further Reading

- libopenraw CR2 notes: `https://libopenraw.freedesktop.org/formats/cr2/`
- ExifTool Canon tags: `https://exiftool.org/TagNames/Canon.html`
