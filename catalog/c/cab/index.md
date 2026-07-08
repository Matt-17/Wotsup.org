---
overview: ".cab files are Microsoft Cabinet archives: a compressed container used throughout Windows for installers, drivers, and system components, supporting multiple compression methods and multi-cabinet spanning."
extensions:
  - name: "MS CAB file format with source"
    description: "MS CAB file format with source"
    categories:
    - windows
    - binaries
    - archive
    file: cab.zip
    
---

## Microsoft Cabinet (CAB)

The Cabinet format is Microsoft's native compressed archive, used extensively in
Windows software distribution: application setups, device driver packages,
Windows Update payloads, and the internals of other package formats all rely on
`.cab`. A cabinet stores one or more files, compressed, together with a
directory describing them, and starts with the signature `MSCF`.

Internally a cabinet is organized into "folders" (compression units) and files.
Each folder holds a compressed data stream, and files are stored as ranges
within a folder, so several small files can share one compression context.
CAB supports the MSZIP (a DEFLATE variant), LZX, and Quantum compression
methods, with MSZIP and LZX being the ones in common use.

### Spanning And Related Formats

Cabinets can span multiple files: a file too large for one cabinet, or a set
split for distribution across media, continues into subsequent numbered
cabinets that are logically read as a set. The CAB structure also underlies
self-extracting installers and is referenced by other Microsoft packaging
formats, so a `.cab` is frequently encountered embedded inside larger installers
rather than on its own.

### Preservation And Security Notes

The common media type is `application/vnd.ms-cab-compressed`, and open tools such
as `cabextract` can read cabinets on non-Windows systems. As a compressed
container feeding software installation, untrusted cabinets warrant the usual
archive precautions — validated paths, bounded expansion, and integrity checks —
and should be treated as potential carriers of executable content.

### Further Reading

- Microsoft Cabinet format specification: `https://learn.microsoft.com/previous-versions/bb417343(v=msdn.10)`
- cabextract project: `https://www.cabextract.org.uk/`
