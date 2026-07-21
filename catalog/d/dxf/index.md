---
overview: ".dxf files are AutoCAD Drawing Exchange Format: an openly documented, tagged CAD interchange format (usually ASCII) for exchanging 2D and 3D drawings between AutoCAD and other CAD systems."
extensions:
  - name: "AutoCAD DXF version 13 File Format"
    description: "AutoCAD DXF version 13 File Format"
    categories:
    - 2d-graphics
    - cad
    author: "Autodesk Inc."
    file: dxf13.zip
    deprecated: true
    
  - name: "AutoCAD DXF version 14 File Format (Windows Help format)"
    description: "AutoCAD DXF version 14 File Format (Windows Help format)"
    categories:
    - 2d-graphics
    - cad
    author: "Autodesk Inc."
    file: dxf_r14.zip
    deprecated: true
    
  - name: "AutoCAD DXF version 14 File Format (html format)"
    description: "AutoCAD DXF version 14 File Format (html format)"
    categories:
    - 2d-graphics
    - cad
    author: "Autodesk Inc."
    file: dxf14htm.zip
    deprecated: true
    
  - name: "AutoCAD DXF version 12 File Format"
    description: "AutoCAD DXF version 12 File Format"
    categories:
    - 2d-graphics
    - cad
    author: "Autodesk Inc."
    file: dxf12.zip
    deprecated: true
    
  - name: "AutoCAD DXF version 10 File Format"
    description: "AutoCAD DXF version 10 File Format"
    categories:
    - 2d-graphics
    - cad
    author: "Autodesk Inc."
    file: dxf.zip
    deprecated: true
    
  - name: "Minimum Requirements for DXF Files"
    description: "Minimum Requirements for DXF Files"
    categories:
    - 2d-graphics
    - cad
    author: "Paul Bourke"
    file: dxf_make.zip
    deprecated: true
    
---

## Drawing Exchange Format (DXF)

DXF is a CAD data format created by Autodesk to exchange drawings between AutoCAD
and other programs. Where AutoCAD's native DWG is a proprietary binary format, DXF
was published as a documented interchange format, and it became a de facto standard
that most CAD, CAM, and GIS tools can read and write. It represents the same kinds
of content as a drawing: layers, line types, blocks, and geometric entities in 2D
and 3D.

Most DXF files are ASCII text organized as tagged pairs: each value is preceded by
an integer "group code" that says what the value means (for example, group code 10
introduces an X coordinate). The file is divided into sections — HEADER, TABLES,
BLOCKS, ENTITIES, and OBJECTS — that describe drawing settings, reusable
definitions, and the entities themselves. A binary DXF variant exists but is far
less common than the text form.

### Compatibility Notes

DXF is versioned in step with AutoCAD releases (R12, R13, ... and the AC10xx
formats), and newer entity types may not be understood by older readers, so tools
often export to an older DXF version for maximum compatibility. Round-tripping
complex drawings can lose application-specific data that DXF does not model.

### Preservation And Security Notes

DXF's open, text-based nature makes it a good archival interchange format for
vector CAD geometry; recording the DXF version and units aids later use. As tagged
text with cross-referenced handles, a parser handling untrusted files should guard
against malformed group codes, dangling references, and extremely large entity
counts.

### Further Reading

- AutoCAD DXF reference (Autodesk): `https://help.autodesk.com/view/ACD/2024/ENU/?guid=GUID-235B22E0-A567-4CF6-92D3-38A2306D73F3`
