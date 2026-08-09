---
overview: ".md files are Markdown documents: a lightweight plain-text markup syntax that stays readable as source while converting cleanly to HTML, widely used for READMEs, documentation, notes, and static sites."
extensions:
  - name: "Markdown"
    description: "Lightweight plain-text markup that converts to HTML"
    categories:
    - documents
    - internet
    author: "John Gruber / CommonMark"
    link: "https://commonmark.org/"
---

## Markdown

Markdown is a lightweight markup language created by John Gruber with the goal that
the source text should be as readable as possible on its own, while still converting
cleanly to HTML. Instead of tags, it uses unobtrusive punctuation conventions — `#`
for headings, `*` or `_` for emphasis, `-` for list items, backticks for code, and
`[text](url)` for links — so a `.md` file reads naturally in a plain editor and
renders as formatted output when processed. This balance made it the default format
for software READMEs, documentation, wikis, forum and chat messages, note-taking
apps, and static-site generators.

Because the original description left some behavior unspecified, many
implementations diverged, and the CommonMark specification was created to define
Markdown precisely and improve interoperability. Popular supersets such as GitHub
Flavored Markdown add tables, task lists, strikethrough, and fenced code blocks with
syntax highlighting.

### Extensions And Front Matter

Markdown is frequently combined with other conventions: a YAML "front matter" block
at the top of a file carries metadata for site generators, and many toolchains allow
embedded raw HTML for anything Markdown itself does not express. As a result the
exact feature set depends on the processor, which should be recorded for
reproducibility.

### Preservation And Security Notes

Markdown is ideal for preservation: it is open, plain text, human-readable even
without rendering, and diff-friendly for version control. When converting Markdown
from untrusted sources to HTML, sanitize the output (and any embedded raw HTML) to
prevent cross-site scripting. The common media type is `text/markdown`.

### Further Reading

- CommonMark specification: `https://commonmark.org/`
- GitHub Flavored Markdown spec: `https://github.github.com/gfm/`
