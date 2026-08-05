---
overview: ".dbf files are dBASE database tables: a long-lived, simple record-oriented table format (the core of the xBase family) storing a field-defined header followed by fixed-length records, still widely used including as the attribute table of GIS shapefiles."
extensions:
  - name: "dBASE .DBF File Structure"
    description: "dBASE .DBF File Structure"
    categories:
    - spreadsheets
    author: "Borland"
    file: ti838d.zip
    
  - name: "DBase file documentation"
    description: "DBase file documentation"
    categories:
    - spreadsheets
    file: dbase.zip
    
  - name: "XBASE (NDX/MDX/DBF/DBT)"
    description: "XBASE (NDX/MDX/DBF/DBT)"
    categories:
    - spreadsheets
    author: "Erik Bachmann"
    link: "http://www.clicketyclick.dk/databases/xbase/format/"
    
  - name: "File Structure (dBASE III/dBASE IV/Foxbase/Foxpro)"
    description: "File Structure (dBASE III/dBASE IV/Foxbase/Foxpro)"
    categories:
    - spreadsheets
    author: "Peter Mikalajunas"
    file: dbf.zip
    
---

## dBASE Table (DBF)

The DBF format originated with dBASE, the dominant database program on early PCs,
and it became the shared table format of the entire "xBase" family — dBASE, FoxPro,
Clipper, and their successors. Its longevity comes from a simple, transparent
design that many programs can read and write, and it remains in active use decades
later, most visibly as the attribute table (`.dbf`) that accompanies an ESRI
Shapefile in GIS.

A DBF file has a header followed by data records. The header records the version/
type flag, the date of last update, the number of records, and a field descriptor
array that names each column and gives its type, length, and decimal count. Each
record is then a fixed-length row: a leading byte marks whether the record is
active or deleted, followed by each field's value stored in a fixed-width,
space- or zero-padded text form. Common field types include character, numeric,
date, logical, and memo. Long or binary values (memo fields) are stored in a
companion `.dbt`/`.fpt` file, and index files (`.ndx`/`.mdx`/`.cdx`) may accompany
the table.

### Preservation And Interoperability Notes

DBF is well suited to preservation of tabular data because its structure is simple,
openly documented, and self-describing through its field header. Two caveats matter:
character encoding is often implied rather than stored (the "language driver"/code
page), so it should be recorded to avoid corrupting non-ASCII text; and memo
content lives in a separate file that must be kept with the `.dbf`. There are minor
dialect differences between dBASE III/IV, FoxPro, and Visual FoxPro variants.

### Security Notes

As a binary format whose header field lengths and record counts drive parsing, a
DBF reader should validate the declared record length and count against the actual
file size when handling untrusted files.

### Further Reading

- XBase (DBF) file format description: `https://www.clicketyclick.dk/databases/xbase/format/`
