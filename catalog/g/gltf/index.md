---
overview: ".gltf and .glb files are glTF (GL Transmission Format) assets: a modern, runtime-oriented 3D format for efficiently delivering scenes and models — geometry, materials, textures, animation, and PBR shading — to engines and the web."
extensions:
  - name: "glTF (GL Transmission Format)"
    description: "Royalty-free runtime 3D asset format for scenes and models, with JSON (.gltf) and binary (.glb) forms"
    categories:
    - 3d-graphics
    - internet
    author: "The Khronos Group"
    link: "https://www.khronos.org/gltf/"
---

## glTF (GL Transmission Format)

glTF is a modern 3D asset format from the Khronos Group, often described as "the
JPEG of 3D," designed for the efficient transmission and runtime loading of 3D
scenes and models. Unlike authoring/interchange formats aimed at editing, glTF is
optimized to be loaded directly by engines and browsers: its structure maps
closely onto how GPUs and real-time renderers consume data, minimizing the work an
application must do at load time.

A glTF asset describes a full scene graph: nodes with transforms, meshes,
materials using physically based rendering (PBR), textures, cameras, skins for
skeletal animation, and keyframe animations. It comes in two serializations. The
`.gltf` form is a JSON document that references external binary buffers (`.bin`)
and image files, while the `.glb` form packs the JSON, binaries, and textures into
a single self-contained binary file — convenient for distribution. An extension
mechanism lets vendors and the community add features (such as compression or
advanced materials) without breaking the core.

### Adoption

glTF 2.0 is widely supported across game engines, 3D web frameworks, model
viewers, AR/VR platforms, and content pipelines, making it a common target for
delivering 3D content to end users. The media types are `model/gltf+json` for
`.gltf` and `model/gltf-binary` for `.glb`.

### Preservation And Security Notes

glTF is open, documented, and (in JSON form) partly human-readable, which suits it
for interchange and archiving of runtime assets; keep external buffers and textures
with a `.gltf`, or prefer the self-contained `.glb`. As a format that references
external resources and carries binary buffers, a loader handling untrusted assets
should validate buffer and accessor bounds and constrain external and data-URI
fetches.

### Further Reading

- glTF overview (Khronos): `https://www.khronos.org/gltf/`
- glTF 2.0 specification: `https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html`
