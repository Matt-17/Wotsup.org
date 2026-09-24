---
overview: ".step files (also .stp) are STEP files: ISO 10303 product data exchange files, widely used to transfer 3D CAD geometry and product structure between systems."
extensions:
  - name: "STEP file (ISO 10303-21)"
    description: "Clear-text encoding of ISO 10303 product data for CAD exchange, also written .stp"
    categories:
    - cad
    - 3d-graphics
    author: "ISO TC 184/SC 4"
    link: "https://www.loc.gov/preservation/digital/formats/fdd/fdd000448.shtml"
---

## STEP

STEP (Standard for the Exchange of Product model data) is the common name for
ISO 10303, a family of standards for describing product data across its life
cycle. The `.step` and `.stp` extensions identify a file in the "Part 21" clear
text encoding (ISO 10303-21), which is the most common way to exchange 3D CAD
models between different CAD, CAM and CAE systems.

### Structure

A Part 21 file is plain text that starts with `ISO-10303-21;` and ends with
`END-ISO-10303-21;`. It contains a `HEADER` section with file description, name,
author and the schema in use, followed by a `DATA` section listing entity
instances as numbered records such as `#10 = CARTESIAN_POINT(...)`. The entities
are defined in EXPRESS schemas (ISO 10303-11) called application protocols.
Frequently used ones are AP203 (configuration-controlled 3D design), AP214
(automotive design), and AP242 (managed model-based 3D engineering), which also
supports product manufacturing information and tessellated geometry. Other
encodings, such as XML (ISO 10303-28) and zipped files, exist but are less common.

### Adoption And Tooling

Nearly every commercial and open source CAD system can import and export STEP,
including SolidWorks, CATIA, Siemens NX, Fusion, FreeCAD and Open CASCADE-based
tools. It is the usual neutral format for exchanging solid models, assemblies and
(depending on the protocol) colors and metadata. Results can vary between
implementations because of different interpretation of the schema and tolerance
settings.

### Preservation And Security Notes

STEP's open, text-based form and standardization make it a good candidate for
long-term preservation of CAD models, and the US Library of Congress lists it as
a format description. Archive the original native CAD file too, since STEP does
not carry parametric history or feature trees in most protocols.

### Further Reading

- STEP file format description (Library of Congress): `https://www.loc.gov/preservation/digital/formats/fdd/fdd000448.shtml`
- STEP standards overview (STEP Tools): `https://www.steptools.com/stds/step/`
