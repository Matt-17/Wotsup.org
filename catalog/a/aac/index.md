---
overview: ".aac files are Advanced Audio Coding streams: lossy compressed audio, usually stored as raw ADTS frames, defined by the MPEG-2 and MPEG-4 standards as a successor to MP3."
extensions:
  - name: "Advanced Audio Coding (AAC)"
    description: "Lossy perceptual audio codec from MPEG-2 and MPEG-4, stored as raw ADTS or ADIF streams"
    categories:
    - audio
    author: "ISO/IEC MPEG"
    link: "https://www.loc.gov/preservation/digital/formats/fdd/fdd000114.shtml"
---

## AAC

Advanced Audio Coding (AAC) is a lossy audio codec standardized by ISO/IEC MPEG,
first in MPEG-2 (ISO/IEC 13818-7) and then extended in MPEG-4 Audio (ISO/IEC
14496-3). It was designed to give better quality than MP3 at similar bit rates.
A file with the `.aac` extension normally holds a bare AAC stream without a
richer container.

### Stream Structure

Raw AAC files typically use ADTS (Audio Data Transport Stream), where every
frame starts with a header whose first 12 bits are all ones (sync word `0xFFF`).
The header carries the profile, sampling rate, and channel configuration, so
each frame can be decoded independently and the stream can be joined or cut at
frame boundaries. A less common variant is ADIF, which has a single header at
the start of the file and begins with the ASCII bytes `ADIF`. Metadata such as
ID3 tags is sometimes prepended to ADTS files, but there is no standard tag
format for the raw stream.

### Adoption

AAC is widely supported by browsers, phones, streaming services, and
broadcast systems. Most AAC audio is not distributed as bare `.aac` files but
inside MP4 containers (`.m4a`, `.mp4`), in MPEG transport streams, or in
HLS segments. The common media type for ADTS is `audio/aac`.

### Preservation And Security Notes

AAC is lossy, so keep an uncompressed or lossless master where one exists and
treat AAC as a delivery format. Because the raw stream has no index or standard
metadata, wrapping it in MP4 is generally preferable for libraries. Decoders
should validate frame lengths and header fields in untrusted input.

### Further Reading

- Library of Congress format description: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000114.shtml`
