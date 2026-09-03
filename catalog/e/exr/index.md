---
overview: ".exr files are OpenEXR images: a high dynamic range image format created by Industrial Light & Magic that supports 16-bit half-float and 32-bit pixel data, arbitrary channels, and deep images."
extensions:
  - name: "OpenEXR image format"
    description: "HDR raster format with half/float pixels, multiple channels and layers, and several compression methods"
    categories:
    - 2d-graphics
    - video-animation
    author: "Industrial Light & Magic / Academy Software Foundation"
    link: "https://openexr.com/en/latest/"
---

## OpenEXR

OpenEXR is a high dynamic range raster image format developed at Industrial
Light & Magic (ILM) for visual effects work and released as open source in
2003. It is now maintained under the Academy Software Foundation. Its
defining feature is the 16-bit floating point "half" pixel type, which
allows a wide range of brightness values without banding, alongside 32-bit
float and 32-bit unsigned integer channels.

### Technical Structure

An OpenEXR file starts with the magic number `76 2F 31 01`, followed by a
version field that indicates features such as tiled or multi-part files. A
header of named attributes follows, then an offset table and pixel data in
scanline or tile form. Images can have any number of named channels, so
color, alpha, depth, and other render passes can be stored in a single file.
Multi-part files hold several images, and deep images store a variable
number of samples per pixel. Compression options include none, RLE, ZIP,
PIZ, PXR24, B44, and DWA, with both lossless and lossy variants.

### Adoption

OpenEXR is widely used in film, animation, and games for rendering output,
compositing, and texture data, and is supported by tools including Nuke,
Blender, and Houdini. The reference library is written in C++ and
distributed under a permissive open source license.

### Preservation And Security Notes

Record the pixel types, compression method, color space and chromaticities,
and whether the file is multi-part or deep. Since values are typically
linear light and may exceed 1.0, converting to 8-bit formats loses
information. Decoders should check dimensions, offset tables, and
compressed block sizes when reading untrusted files.

### Further Reading

- OpenEXR documentation: `https://openexr.com/en/latest/`
- OpenEXR source code: `https://github.com/AcademySoftwareFoundation/openexr`
- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000583.shtml`
