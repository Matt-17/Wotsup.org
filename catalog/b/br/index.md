---
overview: ".br files are Brotli-compressed data: a lossless compression format developed by Google that combines LZ77, Huffman coding, and a built-in static dictionary, widely used for web content."
extensions:
  - name: "Brotli compressed data"
    description: "General-purpose lossless compression format standardized in RFC 7932"
    categories:
    - archive
    - internet
    author: "Google"
    link: "https://datatracker.ietf.org/doc/html/rfc7932"
---

## Brotli

Brotli is a lossless compression format created at Google and specified in
RFC 7932 (2016). It combines an LZ77-style match finder, Huffman coding, and
context modeling with a static dictionary of common words and phrases from
web content such as HTML, CSS, JavaScript, and several human languages. The
dictionary helps compress small text resources in particular. Brotli
generally compresses text better than gzip at comparable decompression
speed, though its highest levels are slow to compress.

### Technical Notes

A Brotli stream is a sequence of meta-blocks. Unlike many compressed formats,
it has no magic number or file header, and the specification defines only the
compressed stream, so the `.br` extension identifies the content by
convention. The stream has no built-in checksum. On the web, Brotli is
negotiated through the HTTP header `Content-Encoding: br`, which browsers
advertise in `Accept-Encoding`.

### Adoption

All major browsers support Brotli, and web servers and content delivery
networks commonly offer it. Build tools often precompress static assets to
`.br` files (for example `app.js.br`) at a high level for serving. The
reference implementation is open source, and bindings exist for many
languages. Brotli is also the compression used inside the WOFF2 font format.

### Preservation And Security Notes

Brotli files are best treated as delivery copies; store originals alongside
them. Because the format has no integrity check, use external hashes for
important data. Decompressors for untrusted input should limit output size
to avoid decompression bombs.

### Further Reading

- Brotli reference implementation: `https://github.com/google/brotli`
- RFC 7932, Brotli Compressed Data Format: `https://datatracker.ietf.org/doc/html/rfc7932`
