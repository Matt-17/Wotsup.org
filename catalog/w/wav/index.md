---
overview: ".wav files are WAVE audio: Microsoft's RIFF-based audio container, most often holding uncompressed PCM samples, widely used as a high-quality, editable master format on Windows and beyond."
extensions:
  - name: "Microsoft WAV Sound File Format"
    description: "Microsoft WAV Sound File Format (MS Word)"
    categories: 
    - audio
    - windows
    author: "Rob Ryan/Robert Shuler"
    file: wav.zip
    
  - name: "WAVE File Format"
    description: "WAVE File Format"
    categories: 
    - audio
    - windows
    author: "Microsoft"
    file: wave.zip
    
  - name: "WAVE Formats and Compression Types"
    description: "WAVE formats and compression types"
    categories: 
    - audio
    - windows
    author: "Microsoft" 
    file: wave_comp.zip   
    
---

## Waveform Audio (WAV)

WAV is the standard audio file format on Windows and a ubiquitous format for
uncompressed audio everywhere. It is an application of Microsoft and IBM's RIFF
container: the file begins with `RIFF`, declares the `WAVE` form type, and is
built from chunks. The two essential chunks are `fmt ` (which records the audio
format, channel count, sample rate, and bit depth) and `data` (which holds the raw
samples). Because the audio is typically linear PCM, WAV preserves the signal
exactly, which is why it is favored as an editing and mastering format.

Although PCM is the common case, the container can also carry compressed codecs
identified by a format tag, and extended forms (WAVE_FORMAT_EXTENSIBLE) support
multichannel layouts and higher precision. Optional chunks can hold cue points,
loops, and metadata. The closely related Broadcast Wave Format (BWF) adds a `bext`
chunk with production metadata and timecode for professional use.

### Limitations And Preservation Notes

Uncompressed WAV files are large, and the classic format uses 32-bit chunk sizes,
which historically limited files to about 4 GB (addressed by extensions such as
RF64). WAV is an excellent preservation and interchange format for master audio
because it is simple, lossless (as PCM), and universally supported; record the
sample rate, bit depth, and channel layout. The common media type is `audio/wav`
(also `audio/x-wav`).

### Security Notes

As a chunked binary format, a WAV reader should validate chunk sizes and the
declared format against the actual data when handling untrusted files, since
malformed size fields are a classic source of over-reads in media parsers.

### Further Reading

- WAVE/RIFF audio format overview: `https://en.wikipedia.org/wiki/WAV`
