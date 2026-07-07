---
overview: ".mif files are MapInfo Interchange Format data: a plain-text export/import format for GIS vector data that pairs a .mif geometry file with a .mid attribute file for moving MapInfo tables between systems."
extensions:
  - name: "MapInfo Interchange Format (MIF/MID)"
    description: "Text-based interchange format for MapInfo GIS vector geometry (.mif) and attribute data (.mid)"
    categories:
    - gis-formats
    author: "MapInfo Corporation / Precisely"
    link: "https://en.wikipedia.org/wiki/MapInfo_TAB_format"
    file: mif_mid.zip
---

## MapInfo Interchange Format (MIF/MID)

The MapInfo Interchange Format is a plain-text format for importing and
exporting GIS vector data to and from MapInfo, historically used to move spatial
tables between MapInfo and other systems that cannot read the native binary TAB
format. Because it is human-readable ASCII, MIF/MID is convenient for
inspection, scripting, and interchange, and it is widely supported by GIS
software as an import/export option.

The format always comes as a pair of files. The `.mif` file holds the header —
version, character set, delimiter, coordinate system and bounds, and the column
definitions — followed by the geometry section describing each feature (points,
lines, polylines, regions, arcs, text, and their styling). The matching `.mid`
file holds the attribute data: one delimited row of column values per feature,
in the same order as the geometries in the `.mif`. The two files are linked by
position, so they must be kept and processed together.

### Structure And Interoperability

Each feature's geometry in the `.mif` corresponds to the same-numbered record in
the `.mid`, so the row order is significant and the files cannot be edited
independently without breaking that correspondence. The header declares the
delimiter and coordinate system that the rest of the data relies on. Because the
format is text and openly documented, it interoperates well, though very large
datasets are more compactly stored in binary formats.

### Preservation Notes

For preservation and transfer, always keep the `.mif` and `.mid` together, and
record the declared coordinate system and delimiter, since attribute parsing and
correct georeferencing depend on the header. When converting to another vector
format such as an ESRI Shapefile, GeoPackage, or GeoJSON, preserve the column
definitions, coordinate reference system, and feature ordering.

### Security Notes

As a delimited text format, MIF/MID carries the usual risks of parsing untrusted
tabular data: mismatched geometry and attribute counts, malformed coordinate or
column definitions, and values that could be misinterpreted by downstream tools
(for example formula injection when exporting attributes to spreadsheets).
Validate that geometry and attribute records align and sanitize values on
export.

### Further Reading

- MapInfo TAB and interchange formats: `https://en.wikipedia.org/wiki/MapInfo_TAB_format`
- GDAL/OGR MapInfo driver: `https://gdal.org/drivers/vector/mitab.html`
