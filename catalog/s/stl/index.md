---
overview: ".stl files are stereolithography meshes: a simple 3D format that describes a surface as a collection of triangular facets, ubiquitous in 3D printing and rapid prototyping."
extensions:
  - name: "STL and SLC formats for rapid prototyping"
    description: "STL and SLC formats for rapid prototyping"
    categories:
    - 3d-graphics
    file: stl.zip
    deprecated: true
---

## Stereolithography (STL)

STL is a 3D geometry format originally created for stereolithography (an early 3D
printing process) and now the de facto standard interchange format for 3D printing
and rapid prototyping generally. Its enduring appeal is simplicity: it describes
the surface of a solid object as a "triangle soup" — an unstructured list of
triangular facets, each given by its three corner vertices and a facet normal —
with no color, material, units, or topology information.

STL comes in two encodings. The ASCII form spells out each facet in readable
`facet normal ... outer loop ... vertex ...` blocks. The binary form, which is far
more compact and common, has an 80-byte header, a 4-byte triangle count, and a
fixed 50-byte record per triangle. Both describe exactly the same geometry.

### Limitations And Preservation Notes

Because STL stores only bare triangles, it does not carry units (a frequent source
of scaling errors between tools), color, or any guarantee that the mesh forms a
closed, "watertight" solid — non-manifold edges and gaps are common and must be
repaired before printing. For richer needs, formats like 3MF, OBJ, PLY, or glTF
carry color, materials, and metadata. For preservation, keep the source CAD model
where possible, since STL is a derived, lossy tessellation of it.

### Security Notes

Given a binary STL's declared triangle count drives allocation and reads, a parser
handling untrusted files should validate that count against the actual file size to
avoid over-allocation or out-of-bounds reads.

### Further Reading

- STL format overview: `https://en.wikipedia.org/wiki/STL_(file_format)`
