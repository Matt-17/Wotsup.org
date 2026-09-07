---
overview: ".m3u8 files are UTF-8 encoded M3U playlists, best known as the playlist format of Apple HTTP Live Streaming (HLS); .m3u is the related, older playlist extension."
extensions:
  - name: "HTTP Live Streaming playlist (M3U8)"
    description: "UTF-8 extended M3U playlist describing media segments and variant streams for HLS"
    categories:
    - internet
    - video-animation
    - audio
    author: "Apple / IETF (RFC 8216)"
    link: "https://www.rfc-editor.org/rfc/rfc8216"
---

## M3U8

M3U8 is an M3U playlist encoded in UTF-8. The format is best known as the
playlist type of HTTP Live Streaming (HLS), originally created by Apple and
documented in the informational RFC 8216. Plain M3U8 files are also used as
ordinary audio playlists.

### Structure

An HLS playlist is a text file whose first line is `#EXTM3U`. Lines starting
with `#EXT` are tags; other lines starting with `#` are comments, and the
remaining lines are URIs. There are two kinds of playlists:

- A media playlist lists media segments, each preceded by an `#EXTINF` tag with
  its duration. Segments are typically MPEG transport stream (`.ts`) or
  fragmented MP4 files.
- A master playlist lists variant streams through `#EXT-X-STREAM-INF` tags, each
  pointing to a media playlist at a different bitrate or resolution, so the
  player can switch quality as network conditions change.

Live streams use a sliding window of segments and are updated by the server;
on-demand playlists end with `#EXT-X-ENDLIST`.

### Adoption

HLS is supported natively on Apple platforms and by most players and browsers
through libraries or built-in support. The common media types are
`application/vnd.apple.mpegurl` and `application/x-mpegURL`.

### Preservation And Security Notes

A playlist only references media, so archiving requires downloading every
segment and rewriting URIs. Playlists may reference encrypted segments through
`#EXT-X-KEY`. Players should treat URIs in untrusted playlists with the same care
as any remote content.

### Further Reading

- RFC 8216, HTTP Live Streaming: `https://www.rfc-editor.org/rfc/rfc8216`
- Apple HTTP Live Streaming overview: `https://developer.apple.com/streaming/`
