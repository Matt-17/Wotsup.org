---
overview: ".mkv files are Matroska multimedia containers: an open, flexible EBML-based container that can hold virtually any number of video, audio, and subtitle tracks plus chapters and metadata in one file."
extensions:
  - name: "Matroska File Formats"
    description: "Matroska file formats (MKV, MKA, MKS)"
    categories:
    - video-animation
    - audio
    link: "http://www.matroska.org/technical/index.html"
    deprecated: true
---

## Matroska (MKV)

Matroska is an open, royalty-free multimedia container format, and `.mkv` is its
video variant (with `.mka` for audio and `.mks` for subtitles). Its goal is to be a
universal container: a single file can hold an essentially unlimited number of
video, audio, and subtitle tracks, along with chapters, tags, attachments (such as
fonts or cover art), and menus. This flexibility made MKV popular for high-
definition video, multilingual releases, and archival of complex media.

Matroska is built on EBML (Extensible Binary Meta Language), a binary analogue of
XML: the file is a tree of typed, length-prefixed elements, which makes the format
extensible without breaking older parsers. Like other containers, Matroska stores
coded streams rather than defining codecs, so an `.mkv` might contain H.264, HEVC,
AV1, or other video and AAC, Opus, FLAC, or other audio. The web-focused WebM format
is a restricted subset of Matroska limited to specific royalty-free codecs.

### Preservation And Security Notes

Matroska is well suited to preservation and interchange of multi-track media
because it is open, documented, and codec-agnostic, but faithful playback depends on
having decoders for the contained codecs, which should be recorded. The common media
type is `video/x-matroska` (`audio/x-matroska` for MKA). As an EBML container with
length-prefixed elements, a demuxer should validate element sizes from untrusted
files to avoid over-reads or excessive allocation.

### Further Reading

- Matroska specifications: `https://www.matroska.org/technical/basics.html`
