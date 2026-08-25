---
overview: ".xlsx files are Office Open XML spreadsheets: the modern Microsoft Excel format, a ZIP package (OPC) of XML parts describing worksheets, cells, formulas, styles, and charts."
extensions:
  - name: "Office Open XML Spreadsheet (XLSX)"
    description: "ZIP-packaged XML spreadsheet format (Microsoft Excel / ECMA-376 / ISO 29500)"
    categories:
    - spreadsheets
    author: "Microsoft / ECMA / ISO"
    link: "https://learn.microsoft.com/openspecs/office_standards/ms-xlsx/"
---

## Office Open XML Spreadsheet (XLSX)

XLSX is the default workbook format of Microsoft Excel since Excel 2007 and the
successor to the legacy binary `.xls`. Like DOCX, it is part of Office Open XML
(ECMA-376 / ISO/IEC 29500) and is structurally unrelated to the old binary BIFF
format it replaced: an `.xlsx` is an open, inspectable package of XML rather than an
opaque OLE compound file.

An XLSX is a ZIP archive following the Open Packaging Conventions. Inside, each
worksheet is an XML part (for example `xl/worksheets/sheet1.xml`), the workbook
structure is in `xl/workbook.xml`, and shared resources are factored out into
separate parts: a shared-strings table deduplicates text across cells, a styles part
holds number formats and cell formatting, and further parts hold charts, drawings,
and embedded media, tied together by `.rels` relationship files. This design keeps
files reasonably compact and lets tools read or generate spreadsheets without Excel.

### Interoperability And Preservation Notes

Because OOXML is an open standard supported by Excel, LibreOffice, Google Sheets, and
many libraries, XLSX is a strong interchange and preservation format for spreadsheets
that need to retain formulas and structure; CSV remains the choice for pure tabular
data without formatting. The media type is
`application/vnd.openxmlformats-officedocument.spreadsheetml.sheet`.

### Security Notes

Spreadsheets can carry VBA macros (the `.xlsm` variant), external data connections,
and links, so untrusted workbooks should be opened with macros disabled and external
content blocked; formula-injection risks apply when building sheets from untrusted
input. As a ZIP container, apply the usual precautions against decompression bombs
and path traversal when extracting parts.

### Further Reading

- Office Open XML overview: `https://en.wikipedia.org/wiki/Office_Open_XML`
