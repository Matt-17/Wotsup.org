---
overview: ".dwg files are AutoCAD drawings: the proprietary native binary format of AutoCAD for storing 2D and 3D design data, geometry, and metadata, versioned across AutoCAD releases."
extensions:
  - name: "OpenDWG Alliance site"
    description: "OpenDWG Alliance site"
    categories:
    - 2d-graphics
    - cad
    link: "http://www.opendwg.org/"
    deprecated: true

  - name: "AutoCAD DWG File Format (in BFF Format)"
    description: "AutoCAD DWG File Format (in BFF Format)"
    categories:
    - 2d-graphics
    - cad
    author: "Frans F. J. Faase"
    file: dwg_ff.zip
    deprecated: true

  - name: "AutoCAD R13/R14 DWG File Specification Version 1.0 (RTF)"
    description: "AutoCAD R13/R14 DWG File Specification Version 1.0 (RTF)"
    categories:
    - 2d-graphics
    - cad
    author: "OpenDWG Alliance"
    file: dwg13_14.zip
    deprecated: true
---

## AutoCAD Drawing (DWG)

DWG is the native file format of Autodesk's AutoCAD and the dominant format for 2D
and 3D CAD data in architecture, engineering, and construction. A `.dwg` stores the
full drawing database: geometric entities, layers, line types and styles, blocks
(reusable symbol definitions), text, dimensions, and both drawing and metadata such
as units and named objects. It is a compact binary format optimized for CAD rather
than a text interchange format.

DWG is proprietary and tightly versioned with AutoCAD releases (for example the
AC1015, AC1021, AC1027, and AC1032 internal versions corresponding to specific
AutoCAD generations), and the binary structure changes between versions. The
signature at the start of the file identifies the version. Because Autodesk does
not publish a full open specification, broad third-party support has come largely
through the Open Design Alliance's reverse-engineered libraries.

### DWG And DXF

For exchanging drawings with software that cannot read DWG, the documented ASCII
DXF format serves as the interchange counterpart. DWG is the working/native format;
DXF is the portable export, usually at some loss of application-specific data.

### Preservation And Security Notes

Because DWG is proprietary and version-specific, long-term preservation carries
migration risk; keeping the native DWG together with an open derivative (DXF, or a
neutral format such as IFC/STEP for the relevant model type) reduces that risk.
Record the DWG version. As a complex binary format, DWG parsers should validate
offsets and object sizes from untrusted files to avoid memory-safety issues.

### Further Reading

- Open Design Alliance (DWG libraries): `https://www.opendesign.com/`
