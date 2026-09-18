---
overview: ".geojson files are GeoJSON documents: a JSON-based format for encoding geographic features such as points, lines, and polygons together with their attributes."
extensions:
  - name: "GeoJSON geographic data"
    description: "JSON format for geographic features, geometries, and properties, standardized in RFC 7946"
    categories:
    - gis-formats
    - data-format
    - internet
    author: "IETF (Butler et al.)"
    link: "https://datatracker.ietf.org/doc/html/rfc7946"
---

## GeoJSON

GeoJSON is a format for representing simple geographic features and their
non-spatial attributes using JSON. A document is a single JSON object whose
`type` member identifies it as a geometry, a `Feature`, or a `FeatureCollection`.
The supported geometry types are `Point`, `MultiPoint`, `LineString`,
`MultiLineString`, `Polygon`, `MultiPolygon`, and `GeometryCollection`. A
`Feature` pairs one geometry with a free-form `properties` object, and a
`FeatureCollection` holds a list of features.

### Technical Notes

GeoJSON is plain UTF-8 text, so it can be read and edited with any text editor
and handled by any JSON parser. Coordinates are arrays of numbers in
longitude, latitude order, with an optional third element for elevation. The
IETF standard, RFC 7946 (2016), fixes the coordinate reference system to WGS 84
and replaced the earlier 2008 community specification, which allowed other
coordinate reference systems. Files commonly use the `.geojson` extension, but
`.json` is also used. The registered media type is `application/geo+json`.

### Adoption

GeoJSON is widely supported by web mapping libraries, GIS desktop software,
spatial databases, and web APIs, and it is a common interchange format for
small and medium datasets. Being text-based, it is verbose for large datasets
and has no built-in spatial index, so formats such as GeoPackage or vector
tiles are often used for large or performance-sensitive data.

### Preservation And Security Notes

The format is open, human-readable, and fully specified, which makes it a
suitable long-term format for vector data. Because geometry is limited to
WGS 84 and attribute schemas are not declared, keep any needed metadata
(such as source, date, and attribute meaning) alongside the file. Parsers
should handle untrusted input defensively, as with any JSON, particularly
deeply nested structures and very large coordinate arrays.

### Further Reading

- GeoJSON site: `https://geojson.org/`
- RFC 7946, The GeoJSON Format: `https://datatracker.ietf.org/doc/html/rfc7946`
