---
overview: ".xcf files are GIMP image files: the native layered format of the GNU Image Manipulation Program, storing layers, channels, paths, and selections."
extensions:
  - name: "GIMP XCF image format"
    description: "Native layered image format of GIMP"
    categories:
    - 2d-graphics
    author: "GIMP Development Team"
    link: "https://developer.gimp.org/core/standards/xcf/"
---

## XCF

XCF is the native file format of GIMP, the GNU Image Manipulation Program. The
name comes from the Experimental Computing Facility at the University of
California, Berkeley, where GIMP was created. Unlike flat formats such as PNG
or JPEG, an XCF file preserves the editable state of an image, including
layers with their blend modes and opacity, layer masks, channels, paths,
guides, and selections.

### Technical Structure

An XCF file starts with the signature `gimp xcf ` followed by a version string
(`file` for the earliest version, or `v001`, `v002`, and so on for later
ones) and a null byte. The header continues with image dimensions, base
color mode (RGB, grayscale, or indexed), and a list of properties, then
offsets to layers and channels. Multi-byte values are stored in big-endian
order. Pixel data is stored in tiles that can be run-length encoded or zlib
compressed, depending on the version. Later versions changed offset sizes
and added support for higher precision, so files written by recent GIMP
versions may not open in older ones.

### Adoption And Tooling

GIMP reads and writes XCF, and some other programs can import it, including
Krita and ImageMagick (which flattens the layers). The format is documented
in the GIMP project's specification, which makes it more accessible than many
layered formats. Files can be compressed with gzip or bzip2 (`.xcf.gz`,
`.xcf.bz2`), which GIMP also reads.

### Preservation Notes

XCF is suited to storing editable working files, while flattened formats
should be exported for distribution. Record the GIMP version used, as
version differences can prevent opening files in older software. Text layers
and some effects may depend on installed fonts or filters.

### Further Reading

- GIMP XCF specification: `https://developer.gimp.org/core/standards/xcf/`
