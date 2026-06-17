---
extensions:
  - name: "Portable Network Graphics Specification"
    description: "Portable Network Graphics Specification"
    categories:
    - 2d-graphics
    author: "Tom Boutell"
    link: "http://www.boutell.com/boutell/png/"
    deprecated: true
    
  - name: "Portable Network Graphics Specification"
    description: "Portable Network Graphics Specification"
    categories:
    - 2d-graphics
    author: "T. Boutell et al"
    file: png.zip
    deprecated: true
    
  - name: "PNG-16 File Format"
    description: "PNG-16 File Format"
    categories:
    - 2d-graphics
    author: "Rich Franzen"
    link: "http://home.att.net/~rocq/png16.html"
    deprecated: true
    
  - name: "Portable Network Graphics Information"
    description: "Portable Network Graphics Information"
    categories:
    - 2d-graphics
    author: "Various"
    link: "http://www.libpng.org/pub/png/"
    
---

## Deep Dive

PNG is a lossless raster image format designed for portable network graphics,
especially on the web. It replaced many GIF use cases by supporting better
compression, truecolor images, grayscale images, indexed-color images, and alpha
transparency without relying on patented compression. It remains important for
screenshots, diagrams, icons, transparency-heavy graphics, and preservation of
pixel-exact imagery.

## Datastream Structure

A PNG file starts with an 8-byte signature:
`89 50 4E 47 0D 0A 1A 0A`. The rest of the file is a sequence of chunks. Each
chunk stores a length, a four-byte chunk type, chunk data, and a CRC. Critical
chunks define the image itself: `IHDR` gives image dimensions and color type,
`PLTE` stores palette data when needed, `IDAT` stores compressed image data, and
`IEND` marks the end of the stream.

Ancillary chunks carry optional information such as gamma, chromaticity, ICC
profiles, text, timestamps, physical pixel dimensions, Exif metadata, and
animation control data in newer specifications. Unknown ancillary chunks can
usually be skipped by older readers, which is a major reason PNG has aged well.

## Compression And Filtering

PNG uses scanline filtering before compression. Each scanline may use a filter
that predicts pixel values from neighboring pixels, making the remaining data
more compressible. The filtered byte stream is then compressed with Deflate.
Because filtering is lossless, a decoded PNG should reproduce the original
sample values exactly, subject to color-management interpretation.

Compression level affects file size and encoding time, not image quality. If a
PNG changes visually after recompression, the tool probably changed color
metadata, bit depth, palette choices, transparency, or gamma handling rather
than the compression itself.

## Color And Transparency

PNG supports palette images, grayscale, truecolor, and optional alpha channels.
For web use, alpha transparency is one of its defining strengths. For archival
or prepress workflows, color chunks such as `sRGB`, `gAMA`, `cHRM`, and `iCCP`
matter because they influence how sample values should be displayed.

The 2025 W3C PNG Third Edition adds modernized support around areas such as
animation, Exif metadata, and HDR-related color information. Older PNG files
remain valid, but validators and preservation workflows should record which
chunks are present rather than assuming every `.png` is a simple static image.

## Preservation And Security Notes

PNG is comparatively simple, but decoders still need limits for huge dimensions,
large compressed streams, malformed chunk lengths, CRC failures, and excessive
ancillary data. Preservation checks should verify the signature, chunk ordering,
CRC values, final `IEND`, dimensions, color type, bit depth, and decompressible
`IDAT` stream. Keep original color metadata when converting or optimizing files.

## Further Reading

- W3C PNG Specification: `https://www.w3.org/TR/png/`
- PNG home site and libpng resources: `http://www.libpng.org/pub/png/`
- Related formats: APNG, MNG, JNG, GIF, WebP
