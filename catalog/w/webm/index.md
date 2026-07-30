---
overview: ".webm files are WebM media: a royalty-free, web-focused multimedia container (a restricted subset of Matroska) carrying VP8/VP9/AV1 video and Vorbis/Opus audio for open, efficient web video."
extensions:
  - name: "WebM media format"
    description: "Open, royalty-free web video container based on a Matroska subset"
    categories:
    - video-animation
    - internet
    author: "Google / WebM Project"
    link: "https://www.webmproject.org/"
---

## WebM

WebM is an open, royalty-free multimedia format designed specifically for video on
the web. It was created to give browsers a high-quality video format unencumbered by
patent-licensing fees, and it is supported natively by the major browsers for the
HTML5 `<video>` and `<audio>` elements. WebM pairs an open container with open
codecs so that the whole delivery path can be royalty-free.

Technically, WebM is a restricted profile of the Matroska container (built on the
EBML binary structure), limited to a defined set of royalty-free codecs: VP8, VP9,
or AV1 for video, and Vorbis or Opus for audio. Constraining Matroska in this way
keeps WebM simpler and more predictable for browser implementations while
benefiting from Matroska's proven, extensible design.

### Adoption And Preservation Notes

WebM is widely used for web video delivery, animated content (as an efficient
alternative to GIF), and streaming, especially where open codecs are preferred.
Because its codecs are typically lossy, keep a high-quality master for preservation
and record the specific video/audio codecs used. The common media type is
`video/webm` (or `audio/webm`).

### Security Notes

As an EBML/Matroska-derived container, a WebM demuxer should validate element sizes
from untrusted files, and decoders for the contained codecs should be kept current
against known vulnerabilities.

### Further Reading

- The WebM Project: `https://www.webmproject.org/`
