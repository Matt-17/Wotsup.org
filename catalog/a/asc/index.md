---
overview: ".asc files are most often ASCII-armored OpenPGP data (signatures, public keys, or encrypted messages in text form), but the extension is also used for plain ASCII text."
extensions:
  - name: "ASCII-armored OpenPGP data"
    description: "Text encoding of OpenPGP signatures, keys, and encrypted messages"
    categories:
    - data-format
    - internet
    author: "IETF OpenPGP Working Group"
    link: "https://www.rfc-editor.org/rfc/rfc9580"
  - name: "ASCII text"
    description: "Plain text restricted to the ASCII character set"
    categories:
    - documents
    author: "IETF / ANSI"
    link: "https://www.rfc-editor.org/rfc/rfc20"
---

## ASC (ASCII-Armored OpenPGP)

The most common use of `.asc` is ASCII armor, the text form of OpenPGP data. It
lets binary data that would otherwise be stored as `.gpg` or `.pgp` pass through
text-only channels such as e-mail and web pages. Software projects usually
publish a detached signature next to a download, such as `release.tar.gz.asc`,
and people share public keys as `.asc` files.

### Structure

ASCII armor, specified in OpenPGP (RFC 4880 and RFC 9580), wraps the Base64
encoding of the binary packets between header and footer lines that show the
content type, for example `-----BEGIN PGP PUBLIC KEY BLOCK-----`,
`-----BEGIN PGP SIGNATURE-----`, or `-----BEGIN PGP MESSAGE-----`. Optional
header lines such as `Version:` or `Comment:` can follow, and the encoded data
may be followed by a CRC-24 checksum line starting with `=`. A clear-signed
message (`-----BEGIN PGP SIGNED MESSAGE-----`) keeps the text readable and puts
the signature after it. Armor makes the data about a third larger than binary.

### Other uses

Outside OpenPGP, `.asc` can simply denote a plain ASCII text file, as in some
scientific and geographic data exports (for example, grids written as text).
Check the content: armor files start with `-----BEGIN PGP`.

### Preservation And Security Notes

A signature file is only useful together with the exact file it signs and the
signer's public key, so archive these together. Verify keys by fingerprint rather
than trusting a key downloaded from the same place as the file. Armored files
marked as private keys must be protected like passwords.

### Further Reading

- RFC 9580, OpenPGP: `https://www.rfc-editor.org/rfc/rfc9580`
- RFC 4880, OpenPGP Message Format (Section 6, Radix-64 Conversions): `https://www.rfc-editor.org/rfc/rfc4880`
- RFC 20, ASCII format for network interchange: `https://www.rfc-editor.org/rfc/rfc20`
