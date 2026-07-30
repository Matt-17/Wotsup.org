---
overview: ".swf files are Flash (Small Web Format) movies: a compact vector-based format for animation, interactivity, and ActionScript applications that dominated early interactive web content and is now retired."
extensions:
  - name: "SWF File Format Specification"
    description: "SWF File Format Specification"
    categories:
    - internet
    - video-animation
    author: "Macromedia, Incorporated"
    file: swffileformat.zip
    deprecated: true

  - name: "Macromedia Flash File Format (SWF)"
    description: "Macromedia Flash File Format (SWF)"
    categories:
    - internet
    - video-animation
    author: "Macromedia, Incorporated"
    link: "http://www.half-serious.com/swf/format/"
    deprecated: true
---

## SWF (Flash)

SWF (officially "Small Web Format," long read as "Shockwave Flash") was the
delivery format of Adobe/Macromedia Flash. It was designed to package vector
graphics, animation, embedded raster images and audio/video, and interactive
behavior driven by the ActionScript language into a compact file that a browser
plug-in could play. For roughly two decades SWF was the dominant format for web
animation, games, rich advertisements, and interactive applications.

An SWF file begins with a signature — `FWS` for uncompressed, or `CWS` (zlib) and
`ZWS` (LZMA) for the compressed variants — followed by a header with the frame size,
rate, and count, and then a series of tagged records defining shapes, sprites,
timelines, scripts, and embedded media. The vector-based design let content scale
smoothly, and the scripting engine made SWF effectively an application platform, not
just an animation format.

### Retirement And Preservation Notes

Adobe ended support for Flash Player at the end of 2020, and browsers removed the
plug-in, so SWF is now a legacy/retired format that no longer plays in mainstream
environments. Preservation efforts rely on emulators and open players (such as the
Ruffle project) and on documentation of the format. Where possible, migrating
important content to modern web technologies (HTML5, canvas/WebGL, video) is the
path forward.

### Security Notes

The Flash Player was a frequent target of exploits, and SWF files can contain
scripted behavior and embedded media, so untrusted SWF should be treated as active
content and only ever run inside a sandboxed, modern player rather than a legacy
plug-in.

### Further Reading

- Ruffle (open-source Flash emulator): `https://ruffle.rs/`
