---
overview: ".p12 files are PKCS #12 archives (also named .pfx): password-protected containers holding private keys together with their certificates and certificate chains."
extensions:
  - name: "PKCS #12 personal information exchange"
    description: "Password-protected bundle of private keys and certificates; same format as .pfx"
    categories:
    - data-format
    - internet
    author: "RSA Laboratories / IETF"
    link: "https://www.rfc-editor.org/rfc/rfc7292"
---

## P12 (PKCS #12)

A `.p12` file is a PKCS #12 archive, a format for storing and transporting a
user's private key together with the matching certificate and the chain of
certificates up to a root. It is used to back up and move identities between
systems, for example TLS client certificates, S/MIME e-mail certificates,
code-signing certificates, and Java or Apple signing identities. The identical
format is also stored with the extension `.pfx`, which is the traditional name
on Windows.

### Structure

PKCS #12 is specified in RFC 7292 and is built from ASN.1 structures encoded in
BER/DER. A `PFX` structure holds authenticated-safe data composed of "safe bags"
that carry keys, certificates, and other items. Contents are protected by a
password: the keys and certificates are encrypted, and a MAC over the whole
structure checks integrity. Older files commonly use legacy algorithms such as
3DES and RC2; newer tools default to AES-based encryption, so very old and very
new software may not be able to read each other's files.

### Tooling

OpenSSL (`openssl pkcs12`), Windows certificate manager, macOS Keychain Access,
Java `keytool`, and browsers can import and export `.p12` files. Conversion to
PEM is done with OpenSSL.

### Preservation And Security Notes

The file contains a private key and must be handled as a secret. Its protection
depends on the password strength and on the encryption algorithms used, so
weakly protected legacy files should be re-encrypted. Store such files and their
passwords separately, and never commit them to a repository.

### Further Reading

- RFC 7292, PKCS #12: Personal Information Exchange Syntax v1.1: `https://www.rfc-editor.org/rfc/rfc7292`
- openssl-pkcs12 manual: `https://www.openssl.org/docs/manmaster/man1/openssl-pkcs12.html`
