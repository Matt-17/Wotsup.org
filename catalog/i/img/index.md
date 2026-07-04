---
overview: ".img files in this context are ERDAS IMAGINE raster images: a geospatial raster format (HFA) used in remote sensing and GIS to store multi-band imagery together with georeferencing, statistics, and pyramids."
extensions:
  - name: "ERDAS IMAGINE (IMG) raster format"
    description: "Hierarchical (HFA) geospatial raster format for multi-band imagery and GIS data"
    categories:
    - gis-formats
    author: "ERDAS / Hexagon Geospatial"
    link: "https://gdal.org/drivers/raster/hfa.html"
    file: erdas.zip
---

## ERDAS IMAGINE (IMG)

The `.img` extension here refers to the ERDAS IMAGINE raster format, a widely
used container for geospatial imagery in remote sensing and GIS. It stores
gridded raster data — satellite and aerial imagery, elevation models,
classification results, and other continuous or categorical rasters — along
with the metadata needed to place that data on the Earth's surface.

The underlying structure is the Hierarchical File Architecture (HFA), a tree of
typed nodes. This lets an `.img` hold multiple bands, per-band statistics and
histograms, a color table, a map projection and georeferencing, and reduced
resolution overviews ("pyramids") for fast display, all inside one file. Large
datasets may accompany the `.img` with auxiliary files, so the raster is not
always a single standalone file.

> Note: `.img` is a heavily overloaded extension. It is also used for raw disk
> and CD/DVD images, floppy images, and other unrelated formats. An `.img` file
> should be identified by its content and context, not by extension alone.

### Capabilities And Tooling

Because it was designed for analytical imagery, the format supports many data
types (from single-bit and 8-bit through floating point), large files, and rich
attached metadata. It is broadly supported by GIS and remote-sensing software,
and open tools such as GDAL implement the HFA driver for reading and writing
`.img`, which makes it a practical interchange format across ecosystems.

### Preservation Notes

For preservation and transfer, keep any sidecar files together with the `.img`,
and record the coordinate reference system, pixel size, band definitions, and
nodata value, since analytical value depends on correct georeferencing and
band semantics. When converting to another raster format such as GeoTIFF,
preserve the projection, nodata handling, and statistics rather than only the
pixel values.

### Security Notes

As a structured binary format with nested nodes and variable-length records, an
`.img` parser should validate node offsets, band and dimension counts, and
allocation sizes from untrusted files before trusting them, to avoid
out-of-bounds reads or excessive memory allocation.

### Further Reading

- GDAL HFA (.img) driver: `https://gdal.org/drivers/raster/hfa.html`
- ERDAS IMAGINE product overview: `https://en.wikipedia.org/wiki/ERDAS_IMAGINE`
