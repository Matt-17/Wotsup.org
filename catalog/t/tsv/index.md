---
overview: ".tsv files are tab-separated values files: plain-text tables in which each line is a record and fields are separated by tab characters."
extensions:
  - name: "Tab-Separated Values (TSV)"
    description: "Plain-text tabular data with tab-delimited fields (text/tab-separated-values)"
    categories:
    - data-format
    - spreadsheets
    author: "IANA (media type registration)"
    link: "https://www.iana.org/assignments/media-types/text/tab-separated-values"
---

## Tab-Separated Values (TSV)

TSV is a simple text format for tabular data. Each line is one record, and the
fields within a record are separated by a tab character (U+0009). It is a close
relative of comma-separated values (CSV) and is used for the same purpose:
exchanging spreadsheet, database, and statistics data between programs.

The main advantage over CSV is that tab characters rarely occur inside ordinary
text, so fields usually need no quoting or escaping. The format is registered with
IANA as `text/tab-separated-values`. In that definition, fields cannot contain tabs
or line breaks; there is no quoting mechanism. Some tools nevertheless add their
own conventions, such as backslash escapes for tab and newline or CSV-style
quoting, so TSV files from different sources are not always interchangeable.

### Adoption

TSV is read and written by spreadsheet programs, databases, and most
data-analysis libraries. It is common in scientific and bioinformatics data and in
dataset distributions. The first line often contains column names, but this is a
convention, not a requirement.

### Preservation And Security Notes

TSV carries no type information, character encoding declaration, or schema, so
document the encoding (UTF-8 is recommended), line endings, and whether a header
row is present. Spreadsheet programs may reinterpret values (dates, leading zeros,
long numbers) on import. Files that will be opened in spreadsheets should guard
against formula injection from cells beginning with `=`, `+`, `-`, or `@`.

### Further Reading

- IANA registration for text/tab-separated-values: `https://www.iana.org/assignments/media-types/text/tab-separated-values`
