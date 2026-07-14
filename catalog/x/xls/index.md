---
overview: ".xls files are Microsoft Excel binary spreadsheets: a legacy workbook format using the BIFF record stream inside an OLE Compound File, holding worksheets, formulas, charts, and formatting."
extensions:             
  - name: "Microsoft Excel File Format"
    description: "Microsoft Excel File Format (versions 2, 3, 4, 5, 95, 97, 2000, XP)"
    categories:
    - spreadsheets
    author: "Daniel Rentz"
    file: excel.zip   
   
  - name: "Microsoft Excel File Format (version 2.1)"
    description: "Microsoft Excel File Format (version 2.1)"
    categories:
    - spreadsheets  
    file: xls.zip  

  - name: "Microsoft Office 97 Excel File Format"
    description: "Microsoft Office 97 Excel file format"
    categories:
    - spreadsheets
    author: "Microsoft Corp."  
    file: excel97chart.zip 
                           
  - name: "Microsoft Excel Binary File Format"
    description: "Microsoft Excel Binary File Format (unknown version)"
    categories:
    - spreadsheets
    author: "Mark O'Brien"
    file: excel_biff.zip   
    
  - name: "Compound File Binary File Format"
    description: "Compound File Binary File Format"
    categories:
    - spreadsheets
    author: "Microsoft Corporation"
    link: "https://sourceforge.net/p/aaf/code2/ci/master/tree/doc/aafcontainerspec-v1.0.1.pdf?format=raw"
           
  - name: "The Chicago Project - GPL Excel project"
    description: "The Chicago Project - GPL Excel project"
    categories:
    - spreadsheets
    author: "Charles Wyble"
    link: "http://chicago.sourceforge.net/"                    
 
  - name: "Java Excel API"
    description: "Java Excel API"
    categories:
    - spreadsheets
    link: "http://www.andykhan.com/jexcelapi/"
    deprecated: true                            
 
  - name: "VB Class to Write an Excel BIFF 2.1 Spreadsheet"
    description: "VB class to write an Excel BIFF 2.1 spreadsheet directly"
    categories:
    - spreadsheets
    author: "Paul Squires"
    file: excelclass.zip  
  
  - name: "OpenOffice.org's Documentation of the Microsoft Excel File Format Versions 2, 3, 4, 5, 95, 97, 2000, XP, 2003"
    description: "OpenOffice.org's Documentation of the Microsoft Excel File Format Versions 2, 3, 4, 5, 95, 97, 2000, XP, 2003"
    categories:
    - spreadsheets
    author: "Daniel Rentz"
    file: excelfileformat.zip 
    
  - name: "OLE Compound File Format"
    description: "OLE Compound File (Structured Storage) format"
    categories:
    - spreadsheets
    link: "http://www.cs.tu-berlin.de/~schwartz/pmh/index.html"
    deprecated: true                                            
---

## Microsoft Excel Spreadsheet (.xls)

The `.xls` extension denotes a Microsoft Excel workbook in the binary format that
was Excel's default through Excel 2003. Its data is encoded as a stream of typed
BIFF (Binary Interchange File Format) records — describing cells, formulas, shared
strings, styles, and worksheet structure — and that stream is stored inside an OLE
Compound File (Structured Storage), the same container used by binary Word and
PowerPoint documents. It carries the compound-file signature
`D0 CF 11 E0 A1 B1 1A E1`.

A workbook contains one or more worksheets of cells that may hold numbers, text,
dates, and formulas, plus charts, cell and number formatting, defined names, and
optionally VBA macros. From Excel 2007 the default changed to the XML-based,
ZIP-packaged `.xlsx` (Office Open XML), so `.xls` is the legacy binary format and
`.xlsx` its modern replacement; older BIFF versions (Excel 2 through 95) also
exist and differ from the BIFF8 used by Excel 97-2003.

### Preservation And Security Notes

Binary Excel files can embed VBA macros and external data connections, so an
untrusted `.xls` should be treated as potential active content and opened with
macros disabled. Spreadsheets are also subject to formula-injection concerns when
built from untrusted input. For preservation, migrating cell data and formulas to
an open format (Office Open XML, ODF, or CSV for pure data) while keeping the
original preserves both the values and the structure.

### Further Reading

- [MS-XLS] Excel (.xls) Binary File Format: `https://learn.microsoft.com/openspecs/office_file_formats/ms-xls/`
- OpenOffice.org Excel file format documentation (Daniel Rentz): `https://www.openoffice.org/sc/excelfileformat.pdf`
