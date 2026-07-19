---
overview: ".ai files are Adobe Illustrator artwork: the native vector-graphics format of Illustrator, historically PostScript-based and now built on PDF, storing paths, type, and effects for scalable illustration."
extensions:
  - name: "Adobe Illustrator(R) File Format Specification Version 7.0 (Acrobat)"
    description: "Adobe Illustrator(R) File Format Specification Version 7.0 (Acrobat)"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: ai7.zip
    
  - name: "Adobe Illustrator 2.0 Format (Acrobat)"
    description: "Adobe Illustrator 2.0 Format (Acrobat)"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: ai20.zip
    
  - name: "Adobe Illustrator 3.0 Draft Format (Acrobat)"
    description: "Adobe Illustrator 3.0 Draft Format (Acrobat)"
    categories:
    - 2d-graphics
    author: "Adobe"
    file: ai30.zip
    
  - name: "Utility for creating AI files"
    description: "Utility for creating AI files"
    categories:
    - 2d-graphics
    link: "http://www.chebucto.ns.ca/~aa056/aimaker/aimaker.html"
    
---

## Adobe Illustrator Artwork (AI)

AI is the native document format of Adobe Illustrator, the industry-standard
vector illustration program. It stores artwork as resolution-independent objects —
Bézier paths, shapes, editable type, gradients, patterns, effects, and layers —
so logos, icons, and illustrations can be scaled to any size without loss of
quality. It is a primary interchange format for professional graphic design and
print.

The format's underpinnings have changed over time. Early AI files were a
constrained dialect of PostScript, which is why older `.ai` files can often be
interpreted by PostScript tools. Modern AI files are based on PDF: the file is a
valid PDF that additionally carries private Illustrator data preserving full
editability. This dual nature means a current `.ai` can frequently be opened or
placed by PDF-aware applications, though only Illustrator reads the private editing
information.

### Preservation And Security Notes

Because AI is proprietary and editor-specific, preserving important artwork often
means keeping the `.ai` master alongside an open or standardized derivative such as
SVG (for web-scale vector graphics) or PDF/X (for print). Faithful rendering
depends on fonts, linked or embedded images, and color profiles, which should be
captured with the file. Since modern AI is PDF-based (and older AI is PostScript-
based), the same caution applies to untrusted files: open them with an up-to-date,
sandboxed reader.

### Further Reading

- Adobe Illustrator overview: `https://en.wikipedia.org/wiki/Adobe_Illustrator_Artwork`
