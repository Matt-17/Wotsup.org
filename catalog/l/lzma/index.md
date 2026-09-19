---
overview: ".lzma files are LZMA-compressed streams in the legacy LZMA-alone format: a lossless compressed file with a small header, the predecessor of the .xz container."
extensions:
  - name: "LZMA alone (.lzma) compressed data"
    description: "Legacy single-stream container for LZMA-compressed data"
    categories:
    - archive
    author: "Igor Pavlov"
    link: "https://github.com/tukaani-project/xz/blob/master/doc/lzma-file-format.txt"
---

## LZMA

LZMA (Lempel-Ziv-Markov chain algorithm) is a compression algorithm designed
by Igor Pavlov, first used in the 7-Zip archiver. The `.lzma` file, sometimes
called the "LZMA alone" format, is a minimal container holding one stream of
LZMA-compressed data. It was used by early LZMA command-line tools before the
`.xz` format was introduced.

### Technical Notes

A `.lzma` file has a 13-byte header followed by the compressed data. The header
holds a properties byte that encodes the `lc`, `lp`, and `pb` parameters, a
four-byte dictionary size, and an eight-byte uncompressed size, which may be
set to all ones when the size is unknown, in which case the stream ends with
an end-of-payload marker. The format has no magic number and no integrity
check, so detection relies on plausible header values, and corrupted data may
go unnoticed. These limitations, along with a lack of extensibility, are among
the reasons the `.xz` format was created. The format is described in a text
document in the XZ Utils repository.

### Adoption

Modern tools usually produce `.xz` (which uses the improved LZMA2 algorithm)
instead, but `.lzma` files are still readable by XZ Utils (`xz --format=lzma`,
`unlzma`), 7-Zip, and various libraries. The LZMA algorithm itself continues
in use inside 7z and xz containers.

### Preservation And Security Notes

Because `.lzma` files lack checksums, consider converting important data to
`.xz` with an integrity check, or store separate hashes. Decompressors for
untrusted data should limit memory according to the declared dictionary size
and cap the output size.

### Further Reading

- LZMA file format (XZ Utils): `https://github.com/tukaani-project/xz/blob/master/doc/lzma-file-format.txt`
- XZ Utils: `https://tukaani.org/xz/`
