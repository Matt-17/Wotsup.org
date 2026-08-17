---
overview: ".zst files are Zstandard-compressed streams: a modern lossless compressor offering a wide speed/ratio range, fast decompression, and trained dictionaries, increasingly a default in systems and packaging."
extensions:
  - name: "Zstandard (zstd) compressed data"
    description: "Modern fast lossless compression format with tunable levels and dictionary support"
    categories:
    - archive
    author: "Meta (Yann Collet) / IETF"
    link: "https://facebook.github.io/zstd/"
---

## Zstandard (zstd)

Zstandard is a modern lossless compression format, originally developed at Facebook
(Meta) by Yann Collet, the author of LZ4. Its design goal is to provide a very wide
range of compression levels — from very fast (competitive with LZ4) to high ratio
(competitive with or better than gzip and, at high levels, approaching xz) — while
keeping decompression consistently fast regardless of the level used. That
flexibility has made it a common default in Linux distributions, package managers,
file systems, and network protocols.

A `.zst` stream stores data compressed with an LZ77-style match finder combined with
a fast entropy stage (finite state entropy and Huffman coding), framed with a magic
number, optional content-size and checksum fields, and block structure. A standout
feature is dictionary compression: zstd can be trained on a corpus of small, similar
files to build a dictionary that dramatically improves the ratio when compressing
many small payloads — valuable for databases, logs, and RPC.

### Use And Preservation Notes

Like gzip and bzip2, zstd compresses a stream rather than bundling files, so it is
paired with tar (`.tar.zst`) for archives. It is standardized in RFC 8878, which
supports its use as a durable, openly specified format; the reference implementation
is widely available. The common media type is `application/zstd`.

### Security Notes

Compressed data can expand greatly, so software decompressing untrusted `.zst`
streams should cap output size and memory to resist decompression bombs, and should
be careful that any attacker-supplied dictionary is handled safely.

### Further Reading

- Zstandard home page: `https://facebook.github.io/zstd/`
- RFC 8878 (Zstandard Compression): `https://datatracker.ietf.org/doc/html/rfc8878`
