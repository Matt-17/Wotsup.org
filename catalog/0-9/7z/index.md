---
overview: ".7z files are 7-Zip archives: a container that bundles files with strong, method-flexible compression (notably LZMA/LZMA2), optional solid compression, and AES-256 encryption."
extensions:
  - name: "7Zip LZMA Compression SDK"
    description: "7Zip LZMA Compression SDK"
    categories:
    - archive
    author: "Igor Pavlov"
    link: "http://www.7-zip.org/sdk.html"
---

## 7z Archive

The `.7z` format is the native archive of the 7-Zip project. It is a general
container that stores many files and directories as one archive while applying
compression, and it is popular because it typically achieves higher compression
ratios than older ZIP tooling on the same data. The format is open and the
reference implementation, including the LZMA SDK, is publicly available.

7z separates the archive container from the compression method, so a single
`.7z` file can use different codecs for different data. The default is LZMA or
LZMA2, but the format also supports BZip2, PPMd, Deflate, and filters such as
delta and BCJ (executable branch conversion) that improve compression of
specific content. Files begin with the signature bytes `37 7A BC AF 27 1C`.

### Features

7z supports "solid" compression, where multiple files are compressed together
as one stream to exploit redundancy between them, at the cost of slower random
extraction. It also offers AES-256 encryption of both file data and, optionally,
the archive header (hiding file names), split/multi-volume archives, and full
Unicode file names.

### Preservation And Security Notes

The common media type is `application/x-7z-compressed`. For preservation, keep
the original archive rather than re-compressing, and record whether encryption
or solid compression was used. Because archives can expand to far more than
their stored size, tools that extract untrusted `.7z` files should guard against
decompression bombs, path-traversal ("zip slip") entries, and excessive memory
use from large dictionaries.

### Further Reading

- 7-Zip and the 7z format: `https://www.7-zip.org/7z.html`
- LZMA SDK: `https://www.7-zip.org/sdk.html`
