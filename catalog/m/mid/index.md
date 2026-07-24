---
overview: ".mid files are Standard MIDI Files: they store sequences of musical performance events — notes, timing, and controls — rather than recorded audio, to be played back by synthesizers or software instruments."
extensions:
  - name: "Standard MIDI File Format"
    description: "Standard MIDI File Format"
    categories:
    - audio
    author: "Dustin Caldwell"
    file: midi.zip
    
  - name: "General MIDI Level 1 Spec."
    description: "General MIDI Level 1 Spec."
    categories:
    - audio
    author: "Jeff Mallory"
    file: mid-frm3.zip
    
  - name: "MIDI Manufacturers Association - the definitive source of MIDI information."
    description: "MIDI Manufacturers Association - the definitive source of MIDI information."
    categories:
    - audio
    link: "http://www.midi.org/"
    
  - name: "Standard MIDI File Format"
    description: "Standard MIDI File Format"
    categories:
    - audio
    link: "http://www.borg.com/~jglatt/tech/midifile.htm"
    deprecated: true
    
  - name: "The USENET MIDI Primer (note .KAR files are standard MIDI files)"
    description: "The USENET MIDI Primer (note .KAR files are standard MIDI files)"
    categories:
    - audio
    author: "Bob McQueer"
    file: midi-prim.zip

  - name: "MIDI Sample Dump Standard"
    description: "MIDI Sample Dump Standard"
    categories:
    - audio
    file: mid-frm4.zip
    
---

## Standard MIDI File (SMF)

A Standard MIDI File stores music as a sequence of instructions rather than as
recorded sound. Instead of audio samples, a `.mid` file contains timed MIDI events
— note-on and note-off, pitch, velocity, program (instrument) changes, controller
movements, and tempo — that a synthesizer, sound module, or software instrument
interprets to produce audio. This makes MIDI files tiny compared with audio
recordings and fully editable at the note level, but it also means the same file
can sound quite different depending on the instruments used to play it.

The format is chunk-based: a header chunk (`MThd`) specifies the format type and
timing resolution, and one or more track chunks (`MTrk`) hold the event streams,
each event preceded by a delta-time. There are three format types: type 0 (a single
combined track), type 1 (multiple synchronized tracks, the most common), and type 2
(independent patterns). General MIDI is a companion standard that fixes a common
instrument map so files play consistently across devices. Karaoke `.kar` files are
Standard MIDI Files with embedded lyrics.

### Preservation Notes

MIDI is compact, open, and well documented, making it excellent for preserving the
performance/score data of a piece. The important caveat is that playback depends on
an external sound source (a synthesizer or soundfont), so a faithful rendering
should record or bundle the intended instrument set; the `.mid` alone captures the
notes, not the timbre. The common media type is `audio/midi`.

### Security Notes

As a chunked binary format with variable-length quantities and length-prefixed
tracks, a MIDI parser should validate chunk and event lengths from untrusted files
to avoid over-reads.

### Further Reading

- MIDI Association (specifications): `https://www.midi.org/specifications`
