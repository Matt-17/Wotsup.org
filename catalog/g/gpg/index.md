---
overview: ".gpg files are binary OpenPGP data produced by GnuPG: encrypted files, signatures, or exported keys, depending on the content (also seen as .pgp)."
extensions:
  - name: "OpenPGP binary data (GnuPG)"
    description: "Binary OpenPGP packets: encrypted data, signatures, or keys, as created by GnuPG"
    categories:
    - data-format
    - misc
    author: "IETF OpenPGP Working Group / GnuPG Project"
    link: "https://www.rfc-editor.org/rfc/rfc9580"
---

## GPG (OpenPGP binary data)

A `.gpg` file is data in the OpenPGP format written by GnuPG (GNU Privacy Guard),
the most common implementation of the standard. The extension is used by the
`gpg` tool for encrypted files (`gpg --encrypt` or `--symmetric`), for detached
or combined signatures, and for exported keys and keyrings. The extension does
not tell which of these it is. `.pgp` is used by other implementations, and
`.asc` stands for the same data in a text encoding.

### Structure

OpenPGP, standardized in RFC 4880 and revised by RFC 9580, represents everything
as a sequence of packets: public-key and secret-key packets, user IDs, signatures,
and encrypted data packets, each with a tag and a length. Encrypted files
typically hold one or more session-key packets, which wrap a random key for each
recipient's public key or a passphrase, followed by symmetrically encrypted data.
Signatures can be embedded or stored in a separate file.

### Tooling

GnuPG (`gpg --list-packets` shows the packet structure), Gpg4win, GPG Suite,
Sequoia-PGP, and many mail clients and package managers handle OpenPGP. GnuPG
2.1 and later store secret keys in a private-keys directory rather than a
single keyring file.

### Preservation And Security Notes

Decrypting an old file needs the private key and its passphrase, so these must
be preserved separately and securely, or the data is permanently lost. Older
files may use algorithms now considered weak. Exported secret keys should be
kept as protected as passwords.

### Further Reading

- RFC 9580, OpenPGP: `https://www.rfc-editor.org/rfc/rfc9580`
- RFC 4880, OpenPGP Message Format: `https://www.rfc-editor.org/rfc/rfc4880`
- GnuPG documentation: `https://gnupg.org/documentation/`
