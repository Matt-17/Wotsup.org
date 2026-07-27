---
overview: ".mov files are QuickTime movies: Apple's multimedia container, organized as a tree of atoms/boxes, that stores video, audio, timed text, and other tracks; its structure became the basis of MP4/ISOBMFF."
extensions:
  - name: "QuickTime Movie Format"
    description: "QuickTime Movie Format"
    categories:
    - video-animation
    author: "Shan Weber"
    file: qtm-layout.zip
    
  - name: "QuickTime Movie File Format May 1996)"
    description: "QuickTime Movie File Format May 1996)"
    categories:
    - video-animation
    author: "Apple"
    file: mov.zip
    
  - name: "QuickTime Atom Hacks"
    description: "QuickTime Atom Hacks"
    categories:
    - video-animation
    author: "Shan Weber"
    file: atom_hacks-layout.zip
    
  - name: "QuickTime movies"
    description: "QuickTime movies"
    categories:
    - video-animation
    author: "Apple"
    link: "http://www.apple.com/quicktime/"
        
---

## QuickTime Movie (MOV)

MOV is the multimedia container format of Apple's QuickTime framework. It stores
one or more time-based media tracks — video, audio, timed text/subtitles, timecode,
and more — together with the metadata needed to synchronize and present them. MOV is
a container: it holds coded media (for example H.264 or ProRes video and AAC or PCM
audio) rather than defining a codec itself, and it is a mainstay of professional
video production, especially in Apple-centric workflows.

Structurally, a MOV file is a hierarchy of "atoms" (also called boxes), each a
length-prefixed, typed unit. A `moov` atom holds the movie's structural metadata
(tracks, sample tables, timing), while `mdat` atoms hold the actual media samples.
This atom-based design was standardized, with modifications, as the ISO Base Media
File Format, which in turn is the foundation of the MP4 (`.mp4`) container — so MOV
and MP4 are close relatives that share much of their structure.

### Preservation And Security Notes

MOV is a capable container for high-quality and edit-friendly media (for instance
with the ProRes codec), but faithful playback depends on the availability of the
contained codecs, which should be recorded for preservation; for long-term access,
a widely supported codec-and-container combination is preferable. As an atom-based
binary format, a parser handling untrusted MOV files should validate atom sizes and
sample-table offsets to avoid out-of-bounds reads.

### Further Reading

- QuickTime File Format overview: `https://developer.apple.com/documentation/quicktime-file-format`
