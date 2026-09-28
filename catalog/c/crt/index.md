---
overview: ".crt files are X.509 certificate files, usually PEM-encoded (and sometimes DER-encoded), commonly used on Unix-like systems for TLS and code-signing certificates."
extensions:
  - name: "X.509 certificate (.crt)"
    description: "Public-key certificate in PEM or DER encoding, conventionally used on Unix-like systems"
    categories:
    - data-format
    - internet
    author: "IETF"
    link: "https://www.rfc-editor.org/rfc/rfc5280"
---

## CRT (X.509 Certificate)

A `.crt` file contains an X.509 public-key certificate: a signed statement that
binds a public key to an identity, such as a domain name or an organization. The
extension is mostly used by Unix-like systems, web servers, and certificate
authorities for server certificates and for root and intermediate CA
certificates. The same data is also stored as `.cer`, `.pem`, or `.der`.

### Structure

An X.509 certificate is an ASN.1 structure, defined in RFC 5280, containing a
version, serial number, issuer, validity period, subject, subject public key, and
extensions, followed by the issuing authority's signature. The `.crt` extension
does not specify an encoding. Most `.crt` files are PEM, text between
`-----BEGIN CERTIFICATE-----` and `-----END CERTIFICATE-----`, but binary DER
files with this extension exist too. Tools such as OpenSSL detect or are told
the encoding, for example `openssl x509 -in file.crt -text -noout` for PEM and
`-inform DER` for binary files.

### Adoption

Operating systems and browsers keep trust stores of root certificates; on many
Linux distributions, adding a `.crt` file to a certificate directory and running
an update command makes it trusted system-wide.

### Preservation And Security Notes

A certificate holds only public information and has no private key, so it can be
shared. Certificates expire and can be revoked, so archived ones mainly serve as
a record of identity. Installing an unknown root certificate as trusted allows
its owner to impersonate any site, and should be done only for sources you
trust.

### Further Reading

- RFC 5280, Internet X.509 PKI Certificate and CRL Profile: `https://www.rfc-editor.org/rfc/rfc5280`
- RFC 7468, Textual Encodings of PKIX, PKCS, and CMS Structures: `https://www.rfc-editor.org/rfc/rfc7468`
