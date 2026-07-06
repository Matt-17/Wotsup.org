---
overview: ".ifc files hold Industry Foundation Classes models: an open, vendor-neutral data standard for exchanging Building Information Modeling (BIM) data about buildings and infrastructure across design, construction, and facility tools."
extensions:
  - name: "Industry Foundation Classes (IFC) format"
    description: "Open buildingSMART data model for BIM exchange of building and infrastructure information"
    categories:
    - cad
    author: "buildingSMART International"
    link: "https://technical.buildingsmart.org/standards/ifc/"
---

## Industry Foundation Classes (IFC)

IFC is the open, standardized data model for Building Information Modeling
(BIM). Maintained by buildingSMART International and standardized as ISO 16739,
it describes the objects that make up a building or infrastructure project —
walls, slabs, columns, doors, spaces, systems — together with their geometry,
properties, relationships, materials, and classification. Its purpose is
"openBIM": letting different design, analysis, construction, and facility
management applications exchange a shared model without depending on any single
vendor's native format.

An IFC dataset is more than geometry. It is an object graph in which each
element has a type, a set of properties, and typed relationships to other
elements — a wall belongs to a storey, hosts a door, is made of layered
materials, and carries fire-rating and load properties. This semantic richness
is what makes IFC useful for coordination, quantity takeoff, code checking, and
handover, rather than just visualization.

### Encodings

The classic `.ifc` file uses the STEP physical file encoding (ISO 10303-21,
"Part 21"), a readable text format of numbered `#` instances. The same model
can also be serialized as `ifcXML` (an XML encoding) and packaged as `ifcZIP`
(a compressed archive of an IFC or ifcXML file). Tools should detect which
encoding is present rather than assuming plain STEP text from the extension
alone. Several schema versions exist (such as IFC2x3 and IFC4), and the schema
version affects which entities and properties are valid.

### Preservation And Exchange Notes

Reliable exchange depends on Model View Definitions (MVDs), which constrain
which parts of the schema an exchange uses, and on consistent property sets.
For preservation and transfer, record the IFC schema version and MVD, keep
units and the georeferencing/placement information, and validate the file
against the declared schema. IFC is well suited to long-term archiving because
it is an open, text-documented standard, but a receiving tool may still ignore
entities outside its supported MVD.

### Security Notes

Because a Part 21 file is text with cross-referenced instance IDs, parsers
should guard against malformed or circular references, extremely large instance
counts, and deeply nested geometry from untrusted files, to avoid excessive
memory use or non-termination while resolving the object graph.

### Further Reading

- buildingSMART IFC standard: `https://technical.buildingsmart.org/standards/ifc/`
- ISO 16739 (Industry Foundation Classes): `https://www.iso.org/standard/70303.html`
