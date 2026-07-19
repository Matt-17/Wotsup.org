---
overview: ".avif files are AV1 Image File Format images: still and animated images that store AV1-coded picture data in the ISO/HEIF container, offering very high compression with wide color, HDR, and transparency."
extensions:
  - name: "AV1 Image File Format (AVIF)"
    description: "HEIF-based still/animated image format using AV1 intra-frame coding"
    categories:
    - 2d-graphics
    - internet
    author: "Alliance for Open Media"
    link: "https://aomediacodec.github.io/av1-avif/"
---

## AV1 Image File Format (AVIF)

AVIF is a modern image format that pairs the compression efficiency of the AV1
video codec with the flexible HEIF container. It was developed under the Alliance
for Open Media as a royalty-free format and has been adopted quickly because it
delivers substantially smaller files than JPEG at similar quality, while also
supporting features that older web formats lack.

An AVIF file stores one or more still images (or an image sequence for animation)
coded as AV1 intra frames, wrapped in the ISO Base Media File Format / HEIF box
structure (the same container family as MP4 and HEIC). This gives it a wide
feature set: full alpha transparency, high bit depth, wide color gamut and HDR
(via color and transfer metadata), and layered/derived images. Being HEIF-based,
it is structurally close to Apple's HEIC, differing mainly in the codec used.

### Adoption

AVIF is supported by current versions of the major browsers and by a growing set
of image tools and operating systems. Because AV1 encoding is computationally
heavy, AVIF files are usually produced ahead of time or by build/CDN pipelines
rather than on the fly. The media type is `image/avif`.

### Preservation And Security Notes

Lossy AVIF discards data, so keep an original master for archival needs and treat
AVIF as an efficient delivery format; AVIF also supports a lossless mode where
exact pixels are required. As a container wrapping a complex codec, AVIF decoders
should validate box structure and image dimensions from untrusted files and be
kept current against codec vulnerabilities.

### Further Reading

- AVIF specification (AOMedia): `https://aomediacodec.github.io/av1-avif/`
