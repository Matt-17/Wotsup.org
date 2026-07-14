---
overview: ".psd files are Adobe Photoshop documents: Photoshop's native format, preserving layers, masks, channels, adjustment layers, and other editable image data alongside a composite preview."
extensions:
  - name: "Adobe Photoshop 2.5 File Format"
    description: "Adobe Photoshop 2.5 File Format"
    categories:
    - 2d-graphics
    author: "Thomas Knoll"
    file: psd.zip
    deprecated: true
    
  - name: "Adobe Photoshop 3 and 4 File Formats"
    description: "Adobe Photoshop 3 and 4 File Formats"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: psd3_4.zip
    deprecated: true
    
  - name: "Adobe Photoshop 3 Plug-in format"
    description: "Adobe Photoshop 3 Plug-in format"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: ps_plug.zip
    deprecated: true
    
  - name: "Adobe Photoshop 6.0 File Formats"
    description: "Adobe Photoshop 6.0 File Formats"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: psd6.zip
    deprecated: true
    
  - name: "Adobe Photoshop SDKs"
    description: "Adobe Photoshop SDKs"
    categories:
    - 2d-graphics
    author: "Adobe"
    link: "http://partners.adobe.com/asn/developer/gapsdk/PhotoshopSDK.html"
    deprecated: true
---

## Adobe Photoshop Document (PSD)

PSD is the native document format of Adobe Photoshop. Unlike a flattened image
format such as JPEG or PNG, a PSD preserves the editable structure of a project:
individual layers and layer groups, layer and vector masks, alpha channels, blend
modes, adjustment and text layers, layer effects, and color/mode information. It
lets an artist reopen a file and continue non-destructive editing, which is why it
is a central interchange format across Adobe's applications and many third-party
tools.

The format is well documented and begins with the signature `8BPS`. A PSD stores
the image mode (RGB, CMYK, grayscale, Lab, and others) and bit depth, a layer and
mask section describing every layer's data and metadata, and a merged composite of
the whole image so that programs which do not understand the layer structure can
still display a flattened preview. The related PSB ("large document") variant uses
the same structure to exceed PSD's dimension and size limits.

### Preservation And Security Notes

For preservation, the layered PSD is the master/editable copy; a flattened export
(TIFF, PNG, or JPEG) is a derivative that discards the editing structure, so both
are often kept. Because a PSD is a complex binary format with many
variable-length, offset-driven blocks, a parser handling untrusted files should
validate lengths and dimensions before allocating memory or decoding.

### Further Reading

- Adobe Photoshop File Formats Specification: `https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/`
