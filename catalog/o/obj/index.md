---
overview: ".obj files are Wavefront OBJ 3D models: a widely supported text format describing mesh geometry — vertices, texture coordinates, normals, and faces — usually paired with a .mtl material file."
extensions:
  - name: "Source Code to read Wavefront .OBJ files"
    description: "Source code to read wavefront (alias/maya) .OBJ files"
    categories:
    - 3d-graphics
    author: "Steve Britton"
    file: objsrc.zip
    
  - name: "Videoscape File Specs"
    description: "Videoscape file specs"
    categories:
    - 2d-graphics
    - 3d-graphics
    author: "Max Gilead"
    file: videoscape.zip
    
  - name: "C++ Code for reading OBJ files"
    description: "C++ Code for reading OBJ files"
    categories:
    - binaries
    author: "VenTure"
    file: objfile.zip
    
  - name: "Wavefront Object files"
    description: "Wavefront Object files (Acrobat)"
    categories:
    - 3d-graphics
    file: w_obj.zip
    
  - name: "Macro Assembler and MS C Compiler Object Files"
    description: "Macro Assembler and MS C Compiler Object Files"
    categories:
    - binaries
    file: object.zip
    
  - name: "OBJ Specification"
    description: "OBJ Specification"
    categories:
    - binaries
    author: "Microsoft Corporation"
    file: ss_obj.zip
    
---

## Wavefront OBJ

The Wavefront OBJ format is one of the most broadly supported 3D geometry
interchange formats, originally from Wavefront Technologies' Advanced Visualizer.
It is a plain-text format that describes the geometry of one or more 3D objects,
and its long history and simplicity mean nearly every 3D modeling, rendering, and
game tool can read and write it.

An OBJ file lists geometric data one item per line, tagged by a keyword: `v` for a
vertex position, `vt` for a texture coordinate, `vn` for a vertex normal, and `f`
for a face that references those elements by index. It also supports free-form
curves and surfaces, smoothing groups, and named objects and groups. OBJ itself
stores only geometry; surface appearance is defined separately in a companion
Material Template Library (`.mtl`) file, referenced with `mtllib` and `usemtl`,
which specifies colors, shininess, and texture image maps.

### Strengths And Limitations

OBJ is excellent for static meshes and is a common lowest-common-denominator for
model exchange. It does not, however, represent animation, skeletons, scene
hierarchy, or cameras and lights, so for rigged or scene-level data richer formats
such as glTF or FBX are used instead. Being text, OBJ files can be large compared
with binary formats.

### Preservation And Security Notes

OBJ's open, text-based nature suits preservation of mesh geometry; keep the `.mtl`
and referenced texture images alongside the `.obj`, since materials and maps are
external. A parser reading untrusted OBJ should validate that face indices fall
within the declared vertex ranges to avoid out-of-bounds access.

### Further Reading

- Wavefront OBJ format overview: `https://en.wikipedia.org/wiki/Wavefront_.obj_file`
