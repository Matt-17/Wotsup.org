---
overview: "SGML (Standard Generalized Markup Language) is an ISO meta-language for defining markup vocabularies; it is the ancestor of HTML and XML and underpins large structured-document systems."
extensions:
  - name: "Standard Generalized Markup Language (SGML)"
    description: "Standard Generalized Markup Language (SGML)"
    categories:
    - internet
    link: "http://xml.coverpages.org/sgml.html"
---

## Standard Generalized Markup Language (SGML)

SGML is an international standard (ISO 8879) for defining markup languages. Rather
than being a single fixed vocabulary, it is a meta-language: it specifies how to
declare elements, attributes, and their allowed structure so that organizations
can create their own document types. Its central idea — separating a document's
logical structure from its presentation, and describing that structure with a
formal grammar — was hugely influential.

Each SGML application is defined by a Document Type Definition (DTD) that lists the
permitted elements and how they may nest. SGML itself is powerful and complex,
supporting features such as tag minimization (omitting certain tags where they can
be inferred) and rich entity mechanisms, which made it authoritative for
large-scale technical documentation, publishing, and government and aerospace
standards.

### Relationship To HTML And XML

SGML's practical legacy is its descendants. HTML began as an SGML application, and
XML was designed as a simplified, strict subset of SGML that removed the most
complex and ambiguous features to be easier to process, especially on the web. In
most new work SGML has been superseded by XML, but understanding SGML explains why
HTML and XML look and behave as they do.

### Preservation And Security Notes

SGML documents are open, text-based, and self-describing via their DTD, which suits
preservation as long as the governing DTD is retained alongside the document.
Because SGML entity and external-reference mechanisms can pull in external content,
processors handling untrusted SGML should constrain external entity resolution,
much as with XML.

### Further Reading

- Overview of SGML resources: `https://en.wikipedia.org/wiki/Standard_Generalized_Markup_Language`
