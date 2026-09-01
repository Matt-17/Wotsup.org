---
overview: ".jxl files are JPEG XL images: a royalty-free image format standardized as ISO/IEC 18181 that supports lossy and lossless compression, HDR, animation, and lossless recompression of existing JPEG files."
extensions:
  - name: "JPEG XL image format"
    description: "Modern image format with lossy and lossless modes, wide gamut/HDR, animation, and JPEG recompression"
    categories:
    - 2d-graphics
    author: "Joint Photographic Experts Group (ISO/IEC JTC 1/SC 29/WG 1)"
    link: "https://jpeg.org/jpegxl/"
---

## JPEG XL

JPEG XL is an image format developed by the JPEG committee as a general
purpose successor to JPEG. It is specified in ISO/IEC 18181 and was designed to
cover photographic and synthetic images, high bit depths, wide color gamuts
and HDR, alpha, layers, and animation in a single format. Its reference
implementation, libjxl, is open source and the format is intended to be
royalty-free.

### Technical Structure

JPEG XL has two coding modes. VarDCT is a lossy mode based on variable-size
discrete cosine transforms, and Modular is a mode used for lossless coding
and for images with sharp edges or limited palettes. A distinctive feature is
reversible transcoding of existing JPEG files: the JPEG data is recompressed
into JXL and can be restored bit-exactly, typically at a smaller size.

A file is either a bare codestream starting with the bytes `FF 0A`, or an
ISO base media style container starting with the 12-byte signature
`00 00 00 0C 4A 58 4C 20 0D 0A 87 0A` (a "JXL " box). The container can
carry Exif, XMP, and the JPEG reconstruction data next to the codestream.
The media type is `image/jxl`.

### Adoption

Support has grown across image libraries and tools such as libjxl,
ImageMagick, and GIMP, and several operating systems and browsers have
added or experimented with decoders. Browser support has changed over time,
so check current compatibility before using JXL for web delivery.

### Preservation Notes

JXL can store images losslessly, and JPEG recompression allows smaller storage
without loss for existing JPEG archives. Record the coding mode (VarDCT or
Modular), bit depth, color encoding, and whether the file is a recompressed
JPEG. Decoders should limit image dimensions and memory use when handling
untrusted files.

### Further Reading

- JPEG XL overview (JPEG committee): `https://jpeg.org/jpegxl/`
- libjxl reference implementation: `https://github.com/libjxl/libjxl`
