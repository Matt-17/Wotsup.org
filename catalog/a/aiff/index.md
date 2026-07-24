---
overview: ".aiff files are Audio Interchange File Format audio: Apple's IFF-based container for uncompressed PCM audio, the macOS counterpart to WAV, used as a high-quality master format."
extensions:
  - name: "Audio Interchange File Format"
    description: "Audio Interchange File Format"
    categories:
    - audio
    author: "Max Maischein"
    file: aif.zip
    
  - name: "C Sourcecode for using AIFF files"
    description: "C Sourcecode for using AIFF files"
    categories:
    - audio
    author: "Guido van Rossum, Lance Norskog And Others"
    file: aiff.zip
    
  - name: "Audio Interchange File Format v1.2"
    description: "Audio Interchange File Format v1.2"
    categories:
    - audio
    author: "Apple Computer, Inc."
    file: aiff1.zip    
---

## Audio Interchange File Format (AIFF)

AIFF is an uncompressed audio format developed by Apple, based on Electronic Arts'
Interchange File Format (IFF). It is essentially the Apple-world counterpart to
Microsoft's WAV: it stores linear PCM audio losslessly and is a common master and
interchange format in macOS audio production. The file is a chunked structure whose
`COMM` chunk records the number of channels, sample frames, sample size, and sample
rate, and whose `SSND` chunk holds the sound data.

A key detail distinguishing AIFF from WAV is byte order: AIFF stores samples
big-endian, reflecting its Motorola-based origins, whereas WAV is little-endian. A
variant, AIFF-C (AIFC), extends the format to allow compressed audio by adding a
compression-type field, while plain AIFF remains uncompressed.

### Preservation Notes

Like WAV, AIFF is well suited to preserving master audio because PCM is lossless
and the format is simple and widely supported; files are correspondingly large.
Record the sample rate, bit depth, and channel count, and note whether a file is
plain AIFF or AIFF-C. The common media type is `audio/aiff` (also `audio/x-aiff`).

### Security Notes

As a chunked binary format, an AIFF parser should validate chunk sizes and the
`COMM` parameters against the actual sound data when reading untrusted files to
avoid over-reads driven by malformed length fields.

### Further Reading

- AIFF format overview: `https://en.wikipedia.org/wiki/Audio_Interchange_File_Format`
