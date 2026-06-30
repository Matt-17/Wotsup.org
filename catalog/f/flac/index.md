---
overview: ".flac files store Free Lossless Audio Codec streams: compressed audio that decodes exactly to the original PCM samples, with file-level metadata and integrity checks for reliable interchange."
extensions:
  - name: "Free Lossless Audio Codec (FLAC) format"
    description: "Lossless audio coding format and native .flac stream structure for PCM audio"
    categories:
    - audio
    author: "Josh Coalson / Xiph.Org Foundation"
    link: "https://xiph.org/flac/format.html"
---

## Free Lossless Audio Codec (FLAC)

FLAC is an open lossless audio format for compressing PCM audio without
discarding sample information. Unlike MP3, AAC, or other perceptual codecs,
decoding a valid FLAC stream reconstructs the original PCM samples exactly.
That makes `.flac` files common for music collections, archival transfers,
sound libraries, and workflows where later editing or transcoding should not
start from a lossy source.

The native `.flac` file format is also the FLAC stream format. A stream starts
with the ASCII marker `fLaC`, followed by metadata blocks and then audio
frames. The first metadata block is the required `STREAMINFO` block, which
records properties such as sample rate, channel count, bits per sample, total
sample count, and an MD5 signature of the unencoded audio. Optional metadata
blocks can provide padding, application-specific data, seek tables, Vorbis
comments, cue sheets, and embedded pictures.

### Compression Model

FLAC is tuned for short-range redundancy in PCM audio. Encoders split audio
into blocks, optionally use stereo decorrelation, predict each channel from
nearby samples, and store the residual with Rice coding. If prediction is not
useful for a block, the encoder can store that part verbatim while the overall
stream remains lossless.

Because FLAC compresses PCM rather than arbitrary binary data, it is not a
replacement for ZIP-style archival compression. It works best when the input is
linear audio and when downstream software preserves the stream metadata rather
than rewriting it unnecessarily.

### Compatibility And Preservation Notes

The common media type for native FLAC is `audio/flac`. FLAC audio can also be
mapped into other containers, such as Ogg, Matroska, or MP4, but those
containerized forms should be identified by their container context rather than
by a plain `.flac` extension alone.

For preservation, keep the original file when possible and record the sample
rate, channel layout, bit depth, total sample count, embedded cue sheet,
Vorbis-comment fields, cover-art metadata, and any application metadata blocks.
Verification tools should check both stream structure and decoded-audio
integrity, including the `STREAMINFO` MD5 where available. Converting FLAC to a
lossy format is a derivative access copy, not a preservation equivalent.

### Security Notes

FLAC parsers should validate metadata block lengths, frame headers, seek-table
entries, sample counts, picture metadata, and allocation sizes before trusting
them. Embedded pictures and metadata URIs deserve separate policy checks,
especially in software that automatically fetches linked resources or renders
cover art from untrusted files.

### Further Reading

- FLAC format specification: `https://xiph.org/flac/format.html`
- RFC 9639, Free Lossless Audio Codec (FLAC): `https://datatracker.ietf.org/doc/rfc9639/`
