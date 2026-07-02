---
overview: ".jar files are Java Archives: ZIP-based container files that bundle compiled Java classes, resources, and a manifest so libraries and applications can be distributed and loaded as a single unit."
extensions:
  - name: "Java Archive (JAR) format"
    description: "ZIP-based container for Java classes, resources, and manifest metadata"
    categories:
    - archive
    author: "Sun Microsystems / Oracle"
    link: "https://docs.oracle.com/javase/8/docs/technotes/guides/jar/jar.html"
    file: jar.zip
---

## Java Archive (JAR)

A JAR file packages the compiled parts of a Java program — `.class` files,
images, property files, and other resources — into one file so it can be moved,
versioned, and loaded as a unit. JARs are the standard distribution format for
Java libraries, application components, plug-ins, and runnable programs, and
they are consumed directly by the Java class loader without being unpacked
first.

Structurally, a JAR is a ZIP archive. It uses the same central directory, local
file headers, and DEFLATE compression as `.zip`, so general ZIP tools can list
and extract its contents. What makes it a JAR rather than a plain archive is the
`META-INF/` directory, in particular `META-INF/MANIFEST.MF`, which records
attributes such as the manifest version, the `Main-Class` entry point for
executable JARs, class-path references, and per-entry signing digests.

### Manifests, Signing, And Variants

The manifest lets a JAR describe itself: an executable JAR names its
`Main-Class` so it can be launched with `java -jar`, and a library JAR can
declare a `Class-Path` or module information. JARs can be cryptographically
signed, in which case `META-INF/` holds signature and digest files that let a
runtime verify the archive has not been altered.

Several related formats reuse the JAR layout with different extensions and
runtime meaning, including `.war` for web applications, `.ear` for enterprise
applications, and `.apk` for Android packages. These share the ZIP/JAR
structure but should be identified by their own extension and deployment
context rather than treated as plain JARs.

### Preservation Notes

The standard media type is `application/java-archive`. For preservation, keep
the original archive intact rather than re-zipping it, because re-compression
can invalidate embedded signatures and change entry ordering. Record the target
Java version, module or class-path expectations, and any external dependencies,
since a JAR is rarely self-contained at runtime.

### Security Notes

A JAR is executable code delivered as an archive. Tools that expand untrusted
JARs should guard against path-traversal ("zip slip") entries, oversized or
zip-bomb members, and unexpected `META-INF/` content. Running or loading a JAR
means running its bytecode, so unsigned or unverified archives from untrusted
sources should be treated as untrusted software, not just as data files.

### Further Reading

- JAR File Specification: `https://docs.oracle.com/javase/8/docs/technotes/guides/jar/jar.html`
- ZIP application note (underlying container): `https://pkware.cachefly.net/webdocs/casestudies/APPNOTE.TXT`
