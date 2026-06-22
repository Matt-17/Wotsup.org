---
overview: ".avi is primarily used for Audio Video Interleave (AVI) multimedia container files introduced by Microsoft for Video for Windows, interleaving audio and video streams in a RIFF chunk structure."
extensions:
  - name: "AVI File Format Documentation"
    description: "Microsoft Audio Video Interleave file format documentation describing the RIFF-based AVI container, headers, streams, and index; 1996 reference"
    categories:
    - video-animation
    - windows
    author: "Microsoft Corporation"
    file: avi.zip

  - name: "AVI Overview FAQ"
    description: "Practitioner-oriented FAQ covering AVI structure, codecs, players, and common interoperability problems"
    categories:
    - video-animation
    - windows
    author: "John F. McGowan"
    link: "http://www.jmcgowan.com/avi.html"

  - name: "OpenDML AVI File Format Extensions 1.02"
    description: "OpenDML extensions to the AVI file format addressing the old AVI 1.0 size limits by chaining AVIX RIFF chunks and adding standard index chunks; version 1.02, 1996/1997"
    categories:
    - video-animation
    - windows
    author: "OpenDML AVI M-JPEG File Format Committee (Matrox Electronic Systems Ltd.)"
    link: "https://web.archive.org/web/20191226055430/http://www.morgan-multimedia.com/download/odmlff2.pdf"
---

## Audio Video Interleave (AVI)

AVI is a multimedia container format introduced by Microsoft in 1992 as part of
Video for Windows. The name Audio Video Interleave, also written Audio Video
Interleaved, refers to the way audio and video data are interleaved inside the
file so that playback software can read both streams sequentially from disk
without seeking back and forth across the whole file. The common extension is
`.avi`.

AVI is built on RIFF, the Resource Interchange File Format, the same tagged
chunk structure used by WAV audio. That makes AVI structurally simple and widely
supported, but it also means AVI is only a container. The actual audio and video
samples inside are encoded with separate codecs, and a file that one player
opens without trouble may fail in another player that lacks the matching codec.

### File Structure

An AVI file is a RIFF form. It begins with the four ASCII bytes `RIFF`, followed
by a four-byte little-endian size, followed by the form type `AVI ` (the letters
`AVI` followed by a trailing space). The rest of the file is a sequence of
chunks, each made of a four-character tag, a four-byte little-endian size, and a
payload padded to an even byte boundary.

The main body is organized into three parts. `LIST 'hdrl'` is the header list
and is required to appear first. It contains the `avih` main AVI header chunk
and one `LIST 'strl'` sub-list per stream. Each stream list holds an `strh`
stream header, an `strf` stream format chunk, and optional `strd`, `strn`, or
`strl`-specific chunks. `LIST 'movi'` holds the actual interleaved media data.
The optional `idx1` chunk near the end is a legacy index that records the
position and size of every data chunk inside `movi`.

The `avih` main header records timing and layout facts such as microseconds per
frame, maximum bytes per second, total frames, number of streams, suggested
buffer size, and the video width and height. Each `strh` stream header records a
FourCC type such as `vids` for video, `auds` for audio, `txts` for text, or
`mids` for MIDI, a codec handler FourCC, and a `dwRate` and `dwScale` pair whose
ratio `dwRate / dwScale` gives the stream rate in samples per second. For video
this is the frame rate; for audio it describes the timing of `nBlockAlign` audio
units and equals the PCM sample rate only in the usual PCM case. The `strf`
chunk follows the stream type: video streams use a `BITMAPINFO` /
`BITMAPINFOHEADER`-based structure, including palette information when
appropriate, while audio streams use a `WAVEFORMATEX` structure. Optional `strd` chunks carry
codec-specific initialization data that some decoders require, and `strn`
chunks carry a human-readable stream name.

Inside `movi`, data chunks are tagged with a two-digit stream index plus a
two-character type. For example, `00dc` is a compressed video frame for stream
zero, `00db` is an uncompressed video frame for stream zero, and `01wb` is audio
waveform bytes for stream one. Related chunks may be grouped inside a `rec `
list so they can be read as a single record, which helps interleaved playback
and editing.

### Identification And Indexing

The most reliable identification is the RIFF signature followed by the `AVI `
form type. AVI files using OpenDML may append additional RIFF chunks whose form
type is `AVIX`, especially when crossing the old AVI 1.0 size limits, and may
introduce standard index chunks such as `indx` and per-stream `ix##` indexes.
Some tools also write `JUNK` chunks, which are padding used to align later
structures on file offsets; these are valid and should be skipped rather than
treated as corruption.

The legacy `idx1` index is not always present, and when present it may be
inconsistent with the actual `movi` layout if a file was edited or written by a
non-conforming tool. Players that need robust seeking often rebuild the index
from the `movi` chunks instead of trusting `idx1`.

### Codecs And Compatibility

AVI does not mandate any particular codec. Common video codecs found inside AVI
include DivX, Xvid, Microsoft MPEG-4, Intel Indeo, Cinepak, Motion JPEG, DV,
HuffYUV, and uncompressed RGB. Common audio codecs include MP3, AC3, PCM, and
Microsoft ADPCM. Because the container only describes framing and timing, two
`.avi` files can both be valid AVI while requiring completely different decoder
support.

This codec flexibility is the main source of AVI interoperability problems. A
machine missing a specific codec will show video but no audio, audio but no
video, or refuse the file entirely, sometimes with a misleading "corrupt file"
message. For preservation or exchange, record the codec FourCCs for each
stream in addition to keeping the `.avi` container, because decoding depends on
matching external codec support that is not embedded in the file.

### Limitations And AVI 2.0

Classic AVI 1.0 has practical limits. RIFF sizes are 32-bit, and many
implementations treat them as signed, so individual files are effectively
capped near 2 GB, with older FAT16-era tools and MCIAVI implementations hitting
limits closer to 1 GB. The basic format has no standardized way to store aspect
ratio, reliable variable frame rate, timecode, or modern metadata, and no
broadly interoperable modern subtitle-track model despite support for `txts`
text streams. B-frame video streams, common in later MPEG-4 codecs, are handled
through non-standard workarounds that not every splitter honors.

The OpenDML AVI File Format Extensions, sometimes called AVI 2.0, address the
old AVI 1.0 size limits, commonly encountered around 1–2 GB depending on
implementation and filesystem, by chaining additional RIFF chunks with the
`AVIX` form type and by adding richer index chunks. OpenDML uses a per-stream
index model: an `indx` chunk may appear in the stream header after `strf`, and a
super index can point to `ix##` standard or field index chunks interleaved
inside `movi`. The field-level indexing matters for interlaced professional
video. Most modern large AVI files employ the DML extensions, and the Library of
Congress reports NTFS can carry OpenDML AVI files up to tens of terabytes. Older
tools may still reject AVIX chunks or mishandle them, so the classic 2 GB
boundary remains a practical compatibility threshold.

### Preservation And Security Notes

AVI preservation should keep the original file when possible and validate more
than the RIFF signature. Useful checks include chunk sizes and padding, the
presence and ordering of the `hdrl`, `movi`, and index chunks, per-stream
headers, stream counts, frame counts, and whether the `idx1` index agrees with
the `movi` data. Record the codec FourCCs for every stream, because the file is
not self-describing beyond the container level.

AVI parsers need strict bounds checks. Malformed files can produce recursive or
deeply nested `LIST` structures, chunk sizes that point outside the file,
negative or zero sizes, large allocation requests from header fields, or
deliberately inconsistent indexes that trick a player into seeking to attacker
chosen offsets. Codec parsing bugs are a separate and historically large attack
surface, so pipelines that accept arbitrary AVI files should demux in a
constrained process and decode streams with sandboxed or actively maintained
codecs. Modern containers such as MP4 and Matroska generally support
contemporary features more cleanly, but AVI remains common in legacy archives.

### Further Reading

- AVI Overview FAQ (John F. McGowan): `http://www.jmcgowan.com/avi.html`
- OpenDML AVI File Format Extensions 1.02 (Morgan Multimedia mirror via Internet Archive): `https://web.archive.org/web/20191226055430/http://www.morgan-multimedia.com/download/odmlff2.pdf`
- Microsoft AVI RIFF File Reference: `https://learn.microsoft.com/en-us/windows/win32/directshow/avi-riff-file-reference`
- Library of Congress format description for AVI: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000059.shtml`
- Library of Congress format description for AVI with OpenDML Extensions 1.02: `https://www.loc.gov/preservation/digital/formats/fdd/fdd000442.shtml`
- Related containers: WAV, MP4, Matroska (MKV), MOV
