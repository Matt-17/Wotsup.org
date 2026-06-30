---
overview: ".svg files store Scalable Vector Graphics: XML-based vector and mixed vector/raster graphics used for icons, diagrams, illustrations, maps, and web graphics."
extensions:
  - name: "Scalable Vector Graphics (SVG) format"
    description: "XML-based vector graphics format for scalable two-dimensional graphics, styling, animation, and embedding on the web"
    categories:
    - 2d-graphics
    author: "World Wide Web Consortium (W3C)"
    link: "https://www.w3.org/TR/SVG2/"
---

## Scalable Vector Graphics (SVG)

SVG is a W3C graphics format for describing two-dimensional vector and mixed
vector/raster images in XML. It is widely used for logos, icons, diagrams,
technical drawings, maps, data visualization, and web interface artwork because
the same file can scale cleanly across different output sizes and display
resolutions.

An SVG document is built from elements such as `svg`, `g`, `path`, `rect`,
`circle`, `text`, `defs`, `symbol`, `use`, `image`, and `metadata`. Shapes are
painted with fills, strokes, gradients, patterns, masks, filters, clipping
paths, transforms, and CSS styling. Raster images can be referenced or embedded,
so an `.svg` file may depend on external assets even though the outer format is
text-based.

### Web And Document Use

The standard media type is `image/svg+xml`. SVG can be served as a standalone
image, embedded in HTML, inlined directly into an HTML document, or embedded
inside other XML-based formats. The compressed form is commonly named `.svgz`
when an SVG document is gzip-compressed as a file, although HTTP compression of
a normal `.svg` response is usually preferred for web delivery.

SVG support varies by environment. Browsers generally implement the web-focused
interactive subset, while office suites, illustration tools, asset pipelines,
print workflows, and game engines may ignore scripting, fonts, filters,
animation, CSS features, linked resources, or newer SVG 2 behavior. For
interchange, avoid depending on a single application's private metadata and
test the exact features needed by the target renderer.

### Preservation And Accessibility Notes

SVG is useful for preservation because much of the structure remains readable
as text, but reproducible rendering still depends on fonts, CSS, external
images, linked resources, and implementation-specific filter or text layout
behavior. Important assets should be embedded or stored alongside the SVG with
stable relative paths, and conversion pipelines should record the renderer and
font versions used for any raster or print derivatives.

Accessible SVGs can include `title`, `desc`, ARIA attributes, text elements,
and meaningful document structure. However, an SVG exported from a drawing
program may flatten text to paths or use unnamed groups, so accessibility
metadata should be reviewed separately from visual appearance.

### Security Notes

SVG is not just a bitmap. It can include links, scripts, animation, CSS,
external resource references, embedded raster data, and XML constructs. Systems
that accept untrusted SVG should sanitize it according to the intended display
mode, disable active content where appropriate, restrict external fetches, and
parse XML with protections against entity expansion and resource exhaustion.

### Further Reading

- W3C SVG 2 specification: `https://www.w3.org/TR/SVG2/`
- W3C SVG overview: `https://www.w3.org/Graphics/SVG/`
