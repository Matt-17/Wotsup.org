---
overview: ".rtf files are Rich Text Format documents: a plain-text document interchange format from Microsoft that encodes formatted text, images, and objects using backslash control words, readable across many word processors."
extensions:
  - name: "Rich Text File Format v1.5 (MS Word)"
    description: "Rich Text File Format v1.5 (MS Word)"
    categories:
    - documents
    author: "Microsoft Corporation"
    file: rtf15.zip
    
  - name: "Rich Text File Format v1.8"
    description: "Rich Text File Format v1.8"
    categories:
    - documents
    author: "Microsoft Corporation"
    file: rtf18.zip
    
  - name: "Word 97 Addendum (MS Word)"
    description: "Word 97 Addendum (MS Word)"
    categories:
    - documents
    author: "Microsoft Corporation"
    file: rtfadd97.zip
    
  - name: "Rich Text File Format v1.7 (MS Word)"
    description: "Rich Text File Format v1.7 (MS Word)"
    categories:
    - documents
    author: "Microsoft Corporation"
    file: rtf17.zip
    
---

## Rich Text Format (RTF)

RTF is a document interchange format introduced by Microsoft so formatted text
could move between different word processors and platforms. Unlike the binary
`.doc` format, an RTF file is plain ASCII text: formatting is expressed with
control words beginning with a backslash (such as `\b` for bold or `\par` for a
paragraph break) and grouping braces `{` and `}`. A file starts with the
signature `{\rtf1`, and non-ASCII characters are encoded with escapes, keeping
the file 7-bit safe.

Beyond basic character and paragraph formatting, RTF can carry fonts and color
tables, tables, styles, headers and footers, fields, embedded images, and OLE
objects. Because it is text-based and widely implemented, it has long served as
a "lowest common denominator" for exchanging formatted documents and as a
clipboard format for rich text.

### Compatibility Notes

The RTF specification evolved through numbered versions, and applications
implement different subsets, so a document may render slightly differently or
lose advanced features when opened in another program. For maximum
interoperability, RTF exports tend to favor widely supported control words over
newer or vendor-specific extensions. The common media type is `application/rtf`
(also `text/rtf`).

### Security Notes

Although the outer format is readable text, RTF can embed OLE objects and linked
content, and historically RTF files have been used as a vector for exploits that
target the parser or embedded object handlers. Treat RTF from untrusted sources
as active content: disable automatic object activation and use an up-to-date,
hardened reader.

### Further Reading

- Rich Text Format overview: `https://en.wikipedia.org/wiki/Rich_Text_Format`
