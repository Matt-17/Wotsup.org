---
overview: ".xbm files are X BitMap images: a monochrome bitmap format expressed as C source code, historically used for icons and cursors in the X Window System."
extensions:
  - name: "X BitMap Format"
    description: "X BitMap Format"
    categories:
    - 2d-graphics
    file: xbm.zip
---

## X BitMap (XBM)

XBM is a monochrome (1-bit) image format from the X Window System with an unusual
property: an XBM file is literally a fragment of C source code. The image is
expressed as `#define` statements giving the width and height and a `static`
array of bytes holding the pixel bits, so the same file can be compiled directly
into a program or parsed as image data. This made it the natural way to embed
small bitmaps — icons, cursors, and stipple patterns — into X applications.

Because each pixel is a single bit, XBM stores only two "colors" (set and unset),
with the actual foreground and background chosen at display time. The format is
plain text and trivially portable, which is why it long outlived its original
niche and is still recognized by many image tools and web browsers.

### Status And Preservation Notes

XBM is a legacy format, useful mainly for tiny monochrome graphics and of
historical interest as a self-describing, source-code image. It is lossless and
human-readable, so it preserves its (limited) image data perfectly; the related
XPM format extends the same idea to color. The common media type is `image/x-xbitmap`.

### Security Notes

Since an XBM is C source, it should never be `#include`d or compiled from an
untrusted source; treat it strictly as data and parse it with a dedicated reader
that validates the declared dimensions against the array length.

### Further Reading

- X BitMap format overview: `https://en.wikipedia.org/wiki/X_BitMap`
