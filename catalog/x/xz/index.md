---
overview: ".xz files are XZ-compressed streams: a general-purpose lossless container that usually holds LZMA2-compressed data and is widely used for source tarballs and software packages."
extensions:
  - name: "XZ compressed data"
    description: "Lossless compression container, normally using LZMA2, with integrity checks and an index"
    categories:
    - archive
    author: "Lasse Collin (The Tukaani Project)"
    link: "https://tukaani.org/xz/xz-file-format.txt"
---

## XZ

XZ is a compression file format and the associated tools from the Tukaani
Project, created by Lasse Collin. It compresses a single data stream and is
typically combined with tar (`.tar.xz`) to archive many files. The default
filter is LZMA2, which offers high compression ratios at the cost of slower
compression and higher memory use, while decompression remains comparatively
fast.

### Technical Notes

An `.xz` file begins with the six magic bytes `FD 37 7A 58 5A 00`
(`0xFD`, the text "7zXZ", and a null byte). The format is made of a stream
header, one or more blocks, an index, and a stream footer. Each stream
declares an integrity check, such as CRC32, CRC64, or SHA-256, and the index
allows random access to blocks and lets tools report the uncompressed size
without decompressing. Blocks can use a chain of filters, for example a
branch-call-jump filter for executable code before LZMA2. Concatenated
streams are valid. The format is documented in a public specification, and
the common media type is `application/x-xz`.

### Adoption

XZ is used for Linux kernel and many other source releases, and by various
package formats and distributions. Its main reference implementation is
liblzma with the `xz` command-line tool, and many archivers can read it.

### Preservation And Security Notes

XZ is a good fit for archival use because it is openly specified, includes
integrity checks, and compresses well. As with any compressed stream, a
damaged block can make later data unrecoverable, so keep checksums or
redundant copies. Software handling untrusted input should limit memory and
output size and keep xz libraries updated. In 2024 a backdoor was found in
the upstream xz release tarballs (CVE-2024-3094); this was a supply-chain
compromise rather than a flaw in the file format.

### Further Reading

- XZ Utils: `https://tukaani.org/xz/`
- The .xz file format specification: `https://tukaani.org/xz/xz-file-format.txt`
