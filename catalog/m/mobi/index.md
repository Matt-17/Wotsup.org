---
overview: ".mobi files are Mobipocket e-books: a PalmDOC-based e-book format used for Amazon Kindle devices, with .prc as a related extension and .azw/.azw3 as Amazon's later variants."
extensions:
  - name: "Mobipocket e-book (MOBI)"
    description: "E-book format stored in a Palm database container, used by Mobipocket and older Kindles"
    categories:
    - documents
    author: "Mobipocket SA / Amazon"
    link: "https://wiki.mobileread.com/wiki/MOBI"
---

## MOBI

MOBI is the e-book format of Mobipocket, a company that Amazon acquired in
2005. Amazon built its early Kindle formats on it. The format was never published
as an official specification; the best documentation comes from the community,
for example the MobileRead wiki, which describes the structure through reverse
engineering.

### Structure

A MOBI file is a Palm Database (PDB) file. The header holds a database name, a
type and creator pair that reads `BOOKMOBI` at byte offset 60, and a record list.
The first record holds a PalmDOC header (compression type and text length),
the MOBI header (encoding, version, indexes, and offsets), and optional EXTH
header records for metadata such as author, title, and publisher. The following
records hold the book text, which is HTML-like markup compressed with PalmDOC
(LZ77-style) compression or, in some versions, HUFF/CDIC, plus images and
indexes.

### Adoption

MOBI was widely read by older Kindle devices and by e-book software such as
Calibre, and many e-book stores once sold it. Newer devices and apps prefer
newer formats such as KF8/AZW3 and EPUB. Files may be protected with DRM, which
makes them readable only on authorized devices.

### Preservation And Security Notes

MOBI has limited support for modern HTML and CSS and no formal specification,
so for long-term storage it is better to keep an EPUB or source copy when
possible. DRM-protected files cannot be preserved or migrated without
authorization. Parsers should validate record offsets and decompressed sizes.

### Further Reading

- MOBI (MobileRead Wiki): `https://wiki.mobileread.com/wiki/MOBI`
