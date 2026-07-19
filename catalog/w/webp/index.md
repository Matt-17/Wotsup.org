---
overview: ".webp files are WebP images: a modern web image format from Google offering both lossy and lossless compression, transparency, and animation, typically smaller than equivalent JPEG, PNG, or GIF."
extensions:
  - name: "WebP image format"
    description: "Modern RIFF-based web image format with lossy, lossless, alpha, and animation support"
    categories:
    - 2d-graphics
    - internet
    author: "Google"
    link: "https://developers.google.com/speed/webp"
---

## WebP

WebP is an image format developed by Google to make web images smaller without
sacrificing quality. It supports both lossy and lossless compression in a single
format, along with an alpha (transparency) channel and animation, so it can serve
as a more efficient replacement for JPEG, PNG, and animated GIF at once. In
typical use, lossy WebP is meaningfully smaller than comparable JPEG, and lossless
WebP is smaller than PNG.

Technically, WebP is packaged in a RIFF container beginning with `RIFF....WEBP`.
Lossy WebP reuses the intra-frame (keyframe) coding of the VP8 video codec, while
lossless WebP uses a dedicated method with transforms and entropy coding designed
for exact reconstruction. Transparency and animation are expressed through
extended chunks (`VP8X`, `ALPH`, `ANIM`/`ANMF`), which is why a single format can
cover so many cases.

### Adoption

WebP is now supported by all major browsers and by most image tooling, which has
made it a common default for optimized web delivery. It is often produced
automatically by build pipelines and content delivery networks that negotiate the
best format per client. The media type is `image/webp`.

### Preservation And Security Notes

Lossy WebP discards data like JPEG, so for archiving keep an original master and
treat WebP as a delivery derivative; lossless WebP is suitable where exact pixels
matter. As with any codec, WebP decoders have been targeted by memory-safety
vulnerabilities, so software handling untrusted WebP should validate chunk sizes
and dimensions and stay patched against known decoder issues.

### Further Reading

- WebP documentation (Google): `https://developers.google.com/speed/webp`
- WebP container specification: `https://developers.google.com/speed/webp/docs/riff_container`
