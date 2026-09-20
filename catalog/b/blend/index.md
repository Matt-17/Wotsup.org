---
overview: ".blend files are Blender project files: the native format of the open source Blender 3D suite, storing scenes, models, materials, animation, and more in a single file."
extensions:
  - name: "Blender project file"
    description: "Native file format of the Blender 3D creation suite"
    categories:
    - 3d-graphics
    - video-animation
    author: "Blender Foundation"
    link: "https://docs.blender.org/manual/en/latest/files/blend/index.html"
---

## Blender (.blend)

A `.blend` file is the native save format of Blender, the free and open
source 3D creation suite maintained by the Blender Foundation and community.
One file can hold all the data of a project: objects and meshes, materials,
textures, lights, cameras, animation, rigging, simulations, video editing
sequences, and the user interface layout. Blender also creates `.blend1`
backup files when saving over an existing file.

### Technical Notes

A `.blend` file starts with the magic bytes `BLENDER` followed by header
fields that indicate pointer size, endianness, and the version of Blender
that wrote it. The body is a sequence of data blocks, each with a block header
and raw memory-like contents, together with a `DNA` block that describes the
data structures used. This design lets newer and older Blender versions read
each other's files within certain limits. Files may be compressed, and
external assets such as images can be packed inside the file or linked by
path.

### Adoption

Blender can open files from earlier versions, but files saved by newer
versions may lose features when opened in older ones. Other software
generally relies on import and export through formats such as glTF, FBX, OBJ,
or USD rather than reading `.blend` files directly. Blender also uses `.blend`
files as asset libraries.

### Preservation And Security Notes

Record the Blender version used, since long-term compatibility is best with
Blender itself, and export to open formats such as glTF or USD for exchange.
Embedded Python scripts can run automatically when a file is opened if
auto-run is enabled, so keep "Auto Run Python Scripts" disabled for files from
untrusted sources.

### Further Reading

- Blender manual, Blend files: `https://docs.blender.org/manual/en/latest/files/blend/index.html`
- Blender: `https://www.blender.org/`
