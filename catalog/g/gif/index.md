---
overview: ".gif is primarily used for Graphics Interchange Format images: palette-based raster graphics with LZW compression, simple transparency, and widely supported animation."
extensions:
  - name: "Graphics Interchange Format (GIF)"
    description: "Palette-based raster image format; GIF89a is the common modern baseline"
    categories:
    - 2d-graphics
    author: "CompuServe Inc."
    file: gif89a.zip

  - name: "Graphics Interchange Format 87a"
    description: "Original GIF87a specification"
    categories:
    - 2d-graphics
    author: "CompuServe Inc."
    file: gif.zip

  - name: "Graphics Interchange Format 89m"
    description: "Historical nonstandard modification of GIF89a"
    categories:
    - 2d-graphics
    file: gif89m.zip
    deprecated: true

  - name: "Information about animated GIFs"
    description: "Historical information about animated GIFs"
    categories:
    - 2d-graphics
    author: "Royal E. Frazier Jr."
    link: "http://members.aol.com/royalef/gifabout.htm"
    deprecated: true

  - name: "LZW Compression"
    description: "LZW Compression"
    categories:
    - 2d-graphics
    author: "Bob Montgomery"
    file: compress.zip

  - name: "LZW and GIF explained"
    description: "LZW and GIF explained"
    categories:
    - 2d-graphics
    author: "Steve Blackstock"
    file: lzwexp.zip
---

## Graphics Interchange Format (GIF)

GIF is a compact raster image format introduced by CompuServe. It is built for
indexed-color images and uses LZW compression. Although PNG replaced many static
GIF use cases, GIF remains important because readers broadly support simple web
graphics and short animations. Looping is normally carried by an application
extension convention rather than the base image blocks.

### File Structure

A GIF file starts with either `GIF87a` or `GIF89a`, followed by a logical screen
descriptor and an optional global color table. The rest of the stream is a
sequence of image descriptors, extension blocks, and sub-blocked data, ending
with the trailer byte `3B`. Image data is LZW-compressed and stored in length
prefixed sub-blocks.

### Color, Transparency, And Animation

GIF is limited to indexed color: each image frame references a palette of up to
256 colors. GIF89a adds extension blocks, including the Graphic Control
Extension used for frame delay, disposal behavior, and one transparent palette
index. Animation is represented as multiple images in one stream; looping is
commonly expressed with the Netscape application extension convention.

### Compatibility Notes

Interlaced GIFs store rows in passes so an image can appear progressively.
Readers should handle local color tables, global color tables, multiple frames,
zero or very small animation delays, and disposal methods consistently. For
graphics with many colors or alpha transparency, PNG, WebP, or AVIF may preserve
appearance better.

### Security Notes

GIF decoders should enforce limits on canvas size, frame count, decompressed
data size, LZW code growth, extension block lengths, and animation duration.
Malformed sub-block chains and oversized logical screens are common stress
cases for image pipelines.
