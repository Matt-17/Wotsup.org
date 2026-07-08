---
overview: ".rar files are RAR archives: a proprietary compressed archive format known for strong compression, solid archives, recovery records, multi-volume splitting, and AES encryption."
extensions:
  - name: "RAR 2.00 Format"
    description: "RAR 2.00 Format"
    categories:
    - archive
    author: "Koen Beets"
    file: rar_2.zip

  - name: "RAR version 2.02"
    description: "RAR version 2.02"
    categories:
    - archive
    author: "Eugene Roshal"
    file: rar202.zip
---

## RAR Archive

RAR is a proprietary archive format created by Eugene Roshal (the name stands for
"Roshal Archive"). It bundles files with compression and is valued for high
compression ratios and a set of robustness features aimed at reliable storage
and distribution of large data sets. The format is proprietary: the WinRAR/RAR
tools that create archives are commercial, while a freely redistributable
`unrar` decoder is provided so archives can be extracted broadly.

RAR supports "solid" archives that compress many files as one stream for better
ratios, optional recovery records and recovery volumes that can repair or
reconstruct damaged data, splitting an archive across multiple numbered volumes,
strong AES encryption of data and optionally file names, and Unicode names.

### Format Versions

There are two major on-disk formats. The older RAR4 format (signature
`Rar!\x1a\x07\x00`) is widely compatible, while RAR5 (`Rar!\x1a\x07\x01\x00`)
adds stronger encryption, larger dictionaries, and other improvements but is not
readable by pre-5.0 tools. Software should detect the version from the signature
rather than assume from the extension.

### Preservation And Security Notes

Because creation is proprietary, RAR is a less common choice for long-term
archiving than open formats such as ZIP, 7z, or tar; migrating important content
to an open format is often advisable. The common media type is
`application/vnd.rar`. As with any archive, extractors handling untrusted RAR
files should guard against path traversal, decompression bombs, and archives
that rely on encryption to conceal contents.

### Further Reading

- RARLAB (WinRAR / RAR): `https://www.rarlab.com/`
