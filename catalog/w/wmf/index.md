---
overview: ".wmf files are Windows Metafiles: a vector graphics format that stores a sequence of Windows GDI drawing commands, used for clip art and scalable graphics in older Windows applications."
extensions:
  - name: "Windows Metafile Format"
    description: "Windows Metafile Format"
    categories: 
    - 2d-graphics
    - windows
    author: "Microsoft Corp."
    file: metafile.zip
    
  - name: "Windows Metafile Format"
    description: "Windows Metafile Format WMF/EMF/APM (html)"
    categories:  
    - 2d-graphics
    - windows
    author: "O'Reilly & Associates, Inc."
    file: wmf.zip
    
  - name: "More information on WMF files"
    description: "More information on WMF files"
    categories:  
    - 2d-graphics
    - windows
    author: "Caolan McNamara"
    link: "http://www.csn.ul.ie/~caolan/docs/libwmf.html"
    deprecated: true
---

## Windows Metafile (WMF)

WMF is a graphics format native to Microsoft Windows that stores an image as a
recorded list of Graphics Device Interface (GDI) drawing commands — move to a
point, draw a line, select a pen or brush, output text — rather than as a grid of
pixels. Because it replays drawing operations, a metafile can represent vector
artwork that scales, which is why WMF was the standard format for Office clip art
and for exchanging drawings between older Windows programs.

WMF is a 16-bit format reflecting its origins in early Windows. A standalone WMF
intended for interchange usually has a "placeable" header (the Aldus/APM header,
magic `D7 CD C6 9A`) that adds a bounding rectangle and unit information the base
format lacks. Its 32-bit successor, the Enhanced Metafile (EMF), is generally
preferred for newer work.

### Status And Security Notes

WMF is a legacy format, still recognized by Windows and many graphics tools but
rarely chosen for new content. It carries notable security history: because
metafile records could invoke device functions, WMF handling was the basis of
serious Windows exploits (notably the SETABORTPROC/Escape vulnerability). Software
that renders untrusted metafiles should use hardened, updated code and disable the
ability of records to invoke arbitrary callbacks.

### Preservation Notes

For preservation, converting WMF artwork to a modern vector format such as SVG (or
EMF within Windows workflows) while retaining the original is advisable, since
faithful rendering depends on Windows GDI semantics and available fonts.

### Further Reading

- [MS-WMF] Windows Metafile Format: `https://learn.microsoft.com/openspecs/windows_protocols/ms-wmf/`
