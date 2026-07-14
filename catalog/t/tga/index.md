---
overview: ".tga files are Truevision Targa images: a raster format with optional run-length compression and an alpha channel, long used in game textures, rendering, and video work."
extensions:
  - name: "Targa image file format"
    description: "Targa image file format"
    categories:
    - 2d-graphics
    author: "David McDuffee"
    file: tga.zip
    
  - name: "TGA File format specification V2.0 (Acrobat)"
    description: "TGA File format specification V2.0 (Acrobat)"
    categories:
    - 2d-graphics
    author: "Truevision Inc."
    file: tga2.zip
---

## Truevision Targa (TGA)

TGA is a raster image format introduced by Truevision for its early graphics
cards and still widely used in games, 3D rendering, and video production. It is
valued for being simple to read and write, for supporting a straightforward alpha
(transparency) channel, and for optional lossless run-length compression, which
makes it a practical intermediate format for textures and rendered frames.

A TGA file has a header describing the image type and dimensions, an optional
color map (palette), and the pixel data. It supports several pixel depths —
including 8-bit grayscale or palettized, 16-bit, 24-bit RGB, and 32-bit RGBA —
and pixels may be stored uncompressed or run-length encoded. The version 2 format
adds an extension area and a footer (ending with the signature
`TRUEVISION-XFILE.`) that carries metadata such as author, timestamp, and gamma.

### Notes And Quirks

Because the original specification left some details loosely defined, files vary in
pixel ordering (an "origin" bit controls whether rows run top-down or bottom-up)
and in how the alpha channel is interpreted, so robust readers must honor the
header flags rather than assume a layout. The common media type is `image/x-tga`.

### Preservation And Security Notes

TGA is a reasonable format for lossless interchange of RGBA imagery; recording bit
depth and alpha meaning avoids ambiguity. As a binary format with run-length
compression, a TGA decoder should validate declared dimensions and color-map sizes
from untrusted files and bound the decompressed output to avoid buffer overruns.

### Further Reading

- Truevision TGA format specification: `https://www.dca.fee.unicamp.br/~martino/disciplinas/ea978/tgaffs.pdf`
