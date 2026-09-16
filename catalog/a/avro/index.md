---
overview: ".avro files are Apache Avro object container files: a compact binary data serialization format with an embedded schema, widely used in Hadoop and streaming pipelines."
extensions:
  - name: "Apache Avro"
    description: "Schema-based binary data serialization and container file format"
    categories:
    - data-format
    - databases
    author: "Apache Software Foundation"
    link: "https://avro.apache.org/docs/current/specification/"
---

## Apache Avro

Apache Avro is a data serialization system that defines data with a schema written
in JSON and encodes records in a compact binary form. It originated in the Apache
Hadoop project and is used for storing data in data lakes and for messages in
streaming systems such as Apache Kafka. An `.avro` file normally holds an Avro
object container file.

An object container file starts with the four magic bytes `Obj` followed by the
byte `0x01`. The header contains file metadata, including the writer schema
(under the key `avro.schema`) and an optional compression codec (`avro.codec`,
where `null` and `deflate` are required and others such as Snappy are supported
by many implementations), followed by a randomly generated 16-byte sync marker.
The rest of the file consists of data blocks, each holding a count of objects,
the serialized size, the encoded records, and the sync marker. The sync marker
allows readers to split a file and process blocks in parallel.

### Schema Evolution

Because the schema travels with the data, readers can resolve differences between
the writer schema and their own, which supports adding or removing fields and
other compatible changes. This is a main reason for its use in event pipelines.
Unlike Parquet, Avro is row-oriented, which suits writing whole records and
streaming rather than column-selective analytics.

### Preservation And Security Notes

The embedded schema makes files self-describing and well suited to long-term
storage. Libraries exist for Java, Python, C, C++, C#, and other languages. When
reading untrusted files, bound allocation sizes taken from length fields and
limit schema complexity and recursion.

### Further Reading

- Avro specification: `https://avro.apache.org/docs/current/specification/`
- Apache Avro project: `https://avro.apache.org/`
