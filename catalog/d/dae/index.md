---
overview: ".dae files are COLLADA (COLLAborative Design Activity) documents: an XML-based 3D asset exchange format maintained by the Khronos Group."
extensions:
  - name: "COLLADA Digital Asset Exchange"
    description: "XML-based 3D scene and asset interchange format from Khronos"
    categories:
    - 3d-graphics
    - game-files
    author: "Khronos Group"
    link: "https://www.khronos.org/collada/"
---

## DAE

COLLADA is an XML-based interchange format for 3D assets, with `.dae` (Digital
Asset Exchange) as its file extension. It was originally created by Sony Computer
Entertainment and is now managed by the Khronos Group. Its goal is to let content
creation tools, game engines and viewers exchange assets without a proprietary
format. It has also been published as ISO/PAS 17506.

### Structure

A COLLADA document is a single XML file whose root element is `<COLLADA>`. It
holds libraries of elements such as geometries, materials, effects, images,
cameras, lights, controllers (skinning and morphing) and animations, along with
visual scenes that arrange them in a node hierarchy. Physics scenes are also
supported. Versions 1.4.1 and 1.5.0 are the most widely seen. Textures are
normally referenced as external image files, so a model may depend on files beside
the `.dae`; archive-based packaging (`.zae`) exists for bundling them.

### Adoption And Tooling

COLLADA is supported by Blender, Autodesk tools, SketchUp, Assimp, Unity and many
other applications and libraries, and was used for Google Earth models. Newer
work has shifted to glTF, also from Khronos, which targets efficient runtime
delivery, while COLLADA remains common for older assets and interchange between
digital content creation tools. Exporter quality varies, so check units, axis
orientation and materials after a transfer.

### Preservation And Security Notes

The format is open and human-readable XML, which helps long-term access. Keep
referenced textures with the file. As with any XML input, parsers handling
untrusted files should disable external entity resolution.

### Further Reading

- COLLADA overview (Khronos): `https://www.khronos.org/collada/`
- COLLADA 1.5.0 specification (PDF): `https://www.khronos.org/files/collada_spec_1_5.pdf`
