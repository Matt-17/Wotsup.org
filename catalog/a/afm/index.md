---
overview: ".afm files are Adobe Font Metrics: plain-text files describing the metrics of a PostScript Type 1 font — character widths, kerning, and bounding boxes — without containing the glyph outlines themselves."
extensions:
  - name: "Adobe Font Metrics File Format Specification Version 4.1 (Acrobat)"
    description: "Adobe Font Metrics File Format Specification Version 4.1 (Acrobat)"
    categories:
    - fonts
    author: "Adobe"
    file: afm.zip
---

## Adobe Font Metrics (AFM)

AFM is a plain-text format from Adobe that records the metric information of a
PostScript Type 1 font. Crucially, it does not contain the glyph outlines — those
live in the font program itself (a `.pfb` or `.pfa` file) — but instead the
measurements a layout program needs to set type: the advance width of each
character, its bounding box, the character-name-to-code mapping, and kerning pairs
that adjust spacing between specific character combinations.

This separation reflects how PostScript fonts were distributed: the printer or
interpreter held the outline program, while applications on the host used the AFM
to compute line breaks, justification, and text positioning without needing the
outlines. Because it is human-readable text organized into clearly labeled
sections (such as `StartCharMetrics` and `StartKernPairs`), an AFM is easy to parse
and inspect.

### Status And Preservation Notes

AFM is a legacy companion format from the Type 1 era; modern outline formats such
as TrueType and OpenType embed their metrics directly, so separate metric files are
no longer needed. For preservation of a Type 1 font, the AFM should be kept together
with the corresponding outline program and encoding files, since it is only
meaningful alongside them.

### Security Notes

As simple, well-structured text, AFM poses little parsing risk, but a reader should
still handle malformed or truncated metric and kern-pair entries gracefully.

### Further Reading

- Adobe Font Metrics File Format Specification: `https://adobe-type-tools.github.io/font-tech-notes/pdfs/5004.AFM_Spec.pdf`
