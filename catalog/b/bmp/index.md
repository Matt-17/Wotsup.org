---
overview: ".bmp is primarily used for Windows and OS/2 bitmap images: simple raster files built around DIB headers, optional palettes, and mostly uncompressed pixel data."
extensions:
  - name: "Windows Bitmap (BMP/DIB)"
    description: "Raster bitmap image format using a BMP file header plus a device-independent bitmap header"
    categories:
    - windows
    - 2d-graphics
    file: bmp.zip

  - name: "OS/2 Bitmap format"
    description: "OS/2 Bitmap format"
    categories:
    - 2d-graphics
    link: "http://www.edm2.com/0107/os2bmp.html"

  - name: "The .bmp file format"
    description: "Historical BMP file format reference"
    categories:
    - windows
    - 2d-graphics
    author: "Stefan Hetzl"
    link: "http://www.fortunecity.com/skyscraper/windows/364/bmpffrmt.html"
    deprecated: true

  - name: "Windows Bitmap-File Addendum"
    description: "Windows Bitmap-File Addendum"
    categories:
    - windows
    - 2d-graphics
    author: "Kevin D. Quitt"
    file: bmpadd.zip

  - name: "Windows BMP Format"
    description: "Windows BMP Format (MS Word)"
    categories:
    - windows
    - 2d-graphics
    author: "Wim Wouters"
    file: bmpfrmat.zip
---

## Windows Bitmap (BMP/DIB)

BMP is a family of raster bitmap formats associated with Microsoft Windows and
OS/2. The common Windows file form starts with a bitmap file header, followed by
a DIB header, optional color masks or palette entries, and the pixel array. The
format is easy to parse for common files, but real-world compatibility depends
on which DIB header variant and compression mode a file uses.

### Headers And Variants

The first two bytes of a normal BMP file are `BM`. The file header records the
offset to pixel data, while the DIB header describes width, height, planes, bit
depth, compression, image size, resolution, palette usage, and sometimes color
masks or color-space metadata. Older OS/2 files use smaller core headers;
Windows files commonly use `BITMAPINFOHEADER` or later extended headers.

### Pixel Layout

Classic BMP scan lines are padded to a DWORD/LONG boundary. Positive heights
normally store rows bottom-up, while negative heights indicate top-down storage.
Indexed color files use a palette. Truecolor Windows BMP files commonly store
24-bit pixels as BGR byte triples. For 16-bit and 32-bit images, channel
interpretation may be implied by the compression mode or defined explicitly with
`BI_BITFIELDS` masks.

### Compression And Preservation Notes

Many BMP files use `BI_RGB`, meaning uncompressed pixel data. Other modes
include run-length encoding for 4-bit and 8-bit images and bitfield masks. Newer
variants can use JPEG or PNG payload identifiers, but these are not widely
interoperable as ordinary standalone BMP files. Preservation checks should
record header type, dimensions, bit depth, compression mode, palette length, row
stride, and whether alpha data is meaningful for the target reader.

### Security Notes

BMP parsers should validate dimensions, row-stride arithmetic, palette sizes,
pixel offsets, and compressed stream bounds. Large dimensions or crafted header
values can trigger integer overflow, excessive allocation, or out-of-bounds
reads in naive decoders.
