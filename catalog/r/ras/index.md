---
overview: ".ras files are Sun Rasterfile images: the native raster format of Sun workstations, storing palettized or RGB images with an optional simple run-length compression."
extensions:
  - name: "Sun Rasterfile Format"
    description: "Sun Rasterfile Format"
    categories:
    - 2d-graphics
    link: "http://www.mediatel.lu/workshop/graphic/2D_fileformat/h_sun.html"
    deprecated: true

  - name: "Sun Rasterfile Format"
    description: "Sun Rasterfile Format"
    categories:
    - 2d-graphics
    link: "http://www.research.microsoft.com/~hollasch/cgnotes/formats/sunraster.html"
    deprecated: true

  - name: "Sun Rasterfile Format"
    description: "Sun Rasterfile Format"
    categories:
    - 2d-graphics
    link: "http://www.ius.cs.cmu.edu/IUS/www/help/Macintosh/sunRasterFormat.html"
    deprecated: true
    
  - name: "Sun Rasterfile Format"
    description: "Sun Rasterfile Format"
    categories:
    - 2d-graphics
    file: sun.zip
    
---

## Sun Rasterfile (RAS)

The Sun Rasterfile format was the native raster image format on Sun Microsystems'
workstations and SunOS/Solaris, and it became a common interchange format in Unix
image toolchains of that era. It is a straightforward format: a fixed header
followed by an optional color map and the pixel data.

The header begins with the magic number `0x59A66A95` and records the image width,
height, depth (bits per pixel), the length of the pixel data, a type field
indicating the encoding, and the color-map type and length. Images can be 1-, 8-,
24-, or 32-bit, and the type field selects between uncompressed data and a simple
byte-oriented run-length encoding. Multibyte values are stored big-endian,
reflecting the format's origins on big-endian hardware.

### Status And Preservation Notes

Sun Rasterfile is a legacy format, encountered mainly in older Unix imagery and
supported by classic tools such as Netpbm and ImageMagick. It is lossless and
documented, so it preserves image data faithfully; migrating to PNG or TIFF while
retaining the original is a reasonable preservation step. The common media type is
`image/x-sun-raster`.

### Security Notes

As a binary format with an optional RLE mode and offset-driven color map, a reader
should validate the declared dimensions, depth, and data length from untrusted
files and bound the decoded output to guard against overflows.

### Further Reading

- Sun Rasterfile format overview: `https://www.fileformat.info/format/sunraster/egff.htm`
