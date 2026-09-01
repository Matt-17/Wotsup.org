---
overview: ".dng files are Digital Negative (DNG) images: an open, TIFF-based raw image format from Adobe intended as a common alternative to proprietary camera raw formats."
extensions:
  - name: "Digital Negative (DNG)"
    description: "TIFF/EP-based raw image format with standardized metadata for camera sensor data"
    categories:
    - 2d-graphics
    author: "Adobe"
    link: "https://www.loc.gov/preservation/digital/formats/fdd/fdd000188.shtml"
---

## DNG

Digital Negative (DNG) is a raw image file format introduced by Adobe in
2004. Camera manufacturers each use their own raw formats, such as CR2, NEF,
or ARW, which often lack public documentation. DNG was created as a publicly
documented format that can hold raw sensor data from many cameras along with
the information needed to interpret it. Adobe publishes the specification
and allows implementation without license fees.

### Technical Structure

DNG is based on the TIFF 6.0 and TIFF/EP structures. A file starts with a
TIFF header (`II*\0` for little-endian or `MM\0*` for big-endian), and its
image file directories use standard TIFF tags plus DNG-specific tags, such as
`DNGVersion`. The raw data is usually a CFA (Bayer-style) mosaic, though the
format also supports "linear" DNG with demosaiced data. DNG tags describe
color matrices, black and white levels, white balance, camera calibration,
and optional opcodes for lens corrections. A DNG file can also contain
embedded previews, Exif and XMP metadata, and optionally the original
proprietary raw file. Raw data may be uncompressed, losslessly compressed,
or lossy compressed.

### Adoption

DNG is the native format of some cameras and of many smartphone apps, and
Lightroom and Photoshop can convert other raw formats to DNG. Open tools such
as LibRaw-based applications and darktable can read it. The specification has
been revised several times, so older software may not read files that use
newer features.

### Preservation Notes

DNG is often chosen for archiving because its documentation is public and
it avoids dependence on camera-specific formats. Conversion can discard
manufacturer-specific metadata unless the original raw file is embedded,
so record what conversion tool and DNG version were used. Because DNG is
TIFF-based, parsers should check IFD offsets and tag counts.

### Further Reading

- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000188.shtml`
