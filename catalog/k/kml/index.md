---
overview: ".kml files are Keyhole Markup Language documents: an XML format for describing geographic placemarks, paths, polygons, overlays, and styling for display in earth browsers and mapping software."
extensions:
  - name: "KML (Keyhole Markup Language)"
    description: "XML-based geographic annotation and visualization format, an OGC standard"
    categories:
    - gis-formats
    - data-format
    author: "Google / Open Geospatial Consortium"
    link: "https://www.ogc.org/standards/kml/"
  - name: "KML reference"
    description: "Google reference documentation for KML elements"
    categories:
    - gis-formats
    author: "Google"
    link: "https://developers.google.com/kml/documentation/kmlreference"
---

## KML (Keyhole Markup Language)

KML is an XML-based language for expressing geographic data and how it should
be presented. It was developed for Keyhole's EarthViewer, which became Google
Earth, and was adopted as an Open Geospatial Consortium (OGC) standard in 2008.
A KML file describes features such as placemarks, lines, polygons, and 3D
models, along with styles, descriptions, ground and screen overlays, camera
views, and time information.

### Technical Notes

A KML file is UTF-8 XML whose root element is `<kml>` in the OGC KML
namespace, typically containing a `Document` or `Folder` of `Placemark`
elements. Coordinates are written as longitude, latitude, and optional
altitude. Features can reference remote resources through `NetworkLink`, which
lets a file load or refresh content from a server. When a KML file needs to
travel together with images or models it references, it is packaged as a
`.kmz` archive.

### Adoption

KML is supported by Google Earth, Google Maps and My Maps, and many GIS
programs, GPS tools, and web mapping libraries. It is focused on
visualization, so for analysis and exchange of attribute-rich data, formats
such as GeoJSON, GeoPackage, or Shapefile are often preferred.

### Preservation And Security Notes

Because KML is open, textual XML, it is easy to inspect and convert. Linked
overlays, icons, and network links may not be reachable in the future, so
embed or archive referenced resources (for example, by using KMZ). Treat
files from untrusted sources carefully: network links can trigger outbound
requests, and XML parsers should disable external entity processing.

### Further Reading

- OGC KML standard: `https://www.ogc.org/standards/kml/`
- KML Reference (Google): `https://developers.google.com/kml/documentation/kmlreference`
