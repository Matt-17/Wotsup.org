---
overview: ".cer files are X.509 certificate files, commonly DER-encoded or PEM-encoded, as used by Windows and many certificate authorities."
extensions:
  - name: "X.509 certificate (.cer)"
    description: "Public-key certificate in DER or PEM encoding, the usual extension on Windows"
    categories:
    - data-format
    - internet
    - windows
    author: "IETF"
    link: "https://www.rfc-editor.org/rfc/rfc5280"
---

## CER (X.509 Certificate)

A `.cer` file contains a single X.509 certificate: a public key together with
identity information, signed by a certificate authority (or by the owner in the
case of self-signed certificates). The extension is the one Windows uses for
certificates when they are exported or shown in the certificate viewer, and
many certificate authorities supply downloads with this extension. It holds the
same kind of data as `.crt` and `.pem` files.

### Structure

The certificate is an ASN.1 structure defined in RFC 5280. The `.cer` extension
does not fix the encoding: Windows offers "DER encoded binary X.509" and
"Base-64 encoded X.509" when exporting, and both are saved as `.cer`. A binary
file starts with the DER sequence tag `0x30`, while a Base-64 file is text
between `-----BEGIN CERTIFICATE-----` and `-----END CERTIFICATE-----`. Related
formats are `.p7b`/`.p7c` (PKCS #7 certificate chains without private keys) and
`.pfx`/`.p12` (bundles that include a private key).

### Tooling

Windows opens `.cer` files in its certificate dialog, and OpenSSL, Java's
`keytool`, and browsers can import them. Use `openssl x509 -inform DER` or
`-inform PEM` as appropriate to inspect a file.

### Preservation And Security Notes

A `.cer` file contains no private key and can be shared. Certificates have a
limited validity period; keep the issuing chain if the certificate needs to be
verified later. Import certificates into a trusted store only from sources you
trust.

### Further Reading

- RFC 5280, Internet X.509 PKI Certificate and CRL Profile: `https://www.rfc-editor.org/rfc/rfc5280`
- RFC 2315, PKCS #7: Cryptographic Message Syntax: `https://www.rfc-editor.org/rfc/rfc2315`
