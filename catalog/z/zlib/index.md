---
overview: "The zlib format is a compact wrapper around a DEFLATE stream, adding a two-byte header and an Adler-32 checksum; it is the compressed-data layer embedded inside PNG, PDF, HTTP, and many other formats."
extensions:
  - name: "ZLIB Compressed Data Format Specification version 3.3"
    description: "ZLIB Compressed Data Format Specification version 3.3"
    author: "Network Working Group"
    categories:
    - archive
    link: "http://www.ietf.org/rfc/rfc1950.txt"
---

## zlib Data Format

zlib is a compressed-data format rather than a file-archive format. It wraps a
DEFLATE-compressed stream (the same LZ77-plus-Huffman algorithm used by gzip and
inside ZIP) with a minimal two-byte header describing the compression method and
window size, and appends an Adler-32 checksum of the uncompressed data for
integrity verification. There is no file name, timestamp, or multi-file
structure — that framing is what distinguishes zlib from gzip.

Because it is small and self-checking, the zlib format is used as the
compression layer *inside* many other formats and protocols rather than as a
standalone file type. PNG image data, PDF stream objects, many network protocols,
Git object storage, and countless application data files carry zlib-wrapped
DEFLATE streams. The widely used zlib software library implements this format
along with raw DEFLATE and the gzip wrapper.

### Relationship To DEFLATE And gzip

Three closely related things are easy to confuse: raw DEFLATE (RFC 1951, no
framing), the zlib wrapper (RFC 1950, header plus Adler-32), and the gzip wrapper
(RFC 1952, magic bytes plus CRC-32 and size). They share the same compression
core but differ in framing and checksum, so a decoder must be told, or must
detect, which framing is present.

### Security Notes

As with any compressed data, software inflating untrusted zlib streams should
bound output size and memory to resist decompression bombs, and should verify the
Adler-32 checksum where end-to-end integrity matters.

### Further Reading

- RFC 1950 (zlib format): `https://datatracker.ietf.org/doc/html/rfc1950`
- zlib library home page: `https://www.zlib.net/`
