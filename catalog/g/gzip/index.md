---
overview: ".gz files are gzip-compressed streams: a single data stream compressed with DEFLATE, wrapped in a small header and a CRC-32/length trailer, widely used on its own and to compress tar archives."
extensions:
  - name: "GZIP file format specification"
    description: "GZIP file format specification"
    categories:
    - archive
    author: "L. Peter Deutsch"
    file: gzip.zip
    deprecated: true
---

## gzip

gzip is one of the most widely used compression formats on Unix-like systems and
the web. A `.gz` file holds a single compressed stream: the payload is compressed
with the DEFLATE algorithm (LZ77 plus Huffman coding) and framed by a header and
a trailer. The header begins with the magic bytes `1f 8b`, notes the compression
method and flags, and can optionally carry the original file name and
modification time. The trailer stores a CRC-32 checksum and the original
(uncompressed) size modulo 2^32.

Because gzip compresses one stream rather than a set of files, it is not itself
an archiver. To package a directory it is combined with tar, producing
`.tar.gz` (or `.tgz`). The same DEFLATE core also underlies zlib and the
individual entries of ZIP archives, so these formats are closely related but
framed differently.

### Use And Preservation Notes

gzip is used for file compression, HTTP `Content-Encoding: gzip`, log rotation,
and countless data pipelines. The common media type is `application/gzip`. For
preservation, gzip is a good choice because it is simple, openly specified in
RFC 1952, and self-describing via its checksum and size trailer, which allow
integrity verification on decompression.

### Security Notes

Compressed data can expand dramatically, so software decompressing untrusted
`.gz` streams should cap output size and memory to avoid decompression bombs.
The optional stored file name is attacker-controlled metadata and should be
sanitized rather than used directly as an output path.

### Further Reading

- RFC 1952 (gzip file format): `https://datatracker.ietf.org/doc/html/rfc1952`
- The gzip home page: `https://www.gnu.org/software/gzip/`
