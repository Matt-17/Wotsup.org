---
overview: ".usdz files are USDZ packages: uncompressed, zip-based archives that bundle a USD scene together with its textures and other assets for single-file distribution, notably for AR on Apple devices."
extensions:
  - name: "USDZ package"
    description: "Single-file, uncompressed ZIP-based package for a Universal Scene Description scene and its assets"
    categories:
    - 3d-graphics
    author: "Pixar Animation Studios / Apple"
    link: "https://openusd.org/release/spec_usdz.html"
---

## USDZ

USDZ is a packaging format for Universal Scene Description (USD). It stores a
USD scene and the files it depends on, such as textures and audio, in a single
archive. Pixar and Apple introduced it in 2018, and it is the format used for
AR Quick Look on iOS and macOS, where a `.usdz` file can be previewed in
augmented reality.

### Technical Notes

A USDZ file is a ZIP archive with restrictions defined in the OpenUSD
specification: entries are stored uncompressed and unencrypted, and their data
is aligned to 64-byte boundaries so that the contents can be read directly
from the file without extraction. The first file in the package must be a USD
file (`.usd`, `.usda`, or `.usdc`), which serves as the default layer. Other
files, such as PNG or JPEG images, are referenced from it. The package is
read-only by design, so edits require unpacking and repacking, for example
with the `usdzip` tool shipped with OpenUSD.

### Adoption

USDZ is supported by Apple operating systems, Safari, and Apple developer
tools, and by Blender, Adobe tools, NVIDIA Omniverse, and other 3D
applications through import and export. It is commonly used for product
visualization in AR. For web-oriented delivery in other ecosystems, glTF/GLB
is the main alternative.

### Preservation And Security Notes

Since a `.usdz` is a ZIP archive, it can be inspected with ordinary archive
tools, which makes it easy to recover the underlying scene and textures. Keep
the source scene files too, because the package is intended for delivery.
Software opening untrusted packages should validate archive entry names and
sizes.

### Further Reading

- USDZ File Format Specification: `https://openusd.org/release/spec_usdz.html`
- Apple AR Quick Look: `https://developer.apple.com/augmented-reality/quick-look/`
