---
overview: ".xml files are Extensible Markup Language documents: a self-describing, hierarchical text format with user-defined element and attribute names, used as a foundation for countless data and document formats."
extensions:
  - name: "Extensible Markup Language (XML) 1.0"
    description: "Extensible Markup Language (XML) 1.0"
    categories:
    - internet
    link: "http://www.w3.org/TR/REC-xml"
---

## Extensible Markup Language (XML)

XML is a W3C standard for encoding structured data and documents as
human-readable text. It is a simplified, web-friendly descendant of SGML that
lets authors define their own element and attribute names to model information as
a tree of nested elements. Rather than being a single format, XML is a
meta-format: it provides the syntax on which many specific formats are built,
including SVG, XHTML, RSS/Atom, SOAP, Office Open XML, and innumerable
configuration and data-exchange schemas.

An XML document has a strict notion of being "well-formed": every element must be
properly closed and nested, attribute values quoted, and there must be a single
root element. Documents may declare an encoding, use namespaces to combine
vocabularies without name collisions, and be validated for correctness against a
DTD, XML Schema (XSD), or RELAX NG grammar.

### Strictness And Tooling

Unlike HTML's forgiving parsing, XML parsers reject malformed documents outright,
which makes XML predictable for machine processing at the cost of being less
tolerant of errors. A rich ecosystem supports it — XPath for addressing nodes,
XSLT for transformation, and schema languages for validation — which is a large
part of why XML remains common in enterprise and document-interchange settings.

### Preservation And Security Notes

XML is well suited to preservation: it is open, text-based, self-describing, and
can be validated against an explicit schema. Security requires care, however,
because XML features can be abused: external entity references enable XXE attacks
that read local files or make network requests, and nested entity expansion
enables "billion laughs" denial-of-service. Parsers handling untrusted XML should
disable external entities and DTD processing or otherwise constrain expansion.

### Further Reading

- W3C XML 1.0 specification: `https://www.w3.org/TR/xml/`
