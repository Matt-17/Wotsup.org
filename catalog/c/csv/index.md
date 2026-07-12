---
overview: ".csv files are comma-separated values: a plain-text tabular format with one record per line and fields separated by commas, used as a simple, near-universal interchange format for spreadsheets and databases."
extensions:
  - name: "Comma Separated Value Files"
    description: "Comma Separated Value Files"
    categories:
    - spreadsheets
    author: "Robert J. Lynch and Paul Hsieh"
    file: csv.zip
---

## Comma-Separated Values (CSV)

CSV is the most common plain-text format for exchanging tabular data. Each line
is one record, and fields within a record are separated by commas, with an
optional header row naming the columns. Its appeal is universality and
simplicity: almost every spreadsheet, database, and analysis tool can import and
export CSV, and the files are human-readable and easy to generate.

The format's conventions are documented in RFC 4180. Fields that contain a
comma, a double quote, or a line break are enclosed in double quotes, and a
literal double quote inside a quoted field is written as two double quotes. This
quoting is what allows arbitrary text to be carried safely in a comma-delimited
line.

### Ambiguities

CSV is deceptively simple and not fully standardized in practice. Real files
vary in delimiter (comma, semicolon, or tab — the latter often called TSV),
character encoding (which affects non-ASCII text and is a frequent source of
corruption), line-ending style, and whether a header row is present. Some locales
use the semicolon because the comma is a decimal separator. Reliable interchange
therefore means stating the encoding and delimiter explicitly rather than
assuming them.

### Preservation And Security Notes

CSV is excellent for preservation of tabular data because it is open, text-based,
and tool-independent; recording the encoding (ideally UTF-8) and delimiter keeps
it self-describing. A well-known risk is CSV (formula) injection: a value
beginning with `=`, `+`, `-`, or `@` may be interpreted as a formula when the
file is opened in a spreadsheet, so values should be sanitized on export from
untrusted input.

### Further Reading

- RFC 4180 (Common Format for CSV Files): `https://datatracker.ietf.org/doc/html/rfc4180`
