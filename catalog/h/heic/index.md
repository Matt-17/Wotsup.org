---
overview: ".heic files are HEIC images: HEIF files whose images are coded with HEVC (H.265) intra compression, widely produced by iPhones and other cameras as a compact photo format."
extensions:
  - name: "HEIC (HEVC-coded HEIF image)"
    description: "HEIF container holding still images compressed with HEVC (H.265)"
    categories:
    - 2d-graphics
    author: "MPEG / ISO/IEC"
    link: "https://nokiatech.github.io/heif/"
---

## HEIC

HEIC is the common name for HEIF files that store their images with the High
Efficiency Video Coding (HEVC, H.265) codec. The container is defined by
ISO/IEC 23008-12 and the HEVC coding by ITU-T H.265 / ISO/IEC 23008-2. The
extension `.heic` distinguishes these files from other HEIF files, such as
`.avif`, that use a different codec. The extensions `.heif` and `.heics`
(image sequences) are also in use.

### Structure

A HEIC file is an ISO base media file format container: it begins with an
`ftyp` box whose major brand is `heic` (or a related brand such as `heix`),
followed by a `meta` box that describes image items and, usually, an `mdat`
box with the coded data. Each image is an HEVC intra-coded picture, and a
large photo is typically split into a grid of tiles that are combined by a
derived image item. A single file may also contain a thumbnail, an alpha or
depth auxiliary image, Exif and XMP metadata, and an ICC profile.

### Adoption

Apple made HEIC the default capture format in iOS 11 (2017), and the format
is also written by many recent Android phones and cameras. It is typically
smaller than a JPEG of similar visual quality. Because HEVC is subject to
patent licensing, support in web browsers and some operating systems is
limited or requires extensions, and photos are often converted to JPEG when
shared. Common tools for reading and writing HEIC include libheif and
ImageMagick (when built with libheif). The media type is `image/heic`.

### Preservation And Security Notes

HEIC is lossy in normal use, so keep original files rather than repeatedly
converting. When converting, check that Exif data, color profiles, and depth
maps are preserved or deliberately dropped. Decoders should validate box
sizes, tile grids, and dimensions, as malformed HEIF files have caused
memory-safety problems in image libraries.

### Further Reading

- Nokia HEIF information: `https://nokiatech.github.io/heif/`
- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000525.shtml`
