---
overview: ".eps files are Encapsulated PostScript: a single-page PostScript document with a bounding box and structuring conventions, designed to be embedded as a self-contained graphic inside other documents."
extensions:
  - name: "Encapsulated Postscript Version 1.2"
    description: "Encapsulated Postscript Version 1.2 (Acrobat)"
    categories:
    - documents
    author: "Adobe"
    file: epsf1_2.zip
    
  - name: "Encapsulated Postscript Version 2.0"
    description: "Encapsulated Postscript Version 2.0 (Acrobat)"
    categories:
    - documents
    author: "Adobe"
    file: epsf2_0.zip
    
  - name: "Encapsulated Postscript Version 3.0"
    description: "Encapsulated Postscript Version 3.0 (Acrobat)"
    categories:
    - documents
    author: "Adobe"
    file: epsf3_0.zip
    
---

## Encapsulated PostScript (EPS)

EPS is a constrained form of PostScript intended to be embedded as a graphic
within a larger document, such as a page laid out in a word processor or DTP
program. Where a general PostScript file may describe many pages and manipulate
printer state freely, an EPS file describes a single illustration and follows
extra rules so a host application can place and scale it predictably.

The two defining requirements are a `%!PS-Adobe-3.0 EPSF` header and a
`%%BoundingBox` comment that declares the artwork's extent, so the container knows
how much space the graphic occupies. EPS files also obey the Document Structuring
Conventions and avoid operators that would disturb the surrounding page. Because
many programs cannot render PostScript directly, an EPS may include a low-
resolution preview (TIFF or WMF) for on-screen display while the full PostScript
is used for printing.

### Status And Preservation Notes

EPS was the standard vector interchange format in professional publishing for
years but has largely been superseded by PDF (and, for artwork, by PDF-based AI
and SVG). It remains common in legacy print workflows. The media type is
`application/postscript`. For preservation, converting to PDF/X or PDF/A while
retaining the original is typical, since faithful output depends on available
fonts and a PostScript interpreter.

### Security Notes

An EPS is a PostScript program, and PostScript is a full programming language with
file and device operators. Rendering untrusted EPS has historically enabled
serious exploits, so interpret it only in a sandboxed, capability-restricted
interpreter (or convert via a hardened tool) rather than passing it straight to a
printer or renderer.

### Further Reading

- Encapsulated PostScript File Format Specification (Adobe): `https://www.adobe.com/content/dam/acom/en/devnet/actionscript/articles/5002.EPSF_Spec.pdf`
