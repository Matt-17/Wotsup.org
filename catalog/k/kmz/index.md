---
overview: ".kmz files are zipped KML packages: a ZIP archive that bundles a KML document with the icons, overlays, and models it references."
extensions:
  - name: "KMZ (zipped KML)"
    description: "ZIP-compressed archive containing a KML file and its supporting resources"
    categories:
    - gis-formats
    - archive
    author: "Google / Open Geospatial Consortium"
    link: "https://developers.google.com/kml/documentation/kmzarchives"
---

## KMZ (Zipped KML)

KMZ is the packaged form of KML. It is an ordinary ZIP archive with the
`.kmz` extension that contains a main KML document and, optionally, the files
that document refers to, such as custom icons, ground overlay images, photos,
and 3D models (COLLADA `.dae`). Packaging everything together makes a map
shareable as one self-contained file and reduces size through compression.

### Technical Notes

Because a KMZ is a ZIP file, it starts with the usual ZIP signature `PK` and
can be opened by renaming it to `.zip` and extracting it with any archive
tool. By convention the root KML file is named `doc.kml`, and the files inside
are referenced with relative paths. The format is part of the OGC KML 2.2
standard.

### Adoption

KMZ is the default save format for placemarks and tours in Google Earth and is
read by most GIS tools, mapping applications, and many GPS and aviation
programs. It is often the preferred way to distribute KML that depends on
images or models.

### Preservation And Security Notes

KMZ is a good choice for preservation when a KML needs its resources, since it
keeps them together. Extract and review the contents when archiving, because
the contained KML may still point to remote resources that can disappear. As
with any ZIP file, tools opening untrusted KMZ files should guard against
path traversal in entry names and decompression bombs.

### Further Reading

- KMZ archives (Google): `https://developers.google.com/kml/documentation/kmzarchives`
- KML Reference (Google): `https://developers.google.com/kml/documentation/kmlreference`
- OGC KML standard: `https://www.ogc.org/standards/kml/`
