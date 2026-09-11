---
overview: ".torrent files are BitTorrent metadata files: small bencoded files that describe the files and piece hashes of a payload and the trackers used to share it."
extensions:
  - name: "BitTorrent metainfo file"
    description: "Bencoded dictionary describing shared files, piece hashes, and tracker URLs"
    categories:
    - internet
    - data-format
    author: "Bram Cohen / BitTorrent.org"
    link: "https://www.bittorrent.org/beps/bep_0003.html"
---

## Torrent

A `.torrent` file is the metainfo file of the BitTorrent peer-to-peer file
sharing protocol. It does not contain the shared data. Instead, it describes the
content so that a client can find peers and verify the pieces it downloads. The
format is specified in BitTorrent Enhancement Proposal 3 (BEP 3).

### Structure

The file is a single bencoded dictionary. Bencoding is a simple encoding with
integers (`i42e`), byte strings (`4:spam`), lists (`l...e`), and dictionaries
(`d...e`), with dictionary keys in sorted order. The top-level keys include
`announce` (the tracker URL) and `info`. The `info` dictionary holds the
suggested `name`, the `piece length`, the `pieces` string of concatenated SHA-1
hashes (one per piece), and either `length` for a single file or `files` for a
multi-file torrent. The SHA-1 hash of the bencoded `info` dictionary is the
infohash, which identifies the torrent in trackers, in the DHT, and in magnet
links. Version 2 of the format (BEP 52) uses SHA-256 and per-file Merkle trees.

### Adoption

All BitTorrent clients read `.torrent` files, and many have also moved to
magnet links, which carry only the infohash. The media type is
`application/x-bittorrent`.

### Preservation And Security Notes

A torrent file only stays useful as long as peers or web seeds still have the
data, so it is not an archival copy of the content. The piece hashes allow
integrity checks of downloaded data. Parsers should be careful with nested
bencoded structures, declared lengths, and file paths, because a malicious
torrent could try to write outside the download folder.

### Further Reading

- BEP 3, The BitTorrent Protocol Specification: `https://www.bittorrent.org/beps/bep_0003.html`
- BEP 52, The BitTorrent Protocol Specification v2: `https://www.bittorrent.org/beps/bep_0052.html`
