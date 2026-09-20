---
overview: ".fbx files are Autodesk FBX 3D files: a proprietary format for exchanging 3D models, materials, skeletons, and animation between content creation tools and game engines."
extensions:
  - name: "Autodesk FBX"
    description: "Proprietary 3D interchange format for geometry, materials, rigs, and animation, in binary or ASCII form"
    categories:
    - 3d-graphics
    - game-files
    author: "Autodesk (originally Kaydara)"
    link: "https://aps.autodesk.com/developer/overview/fbx-sdk"
---

## Autodesk FBX

FBX is a 3D file format owned by Autodesk, originally created by Kaydara for
its motion capture software Filmbox, which gave the format its name. Alias
acquired Kaydara in 2004, and Autodesk acquired Alias in 2006. The format carries meshes, materials, texture
references, cameras, lights, skeletons, skinning, blend shapes, and
animation, and is widely used to move assets between tools such as Maya, 3ds
Max, MotionBuilder, Blender, Unity, and Unreal Engine.

### Technical Notes

FBX exists in a binary and an ASCII variant. Binary files begin with the text
`Kaydara FBX Binary` followed by a null-padded header and a version number,
with data stored as a tree of nodes holding properties. The format has had
many versions, and files from newer versions are not always readable by older
software. The format is proprietary and not published as an open
specification; Autodesk provides the FBX SDK for reading and writing it under
its own license terms. Other tools rely on this SDK or on reverse-engineered
readers.

### Adoption

FBX is a de facto standard in game development and animation workflows,
particularly for characters and animation. Its closed nature and
inconsistent implementations between tools can lead to differences in
materials, units, or axis conventions, so open formats such as glTF or USD
are often used for delivery.

### Preservation And Security Notes

Because FBX is proprietary and versioned, archive the original authoring
files in addition to FBX exports, and record the FBX version and the
exporting application. As with other complex binary formats, importers can
contain memory-safety bugs, so handle untrusted FBX files with up-to-date
software.

### Further Reading

- Autodesk FBX SDK overview: `https://aps.autodesk.com/developer/overview/fbx-sdk`
