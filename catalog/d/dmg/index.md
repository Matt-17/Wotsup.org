---
overview: ".dmg files are Apple Disk Image files: macOS disk images commonly used to distribute applications and installers."
extensions:
  - name: "Apple Disk Image"
    description: "macOS disk image container, usually compressed and optionally encrypted"
    categories:
    - binaries
    - archive
    author: "Apple"
    link: "https://developer.apple.com/documentation/xcode/packaging-mac-software-for-distribution"
---

## DMG

A DMG is a disk image format for macOS. When opened, it is mounted as a virtual
volume, so software can be shipped as a single file that the user mounts and then
drags into the Applications folder. DMGs are also used for installers, backups
and read-only distribution media.

### Structure

Apple has not published a complete official specification for the most common
variant, the Universal Disk Image Format (UDIF). It is generally described as
holding the disk data, often compressed in chunks, followed by a trailing
512-byte block beginning with the magic `koly` that points to a chunk map.
Images can contain HFS+, APFS or other file systems. Common sub-types include
read-only compressed (UDZO), read/write (UDRW), and sparse images, and images can
be encrypted.

### Tooling

macOS provides Disk Utility and the `hdiutil` command for creating, converting,
mounting and verifying images. Distributors usually sign and notarize the
application inside the image so that Gatekeeper accepts it. Third-party tools can
extract many DMGs on other platforms, though this relies on reverse-engineered
documentation.

### Preservation And Security Notes

Since the format is only partially documented, archive the file together with a
note of the macOS version and tooling used, and consider keeping an extracted copy
of the contents. Treat images from untrusted sources with care: mounting parses a
file system and the contents may be unsigned software.

### Further Reading

- Packaging Mac software for distribution: `https://developer.apple.com/documentation/xcode/packaging-mac-software-for-distribution`
