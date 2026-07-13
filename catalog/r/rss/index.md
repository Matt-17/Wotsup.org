---
overview: ".rss files are RSS web feeds: an XML format that publishes a channel of frequently updated items — headlines, summaries, and links — so readers and aggregators can track a site's new content."
extensions:
  - name: "Syndication file format"
    description: "Syndication file format"
    categories:
    - internet
    link: "http://backend.userland.com/rss092"
    deprecated: true
---

## RSS (Web Syndication)

RSS is an XML-based format for web feeds, letting sites publish a machine-readable
list of their latest content — news headlines, blog posts, podcast episodes — that
feed readers and aggregators can poll and present in one place. The acronym is
usually expanded as "Really Simple Syndication" (earlier as "RDF Site Summary" and
"Rich Site Summary," reflecting a somewhat tangled version history).

An RSS document is an XML file with a root `<rss>` element containing a single
`<channel>` that describes the source and holds a series of `<item>` elements.
Each item typically carries a title, link, description, publication date, and a
unique identifier (`guid`). Podcasts extend RSS with additional namespaced
elements, most notably `<enclosure>` to attach the audio file, which is how
podcast distribution works.

### RSS And Atom

Two feed formats are in common use: RSS (with widely deployed versions including
0.9x and 2.0) and the later, more rigorously specified Atom format. They serve the
same purpose, and many tools read both, so a feed should be identified by its root
element and namespace rather than assumed from the `.rss` or `.xml` extension.

### Preservation And Security Notes

As open, text-based XML, RSS is straightforward to archive and process. Because
feed content is XML from external sources, aggregators should parse it with the
usual XML protections (disable external entities, bound expansion) and treat item
titles, descriptions, and links as untrusted — sanitizing any embedded HTML before
display to prevent injection.

### Further Reading

- RSS 2.0 specification: `https://www.rssboard.org/rss-specification`
- The Atom Syndication Format (RFC 4287): `https://datatracker.ietf.org/doc/html/rfc4287`
