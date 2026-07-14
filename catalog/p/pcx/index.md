---
overview: ".pcx files are ZSoft PCX images: one of the earliest widely used PC raster formats, storing palettized or RGB images with simple run-length compression."
extensions:
  - name: "PCX File Format Technical Reference"
    description: "PCX File Format Technical Reference"
    categories:
    - 2d-graphics
    author: "ZSoft Corporation"
    file: pcx.zip
---

## ZSoft PCX

PCX is one of the oldest raster image formats for the PC, originating with ZSoft's
PC Paintbrush in the 1980s. For years it was a de facto standard for paint programs
and scanners, and it remains a format that image tools broadly support even though
newer formats have largely replaced it. Files begin with the byte `0x0A` (the ZSoft
manufacturer marker) followed by a version number.

A PCX file has a 128-byte header recording the version, bits per pixel and number
of color planes, image dimensions, and resolution, followed by run-length-encoded
pixel data. Color is handled by bit depth and planes: early images used
1-, 2-, or 4-bit palettes, later versions added a 256-color palette stored at the
end of the file (introduced by a `0x0C` marker) and 24-bit true color via three
8-bit planes. The RLE scheme is simple, which made encoding and decoding fast on
period hardware.

### Status And Preservation Notes

PCX is effectively a legacy format today, encountered mainly in older graphics,
DOS-era software, and some scanning and fax workflows. It is lossless and openly
documented, so it preserves image data faithfully; migrating to a modern lossless
format such as PNG while retaining the original is a reasonable approach. The
common media type is `image/x-pcx`.

### Security Notes

RLE decoders are a classic source of buffer overflows when run counts are trusted
blindly, so a PCX reader should validate header dimensions and plane counts and
bound the decoded output when handling untrusted files.

### Further Reading

- ZSoft PCX File Format Technical Reference: `https://www.fileformat.info/format/pcx/egff.htm`
