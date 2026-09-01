---
overview: ".heif files are High Efficiency Image File Format (HEIF) images: an MPEG container for still images and image sequences, standardized as ISO/IEC 23008-12 and often seen with the extensions .heif, .heic, and .avif."
extensions:
  - name: "High Efficiency Image File Format (HEIF)"
    description: "ISO base media file format container for still images, image sequences, and related metadata"
    categories:
    - 2d-graphics
    author: "MPEG / ISO/IEC"
    link: "https://nokiatech.github.io/heif/"
---

## HEIF

HEIF is a container format for storing individual images and image sequences
together with their metadata. It is defined in ISO/IEC 23008-12 (MPEG-H Part 12)
by the Moving Picture Experts Group. HEIF itself is not a compression method:
it describes how coded images are stored, and the codec is chosen by the
file's brand and item types. HEVC is the best known choice (see `.heic`), and
other codecs such as AV1 (`.avif`) can be carried as well.

### Structure

HEIF builds on the ISO base media file format (ISO/IEC 14496-12), the same box
structure used by MP4. A file starts with an `ftyp` box whose major brand
tells readers what to expect, for example `heic`, `heix`, `mif1`, or `msf1`.
Images are stored as items described in a `meta` box. The format supports
multiple images per file, thumbnails, auxiliary images such as alpha or depth
maps, derived images (for example a grid of tiles forming one large picture),
image sequences, and Exif and XMP metadata.

### Adoption

Apple adopted HEIF with HEVC coding as the default photo format starting with
iOS 11 and macOS High Sierra, and many Android devices and cameras also
write it. Support in browsers and operating systems varies, partly because
HEVC is covered by patent licensing. The media type is `image/heif`, with
`image/heic` for the HEVC variant.

### Preservation And Security Notes

Because HEIF is a container, preservation records should note which codec,
brand, and optional features (derived images, sequences, auxiliary images)
are used, as readers may support only a subset. Parsers should validate box
sizes, item references, and image dimensions, since the nested box structure
has been a source of memory-safety bugs in decoders. Nokia published an open
source implementation of the format.

### Further Reading

- Nokia HEIF information and reference implementation: `https://nokiatech.github.io/heif/`
- Nokia HEIF source code: `https://github.com/nokiatech/heif`
- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000525.shtml`
