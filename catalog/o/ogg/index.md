---
overview: ".ogg files are Ogg container media: a free, open multimedia container from Xiph.Org that packages audio and video streams — most often Vorbis or Opus audio — into pages for streaming and storage."
extensions:
  - name: "Ogg Encapsulation Format Version 0"
    description: "Ogg Encapsulation Format Version 0"
    categories:
    - audio
    author: "The Internet Society"
    file: rfc3533.zip

  - name: "Ogg Vorbis Documentation"
    description: "Ogg Vorbis Documentation"
    categories:
    - audio
    author: "Xiph.org"
    link: "http://www.xiph.org/ogg/doc/"
---

## Ogg

Ogg is a free, open container format maintained by the Xiph.Org Foundation for
packaging compressed multimedia streams. It is a container, not a codec: an Ogg
file carries one or more logical bitstreams — commonly Vorbis or Opus audio, and
also FLAC audio or Theora video — organized so they can be streamed and seeked
efficiently. Because the format and its common codecs are royalty-free, Ogg is
popular in open-source software, games, and web audio.

Internally, an Ogg stream is divided into "pages," each beginning with the capture
pattern `OggS` and carrying a segment of one bitstream along with a granule
position (used for timing/seeking), a serial number identifying the stream, and a
CRC checksum. Multiple streams can be interleaved (multiplexed) so audio and video
play in sync. Conventionally, audio-only Vorbis files use `.ogg` or `.oga`, Opus
files use `.opus`, and video uses `.ogv`, though `.ogg` is still widely used
generically.

### Preservation And Security Notes

Ogg is a strong choice for open, unencumbered distribution and archiving of
compressed audio; note that Vorbis and Opus are lossy, so a lossless master should
be retained where exact reproduction matters (FLAC-in-Ogg is a lossless option).
The common media type is `audio/ogg` (or `video/ogg`). As a paged container, an Ogg
demuxer should validate page and segment sizes and verify CRCs when handling
untrusted files.

### Further Reading

- Ogg documentation (Xiph.Org): `https://xiph.org/ogg/`
- RFC 3533 (Ogg encapsulation): `https://datatracker.ietf.org/doc/html/rfc3533`
