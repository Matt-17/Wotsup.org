---
overview: ".tar files are Unix tape archives: an uncompressed container that concatenates many files and directories into one stream, preserving names, permissions, ownership, timestamps, and links."
extensions:
  - name: "TAR Archive File Format"
    description: "TAR Archive File Format"
    categories:
    - archive
    author: "Max Maischein"
    file: tar.zip
---

## TAR (Tape Archive)

The `.tar` format ("tape archive") originated as a way to write files to
sequential tape on Unix, and it remains the standard way to bundle a directory
tree into a single stream on Unix-like systems. A tar file simply concatenates
its members: each file is preceded by a 512-byte header block recording its
name, mode, owner and group, size, modification time, and type, followed by the
file contents padded to a multiple of 512 bytes.

Crucially, tar does not compress. It packages files, and compression is applied
separately by piping the archive through a compressor, which is why archives are
commonly seen as `.tar.gz` (gzip), `.tar.bz2` (bzip2), or `.tar.xz` (xz). This
separation of concerns — archiving versus compression — is a defining trait of
the format.

### Format Variants

Several header conventions coexist. The historic format was standardized as
POSIX `ustar`, which added fields such as user and group names and a magic
string. Long path names, large files, sparse files, and extended metadata are
handled by the GNU tar extensions and by the POSIX `pax` extended headers.
Because these variants differ, a robust extractor needs to recognize which
convention an archive uses.

### Preservation And Security Notes

Tar is well suited to preservation of file trees because the format is simple,
openly documented, and preserves POSIX metadata and symbolic/hard links. Tools
extracting untrusted tar files should reject absolute paths and `..` traversal
entries, be cautious with device nodes, symlinks, and hard links that could
escape the target directory, and limit resource use when the archive is
compressed.

### Further Reading

- GNU tar manual: `https://www.gnu.org/software/tar/manual/`
- POSIX pax/tar format (IEEE Std 1003.1): `https://pubs.opengroup.org/onlinepubs/9699919799/utilities/pax.html`
