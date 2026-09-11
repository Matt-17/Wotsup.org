---
overview: ".mbox files are mailbox files: plain-text archives that store many e-mail messages in one file, originating on Unix systems and used by many mail clients."
extensions:
  - name: "mbox mailbox format"
    description: "Concatenated e-mail messages in one text file, each introduced by a From line"
    categories:
    - communication-formats
    - internet
    author: "IETF (RFC 4155)"
    link: "https://www.rfc-editor.org/rfc/rfc4155"
---

## MBOX

The mbox format stores a collection of e-mail messages as one text file. It
comes from early Unix mail systems and has several incompatible variants. RFC
4155 documents the common form and registers the media type `application/mbox`.
The extension `.mbox` is used by clients such as Mozilla Thunderbird and for
exports from services such as Google Takeout, while Unix mail folders often
have no extension at all.

### Structure

Messages are stored one after another. Each message begins with a separator line
that starts with the five characters `From ` (with a space) followed by the
sender address and a date. The following lines are the message's RFC 5322 header
and body. A blank line precedes the next separator. To keep body lines from being
mistaken for separators, lines in the body that start with `From ` are escaped,
usually by prefixing `>`. The variants differ in how they do this: `mboxo` only
escapes `From ` lines, `mboxrd` also escapes lines that already start with
`>From ` so the process can be reversed, and `mboxcl` and `mboxcl2` use a
`Content-Length` header instead.

### Adoption

Many mail clients and mail servers can import and export mbox. Because the
whole mailbox is one file, it is easy to copy and process with text tools, but
it needs file locking when several programs access it and can be slow to
modify or search when it becomes very large.

### Preservation And Security Notes

Because of the variant differences, record which variant was used for an export
and check that message counts match after migration. Mailboxes contain
personal data and attachments encoded as MIME, so treat them as sensitive and
scan attachments with the same care as any e-mail.

### Further Reading

- RFC 4155, The application/mbox Media Type: `https://www.rfc-editor.org/rfc/rfc4155`
