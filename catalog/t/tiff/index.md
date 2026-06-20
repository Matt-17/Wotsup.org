---
overview: ".tiff and .tif are primarily used for Tagged Image File Format raster images: flexible tag-based files for scanning, publishing, document imaging, GIS, scientific imaging, and preservation."
extensions:
  - name: "Tagged Image File Format (TIFF), Revision 6.0"
    description: "Tag-based raster image format for interchange and storage; Revision 6.0 final specification, June 3, 1992"
    categories:
    - 2d-graphics
    author: "Aldus Corporation"
    file: tiff6.zip

  - name: "TIFF 5.0 Specification"
    description: "Historical TIFF 5.0 specification"
    categories:
    - 2d-graphics
    author: "Aldus / Microsoft"
    file: tiff.zip
    deprecated: true

  - name: "OGC GeoTIFF Standard 1.1"
    description: "Current OGC implementation standard for encoding georeferencing and coordinate-reference metadata in TIFF"
    categories:
    - gis-formats
    - 2d-graphics
    author: "Open Geospatial Consortium"
    link: "https://docs.ogc.org/is/19-008r4/19-008r4.html"

  - name: "GeoTIFF Format Specification 1.0 (historical)"
    description: "Historical community GeoTIFF 1.0 specification, specification version 1.8.2"
    categories:
    - gis-formats
    - 2d-graphics
    author: "Niles Ritter, Mike Ruth, and the GeoTIFF Working Group"
    link: "http://geotiff.maptools.org/spec/geotiffhome.html"
    deprecated: true

  - name: "TIFF-F / TIFF Class F"
    description: "Historical facsimile-oriented F Profile for TIFF, historically known as TIFF Class F"
    categories:
    - 2d-graphics
    file: tiff_f.zip
    deprecated: true
---

## Tagged Image File Format (TIFF)

TIFF is a tag-based raster image format designed for storing and exchanging
images from scanners, publishing systems, document imaging workflows, scientific
instruments, and geospatial tools. The common extensions are `.tif` and `.tiff`.
The acronym is commonly expanded as Tagged Image File Format, though older
references also use Tag Image File Format. Unlike simpler bitmap formats, TIFF
is a flexible container: two TIFF files can both be valid while using different
color models, compression methods, metadata tags, tiling schemes, page
structures, or application-specific private tags.

That flexibility is the main strength of TIFF and also its main compatibility
risk. A "TIFF reader" may support baseline bilevel, grayscale, palette, and RGB
images, but fail on tiled images, uncommon compression methods, CMYK data,
floating-point samples, very large files, private tags, or specialized profiles
such as GeoTIFF, TIFF/EP, DNG, or TIFF-FX.

### File Structure

A classic TIFF file starts with an 8-byte header. The first two bytes declare
byte order: `II` for little-endian Intel order or `MM` for big-endian Motorola
order. The next two-byte field contains the TIFF version number, normally `42`,
followed by a four-byte offset to the first image file directory, usually called
an IFD.

Each IFD is a table of tagged fields. A field records a tag number, value type,
value count, and either the value itself or an offset to the value. Important
tags describe image width, image length, bit depth, samples per pixel,
photometric interpretation, compression, resolution, strip or tile offsets, and
strip or tile byte counts. IFDs can link to later IFDs, which is how TIFF stores
multi-page documents, reduced-resolution images, thumbnails, or image pyramids.

Classic TIFF uses 32-bit offsets, so very large images can run into the 4 GB
addressing limit. BigTIFF is a related variant that changes the version value
from `42` to `43` and uses 64-bit offsets. It is useful for large scientific,
geospatial, and whole-slide imaging files, and is widely implemented, but it is
not supported by every TIFF implementation.

### Baseline, Extensions, And Compression

TIFF 6.0 separates the broadly interoperable baseline from optional extensions.
Baseline TIFF support covers common bilevel, grayscale, palette-color, and RGB
images. For compression, baseline bilevel images may use no compression, CCITT
Group 3 1D Modified Huffman, or PackBits; baseline grayscale, palette-color,
and RGB images are limited to no compression or PackBits. LZW compression,
tiled storage, CMYK, YCbCr, CIE L*a*b*, associated alpha, floating-point or
signed sample formats, JPEG compression, and several other features belong to
extended TIFF rather than the baseline set.

JPEG-in-TIFF also needs version-specific care. The original TIFF 6.0 JPEG
compression design was later corrected by Adobe Photoshop TIFF Technical Notes,
also known as TIFF Specification Supplement 2, so older JPEG-in-TIFF files and
tools may not agree on the same interpretation.

Interchange problems usually come from assuming that the `.tif` extension
identifies a single encoding. For preservation or conversion, record the
compression tag, photometric interpretation, bit depth, sample format, planar
configuration, tiling or strip layout, color metadata, and any private tags that
the creating software depends on.

### GeoTIFF And Related Profiles

GeoTIFF stores georeferencing and coordinate-reference metadata inside TIFF
using TIFF tags, GeoTIFF-specific tag sets such as `GeoKeyDirectoryTag`, and
GeoKeys. Those tags and keys can describe raster-to-model transforms,
coordinate reference systems, projection parameters, datums, units, and
vertical coordinate information. The OGC GeoTIFF 1.1 standard formalizes the
modern requirements for these fields while preserving compatibility with the
older GeoTIFF 1.0 ecosystem where possible.

Other TIFF-related profiles matter in specific domains. TIFF/EP and DNG are
important in digital photography and raw-image workflows. TIFF-F, historically
known as TIFF Class F, and TIFF-FX appear in facsimile and document-imaging
contexts. Exif metadata also uses TIFF-style IFD structures inside JPEG APP1
segments, even when the outer file is not a TIFF.

### Preservation And Security Notes

TIFF preservation should keep the original file when possible and validate more
than the header. Useful checks include byte order, IFD offsets, IFD chain
termination, tag types and counts, strip or tile byte ranges, compression
support, image dimensions, color interpretation, metadata dependencies, and
whether private tags are required to reproduce the image correctly. Multi-page
documents should be checked page by page.

TIFF parsers need strict bounds checks. Malformed files can create IFD loops,
huge allocation requests, integer overflows in strip or tile calculations,
out-of-range offsets, decompression bombs, or decoder bugs in embedded
compression streams. Pipelines that accept arbitrary TIFF files should decode in
a constrained process and reject unsupported compression or private structures
explicitly.

### Further Reading

- TIFF 6.0 specification: `https://www.itu.int/itudoc/itu-t/com16/tiff-fx/docs/tiff6.pdf`
- Library of Congress format description for TIFF 6.0: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000022.shtml`
- OGC GeoTIFF 1.1 standard: `https://docs.ogc.org/is/19-008r4/19-008r4.html`
