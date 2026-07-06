---
overview: ".crw files are the original Canon Raw format: an early camera raw format based on the Canon CIFF container, used by Canon's first digital SLRs and PowerShot models before the later CR2 and CR3 formats."
extensions:
  - name: "Canon Raw (CRW) format"
    description: "Canon's original camera raw image format, based on the CIFF container"
    categories:
    - 2d-graphics
    author: "Canon Inc."
    link: "https://exiftool.org/canon_raw.html"
---

## Canon Raw (CRW)

CRW is Canon's original digital camera raw format, used by early EOS digital
SLRs (such as the D30, D60, and 10D) and various PowerShot cameras. Like later
Canon raw formats it stores minimally processed sensor data plus capture
metadata, allowing white balance, exposure, and color to be decided during raw
development rather than at capture time.

Where the later CR2 is based on TIFF and CR3 on the ISO Base Media File Format,
CRW uses Canon's own Camera Image File Format (CIFF). CIFF organizes the file as
a hierarchy of typed records within a heap, holding the raw image data, a
thumbnail or preview, and camera settings and shooting information. CRW predates
the widespread EXIF-in-raw convention, so metadata lives in these CIFF records
rather than a standard EXIF block.

### Legacy Status And Tooling

CRW was superseded by CR2 and then CR3, so it is primarily encountered as a
legacy format from older Canon equipment. Because CIFF was documented and
further reverse-engineered, tools such as ExifTool, dcraw, and LibRaw can read
CRW files, extract their metadata, and decode the raw image. As with any raw
format, the developed appearance depends on the converter's demosaicing and
color handling.

### Preservation Notes

Being an obsolete, camera-specific raw format, CRW is a candidate for migration
risk. For preservation keep the original `.crw`, record the camera model, and
consider producing a documented derivative such as DNG or a rendered TIFF while
retaining the CIFF metadata (white balance, exposure, and lens information)
that is needed to reprocess the image.

### Security Notes

A CRW parser reads nested CIFF records with offsets and lengths that, in an
untrusted file, may be malformed. Validate record boundaries, heap offsets, and
image dimensions before allocating buffers or decoding to avoid out-of-bounds
access and excessive memory use.

### Further Reading

- Canon CRW / CIFF format notes: `https://exiftool.org/canon_raw.html`
- LibRaw (raw decoding library): `https://www.libraw.org/`
