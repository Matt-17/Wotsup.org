---
overview: ".epub files are EPUB e-books: an open e-book standard that packages reflowable XHTML content, CSS, and media as a ZIP archive, readable across a wide range of e-reading devices and apps."
extensions:
  - name: "EPUB electronic publication"
    description: "Open, ZIP-packaged reflowable e-book format based on XHTML and CSS"
    categories:
    - documents
    - internet
    author: "W3C (formerly IDPF)"
    link: "https://www.w3.org/publishing/epub3/"
---

## EPUB

EPUB is the leading open standard for digital books, maintained today by the W3C
(originally by the International Digital Publishing Forum). Its defining strength is
reflowable content: rather than fixing text to a page like a PDF, an EPUB lets the
reading system adapt the layout to the screen size, font, and user preferences,
which is why it is the format of choice for novels and other text-centric books on
phones, tablets, and dedicated e-readers.

Under the hood, an EPUB is essentially a website packaged as a ZIP archive. The
content is authored in XHTML and styled with CSS, with images, fonts, and media
included as separate files. A `META-INF/container.xml` points to a package document
(the OPF file) that lists all the resources (the "manifest"), defines the reading
order (the "spine"), and carries metadata such as title, author, and identifier; a
navigation document provides the table of contents. The ZIP must store its first
entry, `mimetype`, uncompressed so the format can be identified quickly.

### Versions And Fixed Layout

EPUB 3, the current generation, is built on modern HTML and CSS and supports rich
media, scripting, accessibility features, and MathML, while remaining backward-aware
of the older EPUB 2. A "fixed-layout" profile exists for content like children's
books and comics where precise page design matters more than reflow.

### Preservation And Security Notes

EPUB is well suited to preservation because it is open, standards-based, and built
from documented web technologies; note that commercially distributed e-books may be
wrapped in DRM, which is a separate access barrier from the format itself. As
ZIP-plus-web-content, reading systems should apply archive precautions and treat
embedded scripts and external references as untrusted. The media type is
`application/epub+zip`.

### Further Reading

- EPUB 3 specification (W3C): `https://www.w3.org/publishing/epub3/`
