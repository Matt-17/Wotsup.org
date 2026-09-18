---
overview: ".gpx files are GPS Exchange Format documents: an XML format for storing waypoints, routes, and recorded tracks from GPS devices and apps."
extensions:
  - name: "GPX (GPS Exchange Format)"
    description: "XML schema for exchanging GPS waypoints, routes, and tracks between devices and software"
    categories:
    - gis-formats
    - data-format
    author: "TopoGrafix"
    link: "https://www.topografix.com/gpx.asp"
---

## GPX (GPS Exchange Format)

GPX is a lightweight XML format for exchanging GPS data between applications
and devices. It was created by TopoGrafix, and the most widely used version is
GPX 1.1, published in 2004. A GPX file can hold three kinds of data:
waypoints (individual named points), routes (ordered lists of points to
follow), and tracks (recorded sequences of points, organized into track
segments).

### Technical Notes

A GPX file is UTF-8 XML with a root `<gpx>` element carrying a `version` and a
`creator` attribute. Points use `lat` and `lon` attributes in WGS 84 decimal
degrees, with optional child elements such as `ele` (elevation), `time` (UTC
timestamp), `name`, and `desc`. The format defines a metadata block and
supports extensions through an `<extensions>` element, which device makers
use for data such as heart rate or cadence. The schema is published as an XSD
by TopoGrafix.

### Adoption

GPX is supported by hiking, cycling, and running apps, handheld GPS units,
navigation software, and GIS tools, making it the common interchange format
for GPS tracks. It is not designed for general geographic features; use
GeoJSON or KML for those purposes.

### Preservation And Security Notes

The format is open, textual, and simple to parse. Tracks often reveal home
addresses and routines, so consider stripping or reducing location data
before sharing files. Extension elements are vendor-specific, so keep
documentation for any extensions used. Parsers should disable external entity
processing when reading untrusted files.

### Further Reading

- GPX 1.1 schema documentation: `https://www.topografix.com/GPX/1/1/`
- GPX developer information (TopoGrafix): `https://www.topografix.com/gpx.asp`
- GPX manual: `https://www.topografix.com/gpx_manual.asp`
