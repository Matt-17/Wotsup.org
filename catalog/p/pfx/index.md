---
overview: ".pfx files are PKCS #12 archives (also named .p12), the traditional Windows extension for password-protected bundles of private keys and certificates."
extensions:
  - name: "Personal Information Exchange (PFX / PKCS #12)"
    description: "Windows name for PKCS #12 bundles with private key and certificate chain"
    categories:
    - data-format
    - windows
    author: "Microsoft / RSA Laboratories / IETF"
    link: "https://www.rfc-editor.org/rfc/rfc7292"
---

## PFX (Personal Information Exchange)

PFX is the name Microsoft used for its "Personal Information Exchange" format,
which was the basis for the PKCS #12 standard. Today a `.pfx` file is a PKCS #12
archive, identical to a `.p12` file: a container that holds a private key,
the certificate belonging to it, and optionally intermediate and root
certificates. Windows uses `.pfx` when exporting a certificate with its private
key, and tools such as IIS, Azure services, and code-signing utilities
(`signtool`) import identities from such files.

### Structure

The format is described in RFC 7292 and consists of ASN.1 data in BER/DER
encoding, usually starting with the byte `0x30` (a DER sequence). The content
is organized as safe bags, protected by a password-derived encryption key
and an integrity MAC. Files written by older Windows versions use legacy
algorithms such as 3DES and RC2, whereas newer exports can use AES. Software
that supports only the older algorithms may fail to open modern files and vice
versa.

### Tooling

Windows Certificate Manager (`certmgr.msc`), PowerShell's `Export-PfxCertificate`
and `Import-PfxCertificate`, and OpenSSL (`openssl pkcs12`) can create and read
PFX files. They can be converted to PEM files, with key and certificate stored
separately.

### Preservation And Security Notes

A PFX file contains a private key and is as sensitive as the key itself. Use a
strong password, restrict access, and do not store it in source repositories.
Archive copies should be kept encrypted, with the password stored separately.

### Further Reading

- RFC 7292, PKCS #12: Personal Information Exchange Syntax v1.1: `https://www.rfc-editor.org/rfc/rfc7292`
- openssl-pkcs12 manual: `https://www.openssl.org/docs/manmaster/man1/openssl-pkcs12.html`
