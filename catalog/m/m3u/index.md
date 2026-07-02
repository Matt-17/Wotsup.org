---
overview: ".m3u files are plain-text multimedia playlists: an ordered list of local paths or URLs pointing to audio and video tracks, optionally annotated with track titles and durations."
extensions:
  - name: "M3U / M3U8 playlist format"
    description: "Plain-text playlist listing media file paths or URLs, with an extended form for track metadata"
    categories:
    - audio
    link: "https://en.wikipedia.org/wiki/M3U"
    file: m3u.zip
---

## M3U Playlist

An M3U file is a text-based playlist: each non-comment line names one media
resource — a relative or absolute file path, or a URL — and the player loads
those resources in order. It began as a way to describe playlists for early
MP3 players and remains one of the most widely supported playlist formats for
audio and video across desktop players, streaming tools, and media servers.

The basic format is deliberately simple. In the plain form, every line is just
a location, and the file carries no metadata of its own. The player determines
titles and durations from the referenced files. Because the entries can be
relative paths, a plain `.m3u` playlist is only meaningful next to the media it
points at, and moving the playlist without the media breaks it.

### Extended M3U

The extended form starts with the header line `#EXTM3U` and allows comment
directives that begin with `#`. The most common is `#EXTINF:`, which precedes
an entry with a track duration in seconds and a display title, letting players
show meaningful names and lengths without opening each file. Other directives
carry grouping, artwork, or stream metadata depending on the application.

The same extended syntax underpins `.m3u8`, the UTF-8-encoded variant. The
`.m3u8` extension signals that the text is UTF-8 rather than a local code page,
which matters for non-ASCII paths and titles. The extended M3U syntax is also
the basis of HTTP Live Streaming (HLS) manifests, though HLS playlists use a
specific set of `#EXT-X-` tags and should be read in that streaming context.

### Interoperability And Preservation Notes

There is no single formal specification, so behavior varies: encoding (local
code page versus UTF-8), path separators, and support for individual `#EXT`
directives differ between players. The commonly used media type is
`audio/x-mpegurl` (and `application/vnd.apple.mpegurl` for HLS). For
preservation or transfer, prefer the UTF-8 `.m3u8` form, keep playlists with
their referenced media, and record whether paths are relative or absolute.

### Security Notes

Because entries can be arbitrary URLs and local paths, an untrusted playlist
can point a player at remote servers or unexpected local files. Applications
that open playlists automatically should validate and constrain the referenced
locations rather than fetching or opening every entry without checks.

### Further Reading

- M3U overview: `https://en.wikipedia.org/wiki/M3U`
- HTTP Live Streaming (HLS) playlists: `https://datatracker.ietf.org/doc/html/rfc8216`
