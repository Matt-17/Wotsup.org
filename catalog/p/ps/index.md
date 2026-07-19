---
overview: ".ps files are PostScript documents: a device-independent page description language from Adobe that is also a full programming language, historically the standard for driving printers and typesetting pages."
extensions:
  - name: "PostScript Language File Transmission (PSFT) Specification Version 1.0 (Acrobat)"
    description: "PostScript Language File Transmission (PSFT) Specification Version 1.0 (Acrobat)"
    categories:
    - documents
    author: "Adobe"
    file: fax_spec.zip
    
  - name: "PostScript Language Reference, Third Edition (Acrobat: 7.4 MB / 912 pages)"
    description: "PostScript Language Reference, Third Edition (Acrobat: 7.4 MB / 912 pages)"
    categories:
    - documents
    author: "Adobe"
    link: "http://partners.adobe.com/asn/developer/PDFS/TN/PLRM.pdf"
    deprecated: true
---

## PostScript (PS)

PostScript is a page description language created by Adobe that became the standard
way to describe printed pages independently of any specific output device. A `.ps`
file is not a static bitmap but a program: it contains instructions, executed by a
PostScript interpreter (in a printer or in software such as Ghostscript), that draw
text, vector graphics, and images onto a page. Because it is device-independent,
the same file can print at a laser printer's resolution or an imagesetter's,
scaling cleanly.

PostScript is a full, stack-based programming language with variables, procedures,
and control flow, which makes it extremely flexible — a document can compute its
own layout — but also complex to process. Files typically begin with `%!PS-Adobe`
and follow the Document Structuring Conventions so tools can navigate pages and
resources. Fonts, in Type 1 and later formats, are a core part of the ecosystem.

### PostScript And PDF

PDF grew out of PostScript, keeping its imaging model but removing the general
programmability in favor of a fixed, page-oriented structure that is safer and
faster to render. As a result PDF has replaced PostScript for document interchange,
while PostScript persists in print production and as the language many printers
still accept. The media type is `application/postscript`.

### Security Notes

Because PostScript can execute arbitrary logic and includes file and device
operators, rendering untrusted `.ps` files is genuinely risky and has been the
basis of real exploits. Process untrusted PostScript only in a sandboxed
interpreter with file and system operators disabled, or convert it with a hardened
tool, rather than sending it directly to a device.

### Further Reading

- PostScript Language Reference (Adobe): `https://www.adobe.com/content/dam/acom/en/devnet/actionscript/articles/PLRM.pdf`
- Ghostscript: `https://www.ghostscript.com/`
