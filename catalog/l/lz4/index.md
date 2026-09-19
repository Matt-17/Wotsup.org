---
overview: ".lz4 files are LZ4-compressed streams: a lossless format built for very high compression and decompression speed, trading some compression ratio."
extensions:
  - name: "LZ4 frame format"
    description: "Container for LZ4 block-compressed data with optional checksums and size fields"
    categories:
    - archive
    author: "Yann Collet"
    link: "https://github.com/lz4/lz4/blob/dev/doc/lz4_Frame_format.md"
  - name: "LZ4 block format"
    description: "Raw LZ4 compressed block layout used inside frames and by embedded users of the library"
    categories:
    - archive
    author: "Yann Collet"
    link: "https://github.com/lz4/lz4/blob/dev/doc/lz4_Block_format.md"
---

## LZ4

LZ4 is a lossless compression algorithm by Yann Collet that prioritizes speed.
It compresses and decompresses at very high rates, often limited by memory or
storage bandwidth rather than by the CPU, at a lower compression ratio than
algorithms such as gzip or xz. The same author later created Zstandard.

### Technical Notes

LZ4 is a byte-oriented LZ77-style scheme: data is encoded as sequences, each
with a token, optional literal bytes, and a match described by an offset and
length, with no separate entropy coding stage. This keeps decoding simple and
fast. The `.lz4` file extension normally refers to the LZ4 frame format, which
wraps a series of blocks with a header and optional content size, block and
content checksums, and an end mark. A frame begins with the magic number
`0x184D2204`, stored little-endian as the bytes `04 22 4D 18`. The frame
format and the underlying block format are both documented in the project
repository. A high-compression variant, LZ4HC, produces smaller output while
keeping the same decompression speed.

### Adoption

LZ4 is used in file systems, databases, in-memory caches, game engines, the
Linux kernel, and network and storage software where low latency matters. The
reference implementation provides a library and a command-line tool, and
bindings exist for many languages.

### Preservation And Security Notes

LZ4 files are well suited for fast, transient compression; for long-term
archival, a higher-ratio format such as xz or Zstandard may be preferable. Use
the frame checksums where possible, since the block format itself has no
integrity check. Decoders handling untrusted data should bound output size and
use a maintained library version.

### Further Reading

- LZ4 project: `https://github.com/lz4/lz4`
- Frame format: `https://github.com/lz4/lz4/blob/dev/doc/lz4_Frame_format.md`
- Block format: `https://github.com/lz4/lz4/blob/dev/doc/lz4_Block_format.md`
