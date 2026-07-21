---
overview: ".emf files are Enhanced Metafiles: the 32-bit successor to the Windows Metafile, storing device-independent GDI drawing records for scalable vector graphics on Windows."
extensions:
  - name: "Enhanced Metafile Format"
    description: "Enhanced Metafile Format"
    categories:
    - 2d-graphics
    author: "Microsoft"
    file: emf.zip
---

## Enhanced Metafile (EMF)

EMF is the 32-bit successor to the Windows Metafile (WMF), designed to address the
older format's limitations. Like WMF it stores an image as a sequence of Graphics
Device Interface drawing records rather than as pixels, so the graphic is vector-
based and scales cleanly, but EMF uses 32-bit coordinates, a richer and better-
specified record set, and a self-contained header that makes it reliably device-
independent.

An EMF file begins with a header record (`ENHMETA_SIGNATURE`, the ASCII " EMF")
that describes the drawing's bounds in both device and physical units and the
number of records, followed by the drawing records themselves and an end-of-file
record. A later extension, EMF+, embeds GDI+ drawing commands to support features
such as anti-aliasing, alpha blending, and gradients, while remaining within the
EMF container.

### Use And Preservation Notes

EMF is the metafile format used by modern Windows for spooled print jobs, clipboard
vector data, and application graphics interchange. For preservation, converting to
an open vector format such as SVG (or PDF) while keeping the original is sensible,
since faithful rendering depends on Windows GDI/GDI+ semantics and fonts.

### Security Notes

As with WMF, an EMF is a stream of drawing records that a renderer executes, so
software handling untrusted metafiles should validate record types and sizes and
use hardened, up-to-date parsing to avoid the memory-safety and callback issues
that have historically affected metafile handling.

### Further Reading

- [MS-EMF] Enhanced Metafile Format: `https://learn.microsoft.com/openspecs/windows_protocols/ms-emf/`
