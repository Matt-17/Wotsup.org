---
overview: ".class files contain compiled Java bytecode: one class or interface per file, in the class file format defined by the Java Virtual Machine Specification."
extensions:
  - name: "Java class file"
    description: "Compiled Java class or interface in JVM bytecode format"
    categories:
    - binaries
    author: "Oracle"
    link: "https://docs.oracle.com/javase/specs/jvms/se21/html/jvms-4.html"
---

## CLASS (Java Class File)

A `.class` file is produced by a Java compiler and holds the compiled form of
one class or interface. It contains bytecode for the Java Virtual Machine (JVM),
which loads and runs it on any platform that provides a JVM. Other languages for
the JVM, such as Kotlin, Scala, and Groovy, also compile to this format. Class
files are usually distributed together in `.jar` archives.

### Structure

Every class file begins with the magic number `0xCAFEBABE`, followed by a minor
and a major version number. The major version identifies the Java release that
produced it; for example, 52 corresponds to Java 8, and each later release
increases the number by one. A JVM refuses class files with a version newer than
it supports. After the header come the constant pool, access flags, the class
and superclass references, interfaces, fields, methods (including their
bytecode), and attributes such as debug information and annotations. All
multi-byte values are stored big-endian.

### Tooling

The JDK includes `javap` to disassemble class files. Many decompilers can
reconstruct source code approximately from them, because bytecode retains much
structural information. The `0xCAFEBABE` magic is also used by Mach-O universal
binaries, so the first bytes alone do not identify the format.

### Preservation And Security Notes

Keep the source code and the JDK version used to build when preserving Java
software, since class file versions are not backward-compatible with older
JVMs. The JVM verifies bytecode when loading, but class files from untrusted
sources should still be treated as executable code.

### Further Reading

- The class File Format, Java Virtual Machine Specification: `https://docs.oracle.com/javase/specs/jvms/se21/html/jvms-4.html`
