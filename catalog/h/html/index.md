---
overview: ".html files are HyperText Markup Language documents: the tag-based markup language that structures the content of web pages, linking text, media, and interactive elements for display in browsers."
extensions:
  - name: "HTML 2.0 (RFC 1866 approved by IETF)"
    description: "HTML 2.0 (RFC 1866 approved by IETF)"
    categories:
    - internet
    link: "http://www.faqs.org/rfcs/rfc1866.html"
    
  - name: "HTML 3.2 Specification (W3C approved)"
    description: "HTML 3.2 Specification (W3C approved)"
    categories:
    - internet
    author: "Dave Raggett"
    link: "http://www.w3.org/pub/WWW/TR/REC-html32.html"
    
  - name: "HTML 4 Specification (W3C approved)"
    description: "HTML 4 Specification (W3C approved)"
    categories:
    - internet
    author: "Dave Raggett"
    link: "http://www.w3.org/TR/REC-html40/"

  - name: "HTML 4.01 Specification (W3C approved)"
    description: "HTML 4.01 Specification (W3C approved)"
    categories:
    - internet
    link: "http://www.w3.org/TR/html4/"
    
---

## HyperText Markup Language (HTML)

HTML is the markup language that defines the structure and content of documents
on the World Wide Web. An HTML file is text marked up with elements written as
tags — such as `<p>`, `<a>`, `<img>`, `<table>`, and `<div>` — that describe
headings, paragraphs, links, images, forms, and other content. Browsers parse
this markup into a document tree (the DOM) and render it, typically combined
with CSS for presentation and JavaScript for behavior.

HTML has a long standardization history: early versions were specified by the
IETF (HTML 2.0) and then the W3C (HTML 3.2, 4.0, 4.01, and the XML-serialized
XHTML). Development is now stewarded by the WHATWG as the continuously updated
"HTML Living Standard" rather than numbered releases, which is the current
authoritative definition.

### Structure And Robustness

A modern document starts with `<!DOCTYPE html>` and nests content inside
`<html>`, `<head>`, and `<body>`. A defining trait of HTML is lenient parsing:
browsers apply well-defined error-recovery rules to malformed markup, so pages
render even when tags are unclosed or misnested. This forgiving behavior is a
major difference from strict XML-based formats.

### Preservation And Security Notes

The media type is `text/html`, conventionally UTF-8 encoded. HTML is good for
preservation as open, documented text, but a page's appearance depends on
external CSS, scripts, fonts, and images, so archiving should capture those
dependencies. Because HTML routinely carries active content, systems that
display untrusted HTML must sanitize it to prevent cross-site scripting (XSS)
and control what scripts, embeds, and external requests are allowed.

### Further Reading

- HTML Living Standard (WHATWG): `https://html.spec.whatwg.org/`
- MDN HTML documentation: `https://developer.mozilla.org/docs/Web/HTML`
