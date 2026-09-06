---
overview: ".ts files are most commonly MPEG transport streams (video/audio broadcast and HLS segments) or TypeScript source code files; the extension is used by both."
extensions:
  - name: "MPEG transport stream"
    description: "Packetized container for multiplexed audio, video, and data used in broadcast and HLS"
    categories:
    - video-animation
    - audio
    author: "ITU-T / ISO/IEC MPEG"
    link: "https://www.itu.int/rec/T-REC-H.222.0"
  - name: "TypeScript source file"
    description: "Source code of the TypeScript language, a typed superset of JavaScript"
    categories:
    - internet
    - data-format
    author: "Microsoft"
    link: "https://www.typescriptlang.org/docs/"
---

## TS

The `.ts` extension is ambiguous. The two meanings are unrelated: one is a
binary video container, the other is a text-based programming language file.

### MPEG Transport Stream

An MPEG transport stream (MPEG-TS) is defined in ITU-T H.222.0, identical to
ISO/IEC 13818-1 (MPEG-2 Systems). It carries multiplexed audio, video, and data
in fixed-size packets of 188 bytes. Each packet starts with the sync byte `0x47`
and has a 13-bit packet identifier (PID) that assigns it to a stream. Tables
such as PAT and PMT describe which PIDs make up each program. The format is
designed for lossy transmission, so decoders can resynchronize at any packet.

It is used in digital broadcasting (DVB, ATSC), on some camcorders and
recorders, and as the segment format of Apple HTTP Live Streaming (see
`.m3u8`). Blu-ray uses a related form (`.m2ts`) with 192-byte packets. The media
type is `video/mp2t`.

### TypeScript

TypeScript is a language developed by Microsoft that adds static types to
JavaScript. `.ts` files are plain text and are compiled or type-stripped to
JavaScript by the `tsc` compiler or by other build tools. Related extensions
include `.tsx` (with JSX syntax), `.mts`, and `.cts` (ES module and CommonJS
variants), plus `.d.ts` files that hold only type declarations.

### Practical Notes

Because the extension is shared, check the content: a transport stream starts
with `0x47` repeating every 188 bytes, while TypeScript is readable text. For
transport streams, record codecs and stream layout. Untrusted TS media needs a
patched demuxer, and TypeScript source should be reviewed like any code before
being built or run.

### Further Reading

- ITU-T H.222.0: `https://www.itu.int/rec/T-REC-H.222.0`
- TypeScript documentation: `https://www.typescriptlang.org/docs/`
