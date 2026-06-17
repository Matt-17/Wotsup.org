---
extensions:
  - name: "ISO 32000-2:2020, PDF 2.0"
    description: "Current base PDF standard, ISO 32000-2:2020"
    categories:
    - documents
    author: "ISO"
    link: "https://www.iso.org/standard/75839.html"

  - name: "Adobe PDF Reference, version 1.6"
    description: "Adobe PDF Reference, version 1.6"
    categories:
    - documents
    author: "Adobe"
    file: pdfreference16.pdf
    
  - name: "Adobe PDF Reference, version 1.7"
    description: "Adobe PDF Reference, version 1.7"
    categories:
    - documents
    author: "Adobe"
    file: pdfreference17.pdf
    
  - name: "Adobe PDF Reference, version 1.3"
    description: "Portable Document Format Reference Manual Version 1.3, March 11, 1999"
    categories:
    - documents
    author: "Adobe"
    file: pdfspec.zip
    
---

## Deep Dive

PDF is a fixed-layout document format designed to preserve page appearance
across software, printers, and operating systems. PDF originated with Adobe,
but the base format is now standardized through ISO 32000. The current base
standard is ISO 32000-2:2020, PDF 2.0. The format matters because it is a
publication format, an exchange format, a print workflow format, a forms
container, and a long-term preservation target.

## Object Model

A PDF file is organized as numbered indirect objects. Objects may describe page
trees, fonts, images, vector graphics, annotations, metadata, forms, embedded
files, encryption dictionaries, and content streams. A page usually references
resources such as fonts and images, then points to one or more content streams
that contain drawing operators.

PDF readers locate objects through a cross-reference table or cross-reference
stream. The trailer dictionary points to the document catalog, which acts as the
root of the object graph. Later PDF versions allow object streams and compressed
cross-reference streams, which reduce file size but make manual inspection more
difficult.

## Incremental Updates

PDF supports incremental saving. Instead of rewriting the whole file, an editor
can append new objects, a new cross-reference section, and a new trailer. This
is useful for signatures, annotations, and workflow edits, but it means older
content may remain physically present in the file even when it is no longer
visible. Redaction tools must remove sensitive content, not merely cover it with
new drawing instructions.

## Identification

Most PDF files begin with a header such as `%PDF-1.7` or `%PDF-2.0`.
Binary-safe PDFs commonly include a comment line containing non-ASCII bytes near
the beginning of the file so transfer systems do not mistake the document for
plain text. The end of the file normally contains `%%EOF`, but robust readers
often tolerate trailing bytes or damaged offsets because PDFs are common in
email, web, and scan workflows.

## Preservation Profiles

Not every valid PDF is suitable for long-term preservation. PDF/A profiles vary
by part and conformance level, but broadly restrict features that create
external dependencies, active behavior, or uncertain rendering, such as
unembedded fonts, encryption, executable actions, and device-dependent color.
For archival use, prefer a validated PDF/A profile, embedded fonts, explicit
metadata, stable color management, and accessible structure when possible.

## Security Notes

PDF is complex enough to be a frequent attack surface. Risky features include
JavaScript, launch actions, embedded files, rich media, malformed streams, and
parser differences between readers. Safe processing pipelines should use
well-maintained libraries, disable active content where possible, and treat
rendering, text extraction, and validation as separate tasks.

## Further Reading

- ISO 32000-2:2020: `https://www.iso.org/standard/75839.html`
- PDF Association specification archive: `https://pdfa.org/resource/pdf-specification-archive/`
- Related profiles: PDF/A, PDF/X, PDF/UA, PDF/E
