---
overview: ".ply files are Polygon File Format (Stanford Triangle Format) models: a flexible 3D format for storing polygon meshes and scanned point data with arbitrary per-element properties, in ASCII or binary."
extensions:
  - name: "Stanford Triangle Format v1.0 plus MATLAB example functions"
    description: "Stanford Triangle Format v1.0 plus MATLAB example functions"
    categories:
    - 3d-graphics
    author: "Pascal Getreuer"
    file: ply3d.zip
    
  - name: "Autodesk Animator Polygon File Format"
    description: "Autodesk Animator Polygon File Format"
    categories:
    - 2d-graphics
    author: "Max Maischein"
    file: ply.zip
    deprecated: true    
---

## Polygon File Format (PLY)

PLY, also called the Stanford Triangle Format, was developed at Stanford to store
3D data from scanners, and it is widely used in 3D scanning, computer graphics
research, and geometry processing. Its distinguishing feature is a flexible,
self-describing header that lets a file declare exactly which properties each
element carries, so PLY can hold not just vertices and faces but also colors,
normals, texture coordinates, transparency, confidence values, and custom
per-vertex or per-face attributes.

A PLY file starts with an ASCII header beginning with the word `ply` and a format
line stating whether the body is ASCII or binary (and, for binary, the byte order).
The header then defines each "element" (such as `vertex` and `face`) with its count
and a list of typed `property` fields. The body supplies the data in that exact
layout. This design makes PLY equally suited to dense scanned point clouds and to
conventional polygon meshes.

### Strengths And Preservation Notes

PLY is favored where per-vertex attributes from scanning or analysis must be
preserved, which many simpler formats (like STL or basic OBJ) cannot represent. It
does not model scene hierarchy, animation, or materials beyond simple per-element
attributes. For preservation the ASCII form is the most self-explanatory, while the
binary form is far more compact for large clouds; recording which was used and the
property meanings keeps the data interpretable.

### Security Notes

Because element counts and property lists in the header drive parsing and
allocation, a reader handling untrusted PLY should validate counts against the
actual data size and check that face indices reference valid vertices.

### Further Reading

- PLY format description: `https://paulbourke.net/dataformats/ply/`
