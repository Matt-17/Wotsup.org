---
overview: ".arj files are ARJ archives: a DOS-era compressed archive format (Archived by Robert Jung) notable for multi-volume splitting and good compression for its time, now largely obsolete."
extensions:
  - name: "ARJ File Format"
    description: "ARJ File Format"
    categories:
    - archive
    author: "Robert Jung"
    file: arj.zip
    deprecated: true
---

## ARJ Archive

ARJ ("Archived by Robert Jung") was a popular compressed archive format on
MS-DOS during the early 1990s, competing with ZIP, LHA, and PKARC. It bundles
files with compression and was known for achieving strong ratios for its era and
for practical features aimed at floppy-disk distribution. Archives begin with the
marker bytes `60 EA`.

Its standout feature was robust multi-volume support: a large archive could be
split across several floppies as numbered volumes (`.arj`, `.a01`, `.a02`, …),
with the tooling prompting for each disk. ARJ also offered self-extracting
archives, file comments, and data recovery options that suited the media of the
time.

### Status And Preservation Notes

ARJ is now obsolete, encountered mainly in legacy software collections and
bulletin-board-era downloads. It is still readable by several open archive tools
(for example 7-Zip and the free `arj`/`unarj` utilities), which is what matters
for extraction and preservation. For long-term access, migrate content out of
ARJ into an open, actively supported archive format while retaining the original.

### Security Notes

Legacy archivers can have parsing weaknesses, so extract untrusted `.arj` files
with a maintained tool, validate stored paths against traversal, and bound
output size to guard against oversized expansion.

### Further Reading

- ARJ format overview: `https://en.wikipedia.org/wiki/ARJ`
