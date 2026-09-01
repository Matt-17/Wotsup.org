---
overview: ".jp2 files are JPEG 2000 images: a wavelet-based image format (ISO/IEC 15444) used in digital cinema, medical imaging, and archives; related extensions include .j2k, .j2c, .jpf, and .jpx."
extensions:
  - name: "JPEG 2000 Part 1 (JP2)"
    description: "Wavelet-based image compression system and the JP2 file format, ISO/IEC 15444-1"
    categories:
    - 2d-graphics
    author: "Joint Photographic Experts Group (ISO/IEC / ITU-T T.800)"
    link: "https://jpeg.org/jpeg2000/"
---

## JPEG 2000

JPEG 2000 is an image compression standard from the JPEG committee, published as
ISO/IEC 15444 and ITU-T T.800. Instead of the 8x8 block DCT used by JPEG, it
applies a discrete wavelet transform and codes the result with embedded block
coding, which gives it features JPEG lacks: lossless and lossy compression in
one codestream, resolution and quality scalability, region-of-interest
decoding, high bit depths, and no visible blocking artifacts at high
compression.

### File Formats

The `.jp2` format, defined in Part 1, wraps a codestream in a box-based file
structure. A JP2 file begins with the signature box
`00 00 00 0C 6A 50 20 20 0D 0A 87 0A` followed by an `ftyp` box, a header
box with image properties and color specification, and a `jp2c` box holding
the codestream. A raw codestream, often with the extension `.j2k` or
`.j2c`, starts with the markers `FF 4F FF 51`. Part 2 extensions use `.jpx`
(or `.jpf`), and Motion JPEG 2000 uses `.mj2`.

### Adoption

JPEG 2000 is used in digital cinema packages, medical imaging (DICOM),
satellite and geospatial imagery, and by libraries and archives as a
preservation and access format for digitized material. It is also an image
compression option in PDF. Browser support is limited, so it is rarely used
for general web images. Common implementations include the open source
OpenJPEG library and the commercial Kakadu toolkit.

### Preservation And Security Notes

Record whether a file uses reversible (lossless) or irreversible
(lossy) wavelet filters, the number of decomposition levels, tiling,
and color specification. Decoders should validate box lengths, tile sizes,
and component counts, because the format is flexible and parsers have
historically had memory-safety bugs.

### Further Reading

- JPEG 2000 overview (JPEG committee): `https://jpeg.org/jpeg2000/`
- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000138.shtml`
