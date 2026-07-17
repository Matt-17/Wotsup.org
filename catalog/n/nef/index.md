---
overview: ".nef files are Nikon Electronic Format raw images: Nikon's camera raw format, based on TIFF/EP, storing minimally processed sensor data plus extensive capture metadata and an embedded preview."
extensions:
  - name: "Nikon NEF file format"
    description: "Nikon NEF file format"
    categories:
    - 2d-graphics
    author: "Fabrizio Giudici"
    file: nef.zip
---

## Nikon Electronic Format (NEF)

NEF is the raw image format produced by Nikon digital cameras. Like other camera
raw formats it stores the largely unprocessed data read from the image sensor,
together with the metadata needed to interpret and develop it, rather than a
finished RGB picture. This preserves the full latitude of the capture, letting
white balance, exposure, and color be decided later during raw conversion instead
of being baked in by the camera.

Structurally, NEF is built on TIFF/EP, an ISO raw-image baseline derived from
TIFF, so a NEF is a TIFF-family file whose tags and image-file directories point
to the raw sensor data (which may be uncompressed or use Nikon's lossless or
lossy compression), one or more embedded JPEG previews, and rich EXIF and Nikon
MakerNote metadata describing the camera, lens, and settings. Because the raw
encoding and some MakerNote fields are proprietary, full support outside Nikon
software has historically relied on reverse-engineering.

### Preservation Notes

As a proprietary, camera-specific raw format, NEF carries long-term access risk.
For archiving, keep the original NEF untouched and consider a documented derivative
such as DNG (Adobe's openly specified raw format) or a rendered TIFF, while
recording the camera model and firmware. Preserve the EXIF and MakerNote metadata,
since it holds the lens, exposure, and color information needed to reprocess the
image faithfully; the rendered result also depends on the raw converter's
demosaicing and color handling.

### Security Notes

Because NEF is a TIFF-family container with offset-driven directories and embedded
previews, a parser handling untrusted files should validate tag offsets, strip and
preview lengths, and image dimensions before allocating or decoding to avoid
out-of-bounds reads.

### Further Reading

- TIFF/EP and camera raw background: `https://en.wikipedia.org/wiki/Raw_image_format`
- LibRaw (raw decoding library): `https://www.libraw.org/`
