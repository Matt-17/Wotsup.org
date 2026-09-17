---
overview: ".pst files are Microsoft Outlook Personal Storage Table files: a proprietary container holding email messages, calendar items, contacts, and other Outlook data."
extensions:
  - name: "Outlook Personal Storage Table (PST)"
    description: "Microsoft Outlook personal folders file for mail, calendar, and contact data (see also .ost)"
    categories:
    - communication-formats
    - windows
    author: "Microsoft"
    link: "https://learn.microsoft.com/openspecs/office_file_formats/ms-pst/141923d5-15ab-4ef1-a524-6dce75aae546"
---

## Outlook Personal Storage Table (PST)

A PST file is the personal folders store used by Microsoft Outlook to keep
messages, calendar entries, contacts, tasks, and notes on a local disk. It is
commonly used for archives, for exporting mailboxes, and for importing mail
into another account. The related `.ost` offline storage file uses the same
underlying structure and serves as a local cache of an Exchange or Microsoft 365
mailbox.

Microsoft documents the format in the Open Specifications document MS-PST. A PST
file starts with the signature `!BDN` and uses a layered design: the NDB (Node
Database) layer manages blocks and nodes with B-tree structures, the LTP (Lists,
Tables, and Properties) layer builds property sets and tables on top of it, and
the Messaging layer defines folders, messages, and attachments. Two versions
exist: the older ANSI format used by early Outlook versions, which has a 2 GB
size limit, and the Unicode format introduced with Outlook 2003, which supports
much larger files. A file may be protected with a password or encoded with
compressible or high encryption, which is obfuscation rather than strong security.

### Tooling

Outlook reads and writes PST files, and libraries such as libpst and libpff can
extract messages without Outlook, often converting to mbox or EML. Individual
messages may also be saved as `.msg` files.

### Preservation And Security Notes

Large PST files are prone to corruption and are not recommended as primary
storage; for preservation, export messages to open formats such as EML or mbox
alongside the original. The built-in password does not securely protect the
contents. PST files can contain attachments with malware, so process
untrusted files in an isolated environment.

### Further Reading

- MS-PST Outlook Personal Folders File Format: `https://learn.microsoft.com/openspecs/office_file_formats/ms-pst/141923d5-15ab-4ef1-a524-6dce75aae546`
