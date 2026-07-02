---
overview: ".mdb files are Microsoft Access databases: single-file relational databases built on the Jet/ACE engine that hold tables, queries, forms, reports, and application logic together in one file."
extensions:
  - name: "Microsoft Access Database (MDB) format"
    description: "Single-file Jet/ACE relational database used by Microsoft Access"
    categories:
    - databases
    author: "Microsoft"
    link: "https://en.wikipedia.org/wiki/Microsoft_Access"
---

## Microsoft Access Database (MDB)

An `.mdb` file is a self-contained Microsoft Access database. Unlike a
client/server database, the whole database — table definitions, row data,
indexes, relationships, queries, and often the application user interface —
lives inside a single file backed by the Jet database engine. This made MDB a
popular format for departmental applications, desktop data tools, and data
handed between users as a single attachment.

Beyond raw tables, an `.mdb` can embed a complete application: parameterized
queries, forms, reports, macros, and VBA modules. That means the file often
carries both data and executable logic, which is important when assessing,
migrating, or archiving it.

### Versions And The ACE Successor

MDB is the format used through Access 2003 and the Jet engine. Access 2007
introduced the `.accdb` format and the Access Connectivity Engine (ACE), which
added features such as multi-value and attachment fields and stronger
encryption, while dropping some legacy replication and user-level security
features. Both formats remain in use, and tools frequently need to distinguish
them because a `.mdb` and an `.accdb` are not byte-compatible.

The file format itself is proprietary and was reverse-engineered by the
community. Open-source projects such as MDB Tools allow reading table schemas
and exporting data from `.mdb` files on platforms without Access installed,
which is valuable for extraction and preservation workflows.

### Preservation Notes

Because an MDB can contain queries, forms, and VBA rather than just data, a
faithful archive may need to record the Access version, linked external tables,
and any application logic — not only the table contents. For long-term
preservation, exporting tables to an open, documented format (such as CSV or
SQL) alongside the original file preserves the data even where the Access
runtime is unavailable.

### Security Notes

MDB files can contain VBA macros and can link to external data sources, so an
untrusted `.mdb` should be treated as potentially active content, not inert
data. Historic Jet security relied on a shared workgroup file and weak
encryption that should not be considered protective today. Open unknown Access
databases with macros disabled and inspect embedded code before trusting it.

### Further Reading

- Microsoft Access overview: `https://en.wikipedia.org/wiki/Microsoft_Access`
- MDB Tools project: `https://github.com/mdbtools/mdbtools`
