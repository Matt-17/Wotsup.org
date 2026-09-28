---
overview: ".pem files are Privacy-Enhanced Mail text files: Base64-encoded cryptographic objects such as certificates, keys, and certificate requests wrapped in BEGIN and END lines."
extensions:
  - name: "PEM textual encoding"
    description: "Text encoding for X.509 certificates, keys, and other cryptographic structures"
    categories:
    - data-format
    - internet
    author: "IETF (S. Josefsson, S. Leonard)"
    link: "https://www.rfc-editor.org/rfc/rfc7468"
---

## PEM (Privacy-Enhanced Mail)

PEM is a text format for storing and exchanging binary cryptographic data. The
name comes from the Privacy-Enhanced Mail standards of the early 1990s, but
today the format is used for X.509 certificates, public and private keys,
certificate signing requests, and certificate revocation lists. A `.pem` file
may hold one object or several concatenated ones, such as a certificate chain.

### Structure

Each object is the Base64 encoding of binary data (usually ASN.1 DER) enclosed
between a line `-----BEGIN <LABEL>-----` and a line `-----END <LABEL>-----`. The
label tells the type of content, for example `CERTIFICATE`, `PRIVATE KEY`
(PKCS #8), `PUBLIC KEY`, `RSA PRIVATE KEY` (PKCS #1), `EC PRIVATE KEY`, or
`CERTIFICATE REQUEST`. RFC 7468 describes the textual encodings used by current
tools. Because the file extension does not say what is inside, other extensions
such as `.crt`, `.cer`, `.key`, and `.csr` are often used for PEM files too.

### Tooling

OpenSSL, GnuTLS, and most server software read and write PEM. Conversion to the
binary DER encoding or to PKCS #12 bundles is done with `openssl`.

### Preservation And Security Notes

A PEM file can contain a private key, which must be protected like a password
even though the text looks harmless; keys may be encrypted with a passphrase.
Check the label before sharing a file. Certificates and public keys are public
data, but private keys should never be committed to repositories or published.

### Further Reading

- RFC 7468, Textual Encodings of PKIX, PKCS, and CMS Structures: `https://www.rfc-editor.org/rfc/rfc7468`
- RFC 5280, Internet X.509 PKI Certificate and CRL Profile: `https://www.rfc-editor.org/rfc/rfc5280`
