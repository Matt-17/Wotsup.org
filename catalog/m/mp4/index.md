---
overview: ".mp4 files are MPEG-4 Part 14 containers: the near-universal modern container for video and audio, based on the ISO Base Media File Format, holding coded streams such as H.264/HEVC video and AAC audio plus metadata."
extensions:
  - name: "MP4 (MPEG-4 Part 14) container"
    description: "ISO Base Media File Format container for video, audio, subtitles, and metadata"
    categories:
    - video-animation
    - audio
    author: "ISO/IEC (MPEG)"
    link: "https://en.wikipedia.org/wiki/MP4_file_format"
---

## MPEG-4 Part 14 (MP4)

MP4 is the dominant container format for digital video and audio today, used
everywhere from streaming services and social platforms to phone cameras and video
files on disk. It is defined by MPEG as MPEG-4 Part 14 and is built on the ISO Base
Media File Format (ISOBMFF), itself derived from Apple's QuickTime format. Like
other containers, MP4 stores coded media rather than defining a codec: a typical
`.mp4` carries H.264 (AVC) or H.265 (HEVC) video and AAC audio, but it can also hold
AV1, subtitles, chapters, and cover art.

Structurally, an MP4 is a tree of "boxes" (also called atoms), each length-prefixed
and typed. A `moov` box holds structural metadata — tracks, sample tables, timing —
while `mdat` boxes hold the media samples. A feature important for the web is
"fast-start" (moving the `moov` box before the media) and fragmentation
(fragmented MP4), which enables progressive and adaptive streaming such as
MPEG-DASH and HLS.

### Adoption And Preservation Notes

MP4's broad hardware and software support makes it a safe, long-lived choice for
distributing and storing media, though its codecs (notably H.264/HEVC) can carry
patent-licensing considerations, which is part of why royalty-free alternatives like
WebM/AV1 exist. Because the video is usually lossy, keep a high-quality master for
preservation and record the contained codecs and profiles. The common media type is
`video/mp4` (or `audio/mp4` for audio-only).

### Security Notes

As a box-structured binary format, MP4 demuxers should validate box sizes and
sample-table offsets from untrusted files, since malformed atoms have repeatedly
been a source of media-parser vulnerabilities.

### Further Reading

- ISO Base Media File Format (ISO/IEC 14496-12) overview: `https://en.wikipedia.org/wiki/ISO_base_media_file_format`
