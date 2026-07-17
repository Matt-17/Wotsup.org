---
overview: ".xpm files are X PixMap images: a color image format written as C source code, mapping printable characters to colors, used for icons in the X Window System."
extensions:
  - name: "X PIxMap Format definition (Acrobat)"
    description: "X PIxMap Format definition (Acrobat)"
    categories:
    - 2d-graphics
    author: "Arnaud le Hors"
    file: xpm.zip
---

## X PixMap (XPM)

XPM extends the idea of the monochrome XBM to color. Like XBM, an XPM file is
valid C source code — an array of strings — so it can be compiled straight into an
X Window System program or read as an image. It was the common way to store the
color icons and pixmaps used by X applications and window managers.

An XPM image begins with a values line giving the width, height, the number of
colors, and how many characters represent each pixel. A color table then maps each
character (or character group) to a color, which can be specified per visual type
(mono, grayscale, or full color) and may include the keyword `None` to mark
transparent pixels. The image body is a grid of those characters, one string per
row, so a small XPM is even readable as rough ASCII art. This built-in
transparency made XPM especially useful for non-rectangular icons.

### Status And Preservation Notes

XPM is a legacy format tied to the X ecosystem, now largely superseded by PNG for
new work, but still recognized by many toolkits and image libraries. It is
lossless and text-based, preserving its image and transparency data faithfully.
The common media type is `image/x-xpixmap`.

### Security Notes

Because an XPM is C source, never compile or `#include` one from an untrusted
source; parse it as data with a reader that validates the color count and pixel
dimensions against the actual content to avoid mismatched-length errors.

### Further Reading

- X PixMap format overview: `https://en.wikipedia.org/wiki/X_PixMap`
