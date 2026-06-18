---
overview: ".jpg and .jpeg are primarily used for JPEG compressed photographic images, usually stored as JFIF or Exif-style interchange files."
extensions:
  - name: "JPEG File Interchange Format (JFIF)"
    description: "Common JPEG interchange file structure for compressed still images"
    categories:
    - 2d-graphics
    author: "Eric Hamilton / C-Cube Microsystems"
    file: jfif.zip

  - name: "JPEG Compression Standard"
    description: "Explanatory article on JPEG compression"
    categories:
    - 2d-graphics
    author: "Gregory K. Wallace"
    file: jpeg_c.zip

  - name: "JPEG Standard: ITU-T T.81 / ISO/IEC 10918-1"
    description: "Core JPEG still-image compression standard (PostScript version)"
    categories:
    - 2d-graphics
    author: "ITU-T / ISO/IEC"
    file: itu-1150.zip

  - name: "JPEG Standard: ITU-T T.81 / ISO/IEC 10918-1"
    description: "Core JPEG still-image compression standard (PDF version)"
    categories:
    - 2d-graphics
    author: "ITU-T / ISO/IEC"
    file: itu-1150PDF.zip

  - name: "JPEG Compression and the JPEG File Format & Sourcecode"
    description: "JPEG Compression and the JPEG file format & sourcecode"
    categories:
    - 2d-graphics
    author: "Cristian Cuturicu"
    file: jpeg.zip

  - name: "JPEG FAQ"
    description: "JPEG FAQ"
    categories:
    - 2d-graphics
    link: "http://www.faqs.org/faqs/jpeg-faq/"
---

## JPEG File Interchange Format (JFIF)

JPEG is a still-image compression family standardized mainly for
continuous-tone photographic images. The `.jpg` and `.jpeg` files most users
encounter are usually lossy baseline or progressive DCT JPEG streams wrapped
with JFIF, Exif, or related application metadata conventions. The wider JPEG 1
family also includes other coding modes, so a parser should not assume every
JPEG-related stream is only baseline DCT.

### Markers And Segments

A JPEG interchange stream begins with the Start of Image marker `FF D8` and
ends with `FF D9`. Between them are marker segments for metadata, quantization
tables, Huffman tables, frame headers, scan headers, restart markers, and
compressed entropy-coded data. JFIF commonly appears in an `APP0` segment, while
Exif metadata commonly appears in an `APP1` segment.

### Compression Model

Baseline JPEG commonly represents image data as luminance/chrominance
components, often with chroma subsampling, then splits samples into 8x8 blocks,
applies the discrete cosine transform, quantizes coefficients, and
entropy-codes the result. Other component arrangements and JPEG modes exist, so
color-space assumptions should be recorded separately. Progressive JPEG stores
data across multiple scans so the image refines as more data is read.

### Compatibility And Preservation Notes

JPEG works well for photographs but is usually a poor archival choice for sharp
line art, screenshots, and text-heavy images. Preservation metadata should
record dimensions, color space assumptions, sampling factors, progressive vs.
baseline coding, embedded ICC profiles, Exif metadata, thumbnails, and whether
the file has been recompressed from another lossy source.

### Security Notes

JPEG decoders should validate segment lengths, marker ordering, restart
intervals, table definitions, scan counts, dimensions, and allocation sizes.
Metadata parsers need separate care because Exif, XMP, ICC profiles, and
thumbnails often contain nested structures unrelated to the core JPEG decoder.
