---
overview: ".css files are Cascading Style Sheets: the language that describes how HTML and other markup documents are presented — layout, colors, typography, and responsive behavior — separately from their content."
extensions:
  - name: "Cascading Style Sheets 1"
    description: "Cascading Style Sheets 1"
    categories:
    - internet
    link: "http://www.w3.org/TR/REC-CSS1"
    
  - name: "Cascading Style Sheets 2"
    description: "Cascading Style Sheets 2"
    categories:
    - internet
    link: "http://www.w3.org/TR/REC-CSS2"
    
---

## Cascading Style Sheets (CSS)

CSS is the W3C standard language for describing the presentation of documents
written in HTML, XHTML, SVG, and other markup. By separating presentation from
content, CSS lets the same HTML be styled for screens of different sizes, print,
and assistive technologies without changing the underlying markup. A `.css` file
is plain text consisting of rules: a selector that targets elements, followed by
a block of property/value declarations controlling color, spacing, typography,
layout, and more.

The name reflects the "cascade": when multiple rules apply to the same element,
CSS resolves conflicts through a well-defined order based on origin, specificity,
and source order, combined with inheritance of certain properties from parent
elements. Modern CSS also provides powerful layout systems (Flexbox and Grid),
custom properties (variables), media queries for responsive design, transitions,
and animations.

### Versioning

Early CSS was released as numbered levels (CSS1, CSS2, CSS2.1). CSS is now
developed as independent modules — each versioned separately — rather than one
monolithic specification, so support is best described per feature and per
browser rather than by a single version number. The media type is `text/css`.

### Preservation And Security Notes

CSS is open, text-based, and good for preservation, but a document's appearance
depends on the exact stylesheet, referenced fonts and images, and the rendering
engine, all of which should be captured together. Because stylesheets can load
external resources and, in some contexts, influence behavior, systems accepting
untrusted CSS should constrain what it can reference and inject.

### Further Reading

- CSS specifications (W3C): `https://www.w3.org/Style/CSS/`
- MDN CSS documentation: `https://developer.mozilla.org/docs/Web/CSS`
