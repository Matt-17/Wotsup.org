---
overview: ".cr3 files are Canon Raw version 3 images: Canon's current camera raw format, built on the ISO Base Media File Format container and holding minimally processed sensor data plus metadata and preview images."
extensions:
  - name: "Canon Raw v3 (CR3) format"
    description: "Canon's third-generation camera raw image format, based on the ISO Base Media File Format"
    categories:
    - 2d-graphics
    author: "Canon Inc."
    link: "https://github.com/lclevy/canon_cr3"
---

## Canon Raw v3 (CR3)

CR3 is the raw image format used by Canon's newer cameras, introduced with the
EOS M50 and now standard across many EOS models. Like other camera raw formats,
a `.cr3` stores the largely unprocessed data read from the image sensor along
with the metadata needed to interpret and develop it, rather than a finished
RGB picture. This gives photographers latitude to set white balance, exposure,
and tone during raw conversion instead of baking those decisions in at capture.

Unlike the earlier CR2 (which was TIFF-based), CR3 is built on the ISO Base
Media File Format — the same box/atom container family used by MP4 and HEIF.
The file is a tree of typed boxes holding Canon-specific structures: the raw
image data (often using Canon's compressed CRAW variant), full-size and
thumbnail preview JPEGs, capture metadata, and CTMD timed metadata. Because the
container is documented but Canon's internal raw encoding is proprietary,
support outside Canon software has historically depended on reverse-engineering.

### Working With CR3

Raw developers and libraries (for example LibRaw and, through it, many editors)
read CR3 to extract the sensor data and camera metadata. Embedded preview JPEGs
let file browsers show an image quickly without a full raw decode. As with all
raw formats, the rendered result depends on the converter's demosaicing, color
profile, and default tone curve, so the same `.cr3` can look different across
applications.

### Preservation Notes

CR3 is a proprietary format tied to specific camera models, which is a known
risk for long-term access. For archiving, keep the original `.cr3` untouched and
consider generating a documented derivative such as DNG or a rendered TIFF/JPEG,
while recording the camera model and firmware. Preserve the embedded EXIF and
maker-note metadata, since it carries lens, exposure, and color information
needed to reprocess the image faithfully.

### Security Notes

As a box-structured binary format carrying compressed image data and multiple
embedded streams, a CR3 parser should validate box sizes and offsets, embedded
preview lengths, and image dimensions from untrusted files before allocating or
decoding, to avoid out-of-bounds reads and excessive allocation.

### Further Reading

- Reverse-engineered CR3 format notes: `https://github.com/lclevy/canon_cr3`
- LibRaw (raw decoding library): `https://www.libraw.org/`
