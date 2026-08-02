---
overview: ".opus files are Opus audio: a modern, open, royalty-free lossy audio codec (standardized as RFC 6716) that delivers excellent quality across a very wide bitrate range, from voice chat to music, usually in an Ogg container."
extensions:
  - name: "Opus audio format"
    description: "Open, low-latency, royalty-free lossy audio codec, typically carried in Ogg"
    categories:
    - audio
    - internet
    author: "IETF / Xiph.Org"
    link: "https://opus-codec.org/"
---

## Opus

Opus is a modern audio codec designed to be a single, open, royalty-free format
that performs well across the full range of audio applications — from low-bitrate
speech and real-time communication to high-quality music streaming. Standardized by
the IETF as RFC 6716, it consistently matches or outperforms older codecs (such as
MP3, AAC, and Vorbis) at comparable bitrates, which is why it has become a default
choice for new audio work.

Opus achieves this breadth by combining two technologies: a linear-prediction coder
(derived from SILK) that excels at speech, and a transform coder (CELT) that excels
at music, with the encoder blending or switching between them as the content
demands. It supports variable and constant bitrates, a wide range of sample rates,
mono through multichannel, and very low latency, making it equally suited to VoIP,
video conferencing, game audio, and podcasts.

### Containers And Use

Opus is a codec, not a container. Standalone Opus audio is normally carried in an
Ogg container with the `.opus` extension, and Opus is also a standard audio codec
inside WebM and Matroska and is widely used in WebRTC real-time communication. It is
supported by modern browsers, operating systems, and media tools.

### Preservation And Security Notes

Opus is lossy, so for archival masters a lossless format (such as FLAC or PCM/WAV)
should be retained, with Opus used as an efficient distribution format; record the
bitrate and channel layout. The common media type is `audio/opus` (or `audio/ogg`
when Ogg-encapsulated). As with any codec, decoders handling untrusted streams
should validate packet structure and stay patched.

### Further Reading

- Opus codec home page: `https://opus-codec.org/`
- RFC 6716 (Definition of the Opus Audio Codec): `https://datatracker.ietf.org/doc/html/rfc6716`
