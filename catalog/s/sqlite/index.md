---
overview: ".sqlite files are SQLite databases: a complete relational database contained in a single cross-platform file, the most widely deployed database engine, embedded in browsers, phones, and applications everywhere."
extensions:
  - name: "SQLite database file"
    description: "Self-contained, single-file relational (SQL) database"
    categories:
    - databases
    author: "D. Richard Hipp / SQLite team"
    link: "https://www.sqlite.org/fileformat2.html"
---

## SQLite Database

SQLite is a self-contained, serverless relational database engine whose entire
database — tables, indexes, views, triggers, and the data itself — lives in a single
ordinary file. There is no separate server process: applications link the SQLite
library and read and write the file directly. This simplicity, combined with a small
footprint and a permissive public-domain license, has made SQLite the most widely
deployed database in the world, embedded in web browsers, mobile operating systems,
aircraft, and countless desktop and server applications. It is also endorsed as a
recommended format for long-term data archiving.

The file format is stable, openly documented, and cross-platform. A database is a
sequence of fixed-size pages beginning with a 100-byte header that starts with the
string `SQLite format 3\000`. Pages hold B-tree structures for tables and indexes,
and the schema itself is stored as rows in an internal table. SQLite is transactional
(ACID): a rollback journal or write-ahead log (WAL) ensures that changes are atomic
and durable even across crashes, and readers can access the file while a writer works.

### Use And Preservation Notes

Because a whole database is one portable file, SQLite is ideal as an application file
format and for shipping datasets. Its documented, backward-compatible format and
independence from any server make it well suited to preservation; keeping the schema
(which is embedded) means the data remains interpretable with any SQLite-capable
tool. The common media type is `application/vnd.sqlite3`.

### Security Notes

An SQLite file is data, but opening one runs SQL against it, and the file can define
triggers and views; untrusted database files should be opened with care, using
current library versions and appropriate limits, since malformed files have
historically exposed parser bugs. Applications must also use parameterized queries to
avoid SQL injection.

### Further Reading

- SQLite database file format: `https://www.sqlite.org/fileformat2.html`
- SQLite as an archival format: `https://www.sqlite.org/locrsf.html`
