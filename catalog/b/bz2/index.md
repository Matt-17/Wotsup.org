---
overview: ".bz2 files are bzip2-compressed streams: a block-sorting compressor based on the Burrows-Wheeler transform that usually achieves higher ratios than gzip at the cost of speed."
extensions:
  - name: "Bzip 2 archives"
    description: "Bzip 2 archives"
    categories:
    - archive
    link: "http://www.bzip.org/docs.html"
    deprecated: true
---

## bzip2

bzip2 is a lossless compressor that typically compresses better than gzip,
particularly on text, at the cost of slower operation and higher memory use. A
`.bz2` file holds a single compressed stream and, like gzip, is not itself an
archiver, so it is commonly paired with tar to produce `.tar.bz2` archives.
Streams begin with the magic bytes `BZh` followed by a digit giving the block
size.

Rather than the LZ77 dictionary approach used by gzip, bzip2 works in blocks and
applies a pipeline of reversible transforms: the Burrows-Wheeler transform to
group similar byte sequences, a move-to-front transform, run-length encoding,
and finally Huffman coding. Because it operates on independent blocks, a bzip2
stream can be partially recovered around a corrupted block, and parallel
implementations can compress or decompress blocks concurrently.

### Status And Preservation Notes

bzip2 is stable and widely available, though newer compressors such as xz and
zstd often offer better ratio-versus-speed trade-offs, so bzip2's use in new
pipelines has declined. The common media type is `application/x-bzip2`. For
preservation it remains a reasonable, openly documented choice; keep the
original stream and verify integrity on decompression.

### Security Notes

As with any compressor, decompressing untrusted `.bz2` data can expand to far
more than the stored size, so extractors should bound output size and memory to
resist decompression bombs.

### Further Reading

- bzip2 project and documentation: `https://sourceware.org/bzip2/`
