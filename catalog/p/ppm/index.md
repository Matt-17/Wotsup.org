---
overview: ".ppm files are Portable Pixmap images: a deliberately simple RGB raster format in the Netpbm family, easy to generate and parse, used mainly as an intermediate/interchange format."
extensions:
  - name: "Portable Pixelmap format"
    description: "Portable Pixelmap format"
    categories:
    - 2d-graphics
    author: "Jef Pozkanzer"
    file: ppm.zip
    deprecated: true
---

## Portable Pixmap (PPM)

PPM is the color member of the Netpbm family of image formats, designed by Jef
Poskanzer to be about as simple as an image format can be. That simplicity is the
point: PPM is trivial to write from a few lines of code and trivial to parse,
which makes it a favorite as an intermediate or interchange format between image
tools and in teaching and quick experiments, rather than a format for final
distribution.

A PPM file has a tiny header — a magic number (`P3` for ASCII, `P6` for binary),
the width and height, and the maximum color value — followed by RGB triples for
each pixel. Its siblings share the same structure: PBM (`P1`/`P4`) stores 1-bit
bitmaps and PGM (`P2`/`P5`) stores grayscale, while PNM/PAM are umbrella forms.
Because the format carries no compression, files are large but exactly
reproducible.

### Preservation And Security Notes

PPM is lossless and openly documented, so it preserves pixel data perfectly, but
its lack of compression and metadata makes it better as a working format than an
archival one; converting to PNG for storage while keeping the pipeline in PPM is
common. Even for such a simple format, a reader should validate the width, height,
and maximum value from untrusted files and check that the pixel data length
matches, since a malformed header can drive over- or under-reads.

### Further Reading

- Netpbm PPM format definition: `https://netpbm.sourceforge.net/doc/ppm.html`
