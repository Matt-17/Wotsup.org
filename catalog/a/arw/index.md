---
overview: ".arw files are Sony Alpha RAW images: proprietary camera raw files written by Sony Alpha and related cameras, based on the TIFF structure."
extensions:
  - name: "Sony Alpha RAW (ARW)"
    description: "Sony's TIFF-based raw image format for Alpha and related cameras"
    categories:
    - 2d-graphics
    author: "Sony"
    link: "https://exiftool.org/TagNames/Sony.html"
---

## ARW

ARW is the raw image format used by Sony Alpha cameras, including the
interchangeable-lens Alpha and NEX lines. It stores minimally processed data
from the image sensor so that exposure, white balance, and color can be
adjusted later in a raw converter. Sony earlier used related formats named
SRF and SR2.

### Technical Structure

ARW files follow the TIFF layout. They begin with a TIFF header (`II*\0`)
and contain image file directories with the raw image data, a JPEG preview,
and thumbnails. Exif and Sony-specific maker note tags carry camera
settings, lens information, and parameters needed to process the sensor
data. The raw data can be uncompressed or compressed with a Sony-specific
scheme, so decoding details vary between camera models and ARW versions.

### Specification And Tooling

Sony has not published a full public specification of the format. Software
support comes from reverse-engineered documentation, for example ExifTool's
Sony tag tables and the LibRaw library, which many applications use for raw
decoding. Adobe Camera Raw, Lightroom, darktable, RawTherapee, and Sony's
own software can open ARW files, and new camera models often need
updated software versions.

### Preservation Notes

As with other proprietary raw formats, an ARW file is best kept together with
a documented derivative, such as DNG or TIFF, in long-term archives. Keep the
original, since conversion may lose maker note data. Record camera model and
compression type, because both affect which software can decode the file.

### Further Reading

- ExifTool Sony tags: `https://exiftool.org/TagNames/Sony.html`
