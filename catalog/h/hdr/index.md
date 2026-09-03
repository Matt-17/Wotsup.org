---
overview: ".hdr files are Radiance RGBE images: a high dynamic range picture format from the Radiance lighting simulation system, also seen with the extensions .pic and .rgbe."
extensions:
  - name: "Radiance HDR (RGBE) picture format"
    description: "High dynamic range image format storing RGB with a shared exponent per pixel"
    categories:
    - 2d-graphics
    - 3d-graphics
    author: "Greg Ward / Lawrence Berkeley National Laboratory"
    link: "https://www.radiance-online.org/"
---

## Radiance HDR

The Radiance picture format was created by Greg Ward for the Radiance
lighting simulation and rendering system. It was one of the first practical
formats for high dynamic range images. Files commonly use the extension
`.hdr`, and the same format also appears as `.pic` and `.rgbe`. Other,
unrelated formats use `.hdr` as well, for example ENVI image header files.

### Technical Structure

A file begins with a text header, starting with the line `#?RADIANCE` (or
`#?RGBE`), followed by variable lines such as `FORMAT=32-bit_rle_rgbe` and
optional values like `EXPOSURE=`. A blank line ends the header, and a
resolution line such as `-Y 512 +X 1024` gives the image size and pixel
order. Pixel data follows in binary.

Each pixel takes four bytes: 8-bit red, green, and blue mantissas and one
shared 8-bit exponent (RGBE). This covers a very large range of brightness
at a small size per pixel, with limited precision. Scanlines are usually
compressed with a simple run-length encoding scheme. The format can also
store pixels as XYZE.

### Adoption

Radiance HDR is widely used for environment maps and light probes in
rendering, game engines, and 3D tools, and many sites distribute HDRI files
in this format. Libraries such as stb_image can load it, and ImageMagick and
Blender support it. OpenEXR is a more flexible alternative for production
work.

### Preservation Notes

The shared exponent means values are less precise than 16-bit float formats,
and the format has no standard metadata beyond header variables. Record the
color primaries and exposure values from the header, since they are needed
to interpret absolute levels. Parsers should check resolution lines and
run-length data against the declared size.

### Further Reading

- Radiance project: `https://www.radiance-online.org/`
- Radiance file formats (PDF): `https://radsite.lbl.gov/radiance/refer/filefmts.pdf`
