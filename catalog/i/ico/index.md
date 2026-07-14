---
overview: ".ico files are Windows icon images: a container holding several bitmaps at different sizes and color depths so the system can pick the best image for each display context."
extensions:
  - name: "Icon resources in ICO, DLL and EXE files (Also CUR files)"
    description: "Icon resources in ICO, DLL and EXE files (Also CUR files)"
    categories:
    - windows
    author: "John Hornick"
    file: icons.zip
---

## Windows Icon (ICO)

The ICO format is Microsoft Windows' format for application and file icons. Its
defining feature is that a single `.ico` file is a container holding multiple
images of the same icon at different sizes and color depths, so the operating
system can choose the most appropriate one for a given context — a small image in
a menu, a larger one on the desktop, and higher-color versions on capable
displays.

The file begins with a directory that lists each contained image with its
dimensions, color count, and the offset and size of its data. Each entry stores
either a device-independent bitmap (a DIB, essentially a BMP without the file
header) with an AND mask for transparency, or, since Windows Vista, a full PNG
image, which is preferred for large, high-color icons because it compresses
better. The nearly identical CUR format uses the same structure for mouse cursors,
adding a hotspot for each image.

### Preservation And Security Notes

The common media type is `image/vnd.microsoft.icon` (also `image/x-icon`). For
preservation, keep the multi-resolution set intact rather than flattening to a
single image, since the alternate sizes are the point of the format. As a
container with per-image offsets and sizes and mixed DIB/PNG payloads, an ICO
parser should validate directory offsets and image dimensions from untrusted files
before decoding to avoid out-of-bounds reads.

### Further Reading

- ICO file format overview: `https://en.wikipedia.org/wiki/ICO_(file_format)`
