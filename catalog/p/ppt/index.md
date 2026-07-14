---
overview: ".ppt files are Microsoft PowerPoint binary presentations: a legacy slide-deck format stored in the OLE Compound File container, holding slides, layouts, embedded media, and animations."
extensions:
  - name: "Microsoft Powerpoint 97 Format"
    description: "Microsoft Powerpoint 97 Format"
    categories:
    - documents
    author: "Microsoft Corp."
    file: powerpoint97.zip
---

## Microsoft PowerPoint Presentation (.ppt)

The `.ppt` extension denotes a Microsoft PowerPoint presentation in the binary
format that was the application's default through PowerPoint 2003. Like the binary
`.doc` and `.xls` formats, a `.ppt` is stored inside an OLE Compound File
(Structured Storage): named streams within the container hold the presentation
document, the slides and their placeholders, embedded pictures and media, and
associated metadata. It shares the compound-file signature
`D0 CF 11 E0 A1 B1 1A E1` with other Office binary formats.

A presentation stores an ordered set of slides with text, shapes, tables, charts,
images, notes, master slides and layouts, transitions, and animations, and can
embed OLE objects and VBA macros. From PowerPoint 2007 onward the default became
the XML-based, ZIP-packaged `.pptx` (Office Open XML), making `.ppt` the legacy
binary format and `.pptx` the modern successor.

### Preservation And Security Notes

Because a binary presentation can contain VBA macros, embedded objects, and linked
media, treat untrusted `.ppt` files as potential active content and open them with
macros disabled. For preservation, migrating to Office Open XML, ODF, or exporting
to PDF while keeping the original is sensible, since faithful rendering depends on
PowerPoint's layout, embedded fonts, and media codecs.

### Further Reading

- [MS-PPT] PowerPoint (.ppt) Binary File Format: `https://learn.microsoft.com/openspecs/office_file_formats/ms-ppt/`
