---
overview: ".3mf files are 3D Manufacturing Format files: a ZIP-based XML format for 3D printing models that includes geometry, colors, materials and print metadata."
extensions:
  - name: "3D Manufacturing Format"
    description: "Open ZIP/XML 3D model format designed for additive manufacturing"
    categories:
    - 3d-graphics
    - printer-formats
    author: "3MF Consortium"
    link: "https://3mf.io/specification/"
---

## 3MF

The 3D Manufacturing Format (3MF) is an open format for exchanging 3D models
between design software and 3D printers or slicers. It is developed by the 3MF
Consortium, whose members include major CAD and 3D printing companies, and was
created to address limitations of the older STL format, which stores only
untextured triangle geometry.

### Structure

A 3MF file is a ZIP archive that follows the Open Packaging Conventions (OPC),
the same container approach used by Office Open XML. The model itself is an XML
document, normally `3D/3dmodel.model`, with `[Content_Types].xml` and relationship
files describing the package. The core specification covers triangle meshes,
build items and transformations, units, and metadata. Official extensions add
materials and properties (colors, textures, composite materials), slices,
beam lattices, production information and other features. Because the parts are
separate files, thumbnails and textures can be stored in the same package.

### Adoption And Tooling

3MF is supported by Windows 3D Builder, many slicers and CAD systems, and
libraries such as lib3mf, which the consortium maintains as a reference
implementation. Its support for units, color and multiple objects in a single file
makes it a common alternative to STL and OBJ for printing workflows. Some slicers
store their own settings inside a 3MF project file as additional metadata.

### Preservation And Security Notes

The format is openly specified and uses standard ZIP and XML, which favors
long-term access. As with any ZIP-based format, software reading untrusted files
should validate archive entries and guard against oversized or malformed data.

### Further Reading

- 3MF specification: `https://3mf.io/specification/`
- 3MF Core Specification source: `https://github.com/3MFConsortium/spec_core`
