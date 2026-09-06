---
overview: ".m4a files are MPEG-4 audio files: audio-only MP4 containers usually holding AAC or Apple Lossless (ALAC) audio; related extensions include .m4b for audiobooks and .m4p for protected iTunes purchases."
extensions:
  - name: "MPEG-4 audio file (M4A)"
    description: "Audio-only ISO base media file, typically AAC or ALAC audio with iTunes-style metadata"
    categories:
    - audio
    author: "ISO/IEC MPEG / Apple"
    link: "https://developer.apple.com/documentation/quicktime-file-format"
  - name: "MPEG-4 File Format"
    description: "Library of Congress description of the MPEG-4 (MP4) file format family"
    categories:
    - audio
    - video-animation
    author: "ISO/IEC MPEG"
    link: "https://www.loc.gov/preservation/digital/formats/fdd/fdd000155.shtml"
---

## M4A

M4A is the conventional extension for MP4 files that contain only audio. It
was popularized by Apple's iTunes, and the container is the same as for `.mp4`.
The audio is usually AAC (lossy) or Apple Lossless (ALAC). Variants include
`.m4b` for audiobooks and podcasts, which can carry chapters and bookmarks, and
`.m4p` for protected tracks sold by the early iTunes Store.

### Container Structure

The container is based on the ISO base media file format, derived from the
QuickTime file format. Data is organized into boxes (atoms), each with a size and
a four-character type. A file starts with an `ftyp` box whose major brand is
commonly `M4A ` (with a trailing space). The `moov` box holds track and sample
tables, and `mdat` holds the encoded audio. Tags such as title, artist, and cover
art are normally stored in the `moov/udta/meta/ilst` structure. When `moov`
comes before `mdat`, playback can start while the file is still downloading.

### Adoption

M4A is supported by essentially all current operating systems, phones, and media
players. The media type is `audio/mp4`. Because the extension only tells you
that a file is audio, the actual codec (AAC, ALAC, or another) must be read
from the file.

### Preservation And Security Notes

AAC in M4A is lossy; ALAC is lossless and suits archival copies. Record the
codec, sample rate, and tag content. Parsers must validate box sizes and nesting
depth, since malformed boxes are a common source of decoder bugs.

### Further Reading

- QuickTime File Format documentation (Apple): `https://developer.apple.com/documentation/quicktime-file-format`
- MPEG-4 File Format (Library of Congress): `https://www.loc.gov/preservation/digital/formats/fdd/fdd000155.shtml`
