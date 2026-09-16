---
overview: ".parquet files are Apache Parquet files: an open columnar storage format for analytical data, with efficient compression and encoding."
extensions:
  - name: "Apache Parquet"
    description: "Open-source columnar binary file format for analytics and big data"
    categories:
    - data-format
    - databases
    author: "Apache Software Foundation"
    link: "https://parquet.apache.org/docs/file-format/"
---

## Apache Parquet

Apache Parquet is a columnar file format designed for efficient storage and
querying of large tabular datasets. Instead of storing records row by row, it
stores the values of each column together, which allows better compression and
lets queries read only the columns they need. It is an Apache Software Foundation
project and is widely used in the Hadoop and data-lake ecosystems.

A Parquet file begins and ends with the four-byte magic number `PAR1`. The data is
split into row groups; within each row group, each column is stored as a column
chunk divided into pages, with encodings and compression codecs chosen per column
(for example dictionary and run-length encoding, with codecs such as Snappy,
Gzip, or Zstandard). A footer holds the file metadata, including the schema,
row group locations, and column statistics, and is stored in Thrift format. The
data model supports nested structures such as structs, lists, and maps. The
media type `application/vnd.apache.parquet` is registered with IANA.

### Adoption

Parquet is read and written by Apache Spark, Hive, Impala, Trino, DuckDB, pandas,
Apache Arrow, and most cloud data warehouses. It is a common file format for
data lakes and for dataset distribution.

### Preservation And Security Notes

The format is open and documented, and the schema is embedded in each file, which
helps long-term readability. Readers and writers differ in which encodings,
codecs, and logical types they support, so check compatibility when exchanging
files. Parquet files are a poor fit for editing individual records. When
reading untrusted files, bound memory use: highly compressed pages can expand
greatly and metadata may claim large sizes.

### Further Reading

- Parquet file format documentation: `https://parquet.apache.org/docs/file-format/`
- Parquet format repository: `https://github.com/apache/parquet-format`
- IANA media type registration: `https://www.iana.org/assignments/media-types/application/vnd.apache.parquet`
