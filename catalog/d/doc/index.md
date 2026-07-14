---
overview: ".doc files are usually Microsoft Word binary documents: a legacy word-processing format stored in the OLE Compound File (Structured Storage) container holding formatted text, images, and embedded objects."
extensions:
  - name: "Palm Pilot DOC files"
    description: "Palm Pilot DOC files"
    categories:
    - documents
    author: "Rob Tillotson"
    link: "http://www.concentric.net/~n9mtb/cq/doc/format.html"
    deprecated: true
    
  - name: "Microsoft Word 6.0 Binary File Format (MS Word)"
    description: "Microsoft Word 6.0 Binary File Format (MS Word)"
    categories:
    - documents
    file: word60t.zip
    deprecated: true
    
  - name: "Microsoft Word 6.0 Binary File Format (as TXT file)"
    description: "Microsoft Word 6.0 Binary File Format (as TXT file)"
    categories:
    - documents
    file: wword60t.zip
    deprecated: true

  - name: "Microsoft Word 8/Word 97 Format - more complete version (HTML FILE)"
    description: "Microsoft Word 8/Word 97 Format - more complete version (HTML FILE)"
    categories:
    - documents
    file: wword8.zip
    
  - name: "Tools to analyse the file formats of Microsoft's OLE applications and to extract the text portion out of Word 6/7/8 files (perl)"
    description: "Tools to analyse the file formats of Microsoft's OLE applications and to extract the text portion out of Word 6/7/8 files (perl)"
    categories:
    - documents
    link: "http://user.cs.tu-berlin.de/~schwartz/pmh/"
    deprecated: true
    
  - name: "Palm Pilot DOC file format"
    description: "Palm Pilot DOC file format"
    categories:
    - documents
    author: "Paul J. Lucas"
    file: palmdoc.zip
    
  - name: "Microsoft Word 97 Format (including bidirectional support)"
    description: "Microsoft Word 97 Format (including bidirectional support)"
    categories:
    - documents
    author: "Microsoft Corp."
    file: Word97BiDirectional.zip
    
  - name: "Microsoft Word 2 Format (RTF)"
    description: "Microsoft Word 2 Format (RTF)"
    categories:
    - documents
    author: "Microsoft Corp."
    file: word2.zip
    
  - name: "Microsoft Word 5.0 (PC) Binary File Format"
    description: "Microsoft Word 5.0 (PC) Binary File Format"
    categories:
    - documents
    file: dosword5.zip
    
  - name: "Microsoft Word 8/Word 97 Format (HTML file)"
    description: "Microsoft Word 8/Word 97 Format (HTML file)"
    categories:
    - documents
    author: "Microsoft Corp."
    file: word8.zip
    
---

## Microsoft Word Document (.doc)

For most of its history the `.doc` extension has meant a Microsoft Word document
in Word's binary format, the default for Word up to and including Word 2003.
Rather than a flat file, a classic `.doc` is stored inside an OLE Compound File
(also called Structured Storage) — a small file system within a file, containing
named streams such as `WordDocument`, `1Table`/`0Table`, and `Data`. The
`WordDocument` stream begins with the File Information Block (FIB), which points
to the text and the formatting structures scattered through the streams.

A binary Word document can hold formatted text, styles, tables, images, fields,
revision tracking, embedded OLE objects, and VBA macro projects. In 2007 Word
switched its default to the XML-based, ZIP-packaged `.docx` (Office Open XML), so
`.doc` is now the legacy binary format while `.docx` is the modern one; the two
are structurally unrelated despite the similar names.

### Other Uses Of .doc

The extension is overloaded. It has also been used for Palm Pilot "DOC" e-book
files and, generically, for plain-text documents, so a `.doc` should be
identified by its content (for example the OLE compound-file signature
`D0 CF 11 E0 A1 B1 1A E1`) rather than by extension alone.

### Preservation And Security Notes

Because binary Word documents can embed VBA macros and OLE objects, an untrusted
`.doc` should be treated as potential active content: open with macros disabled
and object activation blocked. For preservation, migrating to an open, documented
format (Office Open XML, ODF, or PDF/A) while retaining the original is advisable,
since faithful rendering depends on Word's layout behavior and available fonts.

### Further Reading

- [MS-DOC] Word (.doc) Binary File Format: `https://learn.microsoft.com/openspecs/office_file_formats/ms-doc/`
- Compound File Binary Format [MS-CFB]: `https://learn.microsoft.com/openspecs/windows_protocols/ms-cfb/`
