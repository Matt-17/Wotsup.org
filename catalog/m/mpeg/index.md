---
overview: ".mpeg/.mpg files are MPEG program streams: audio and video coded with the MPEG-1 or MPEG-2 standards and multiplexed together, the format behind Video CD, DVD-Video, and digital broadcast."
extensions:
  - name: "ISO/IEC 13818-1 MPEG-2 Systems"
    description: "ISO/IEC 13818-1 MPEG-2 Systems"
    categories:
    - video-animation
    author: "ISO/IEC"
    file: mpeg2-1.zip
    
  - name: "ISO/IEC 13818-2 MPEG-2 Video"
    description: "ISO/IEC 13818-2 MPEG-2 Video"
    categories:
    - video-animation
    author: "ISO/IEC"
    file: mpeg2-2.zip
    
  - name: "ISO/IEC 13818-3 MPEG-2 Audio"
    description: "ISO/IEC 13818-3 MPEG-2 Audio"
    categories:
    - video-animation
    author: "ISO/IEC"
    file: mpeg2-3.zip
    
  - name: "MPEG-2 Technical Frequently Asked Questions list"
    description: "MPEG-2 Technical Frequently Asked Questions list"
    categories:
    - video-animation
    author: "Chad Fogg"
    file: mpeg_faq.zip
    
  - name: "Moving Picture Experts Group"
    description: "Moving Picture Experts Group"
    categories:
    - video-animation
    link: "http://www.cselt.stet.it/mpeg/"
    deprecated: true

  - name: "MPEG-4 Audio Reference Software (C code)"
    description: "MPEG-4 Audio Reference Software (C code)"
    categories:
    - video-animation
    author: "Various Authors"
    file: mpeg4.zip
    
  - name: "MPEG A Multimedia Application Format Overview and Requirements (v.2)"
    description: "MPEG A Multimedia Application Format Overview and Requirements (v.2)"
    categories:
    - video-animation
    author: "Wo Chang"
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-a/mpeg-a.htm"
    deprecated: true
    
  - name: "MPEG Video Header (Partial Information)"
    description: "MPEG Video Header (Partial Information)"
    categories:
    - video-animation
    author: "Wilson Woo"
    file: mpeg.zip
    
  - name: "MPEG 21 Overview v.5"
    description: "MPEG 21 Overview v.5"
    categories:
    - video-animation
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-21/mpeg-21.htm"
    deprecated: true
    
  - name: "MPEG 7 Overview"
    description: "MPEG 7 Overview"
    categories:
    - video-animation
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-7/mpeg-7.htm"
    deprecated: true
    
  - name: "ISO/IEC 11172(MPEG-1)/13818(MPEG-2) MPEG Bit Stream Quick Reference"
    description: "ISO/IEC 11172(MPEG-1)/13818(MPEG-2) MPEG Bit Stream Quick Reference"
    categories:
    - video-animation
    author: "Shan Weber"
    file: mpeg-layout.zip
    deprecated: true
    
  - name: "MPEG 4 Overview"
    description: "MPEG 4 Overview"
    categories:
    - video-animation
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-4/mpeg-4.htm"
    deprecated: true

  - name: "MPEG.ORG site"
    description: "MPEG.ORG site"
    categories:
    - video-animation
    link: "https://www.mpeg.org/"
    
  - name: "ISO/IEC 13818 MPEG 2 Format (9 parts)"
    description: "ISO/IEC 13818 MPEG 2 Format (9 parts)"
    categories:
    - video-animation
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-2/mpeg-2.htm"
    deprecated: true
    
  - name: "ISO/IEC 11172 MPEG 1 Format (5 parts)"
    description: "ISO/IEC 11172 MPEG 1 Format (5 parts)"
    categories:
    - video-animation
    link: "http://www.chiariglione.org/mpeg/standards/mpeg-1/mpeg-1.htm"
    deprecated: true
    
  - name: "Overview of the MPEG-4 Standard"
    description: "Overview of the MPEG-4 Standard"
    categories:
    - video-animation
    author: "Rob Koenen"
    link: "http://mpeg.telecomitalialab.com/standards/mpeg-4/mpeg-4.htm"
    deprecated: true
    
---

## MPEG (MPEG-1 / MPEG-2)

MPEG refers to the family of audio-video standards from the Moving Picture Experts
Group. A `.mpeg` or `.mpg` file most commonly holds MPEG-1 or MPEG-2 compressed
video together with MPEG audio, multiplexed into a single stream. These standards
made digital video practical at consumer bitrates and underpin a generation of
technology: MPEG-1 powered Video CD and the MP3 audio format (MPEG-1 Audio Layer
III), while MPEG-2 powers DVD-Video and much of digital television.

MPEG defines both the coding of the elementary video and audio streams and how they
are combined. The Program Stream, used for storage such as DVDs, multiplexes audio
and video for relatively error-free media, while the Transport Stream is designed
for broadcast and streaming where errors are expected. Video compression relies on
motion-compensated prediction between frames (I-, P-, and B-frames) plus
block-based transform coding, achieving large size reductions at the cost of being
lossy.

### Status And Preservation Notes

MPEG-1/2 remain widely playable and important for legacy media, though newer codecs
(H.264, HEVC, AV1) are far more efficient for new content. Because the video is
lossy, a preservation master should be the highest-quality source available; record
the specific standard, profile, and stream type (program vs transport). The common
media type is `video/mpeg`.

### Security Notes

As a byte-stream format parsed with start codes and length fields, MPEG demuxers and
decoders should validate stream structure from untrusted files, since malformed
packets and headers are a known source of decoder vulnerabilities.

### Further Reading

- MPEG standards overview: `https://www.mpeg.org/` and `https://en.wikipedia.org/wiki/Moving_Picture_Experts_Group`
