---
overview: ".usd files are Universal Scene Description scenes: a framework and file format from Pixar for describing, composing, and exchanging large 3D scenes, with .usda (text) and .usdc (binary crate) as related forms."
extensions:
  - name: "Universal Scene Description (USD)"
    description: "Pixar 3D scene description format; .usd may hold either text or binary data, .usda is text and .usdc is binary"
    categories:
    - 3d-graphics
    author: "Pixar Animation Studios / Alliance for OpenUSD"
    link: "https://openusd.org/release/index.html"
---

## Universal Scene Description (USD)

Universal Scene Description, or OpenUSD, is a system developed by Pixar
Animation Studios for building and interchanging 3D scenes. It was released as
open source in 2016 and is now stewarded by the Alliance for OpenUSD (AOUSD).
Rather than being only a model format, USD provides a scene graph and a
composition engine that lets many artists layer, reference, and override
parts of a scene non-destructively.

### Technical Notes

USD files come in several encodings. `.usda` is human-readable text, `.usdc`
is a compact binary "crate" format, and `.usd` is a generic extension that may
contain either, so tools detect the actual encoding when opening it. A binary
crate file starts with the identifier `PXR-USDC`. Scenes consist of layers
containing prims (objects) with typed attributes and relationships, and
composition arcs such as sublayers, references, payloads, variants, and
inherits combine layers into a final stage. Schemas define types such as
meshes, materials, lights, and cameras. A related `.usdz` package bundles a
scene with its textures for distribution.

### Adoption

USD is used in film and visual effects pipelines and is supported by tools
including Houdini, Maya, Blender, NVIDIA Omniverse, and Apple platforms. The
open source runtime is available with C++ and Python APIs.

### Preservation And Security Notes

The `.usda` text form is the best choice for inspection and long-term
storage, while `.usdc` suits performance. Scenes frequently reference
external files by path, so archive those assets together or package them as
`.usdz`. Treat files from unknown sources carefully, as USD scenes can
reference external paths.

### Further Reading

- OpenUSD documentation: `https://openusd.org/release/index.html`
- Alliance for OpenUSD: `https://aousd.org/`
