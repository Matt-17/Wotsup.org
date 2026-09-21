---
overview: ".deb files are Debian software packages: ar archives used by Debian, Ubuntu and derived Linux distributions to distribute installable software."
extensions:
  - name: "Debian package"
    description: "ar-based binary package format used by dpkg and APT"
    categories:
    - binaries
    - archive
    author: "Debian Project"
    link: "https://manpages.debian.org/stable/dpkg-dev/deb.5.en.html"
---

## DEB

A `.deb` file is a binary package for the Debian family of Linux distributions,
including Debian, Ubuntu and Linux Mint. Packages are installed with `dpkg` and
usually managed through `apt`, which resolves dependencies and downloads packages
from repositories.

### Structure

A deb is an `ar` archive that starts with the text `!<arch>`. In the current
format it contains three members in a fixed order: `debian-binary`, a small text
file with the format version (`2.0`); `control.tar` with the package metadata
(compressed, for example `control.tar.xz` or `.zst`); and `data.tar` with the
files to install (compressed likewise). The control archive holds the `control`
file (name, version, architecture, dependencies, maintainer, description),
checksums, and maintainer scripts such as `preinst`, `postinst`, `prerm` and
`postrm`.

### Tooling

`dpkg-deb` builds and inspects packages, `dpkg -i` installs them, and `ar x` can
unpack the outer container for manual inspection. Package contents and metadata
conventions are defined by the Debian Policy Manual. A related extension is
`.udeb`, used for stripped-down packages in the Debian installer.

### Preservation And Security Notes

Maintainer scripts run as root during installation, so only install packages
from trusted sources. Repository metadata is normally signed; individual `.deb`
files downloaded outside a repository carry no such guarantee unless separately
verified.

### Further Reading

- deb(5) manual page: `https://manpages.debian.org/stable/dpkg-dev/deb.5.en.html`
- Debian Policy Manual: `https://www.debian.org/doc/debian-policy/`
- Debian package basics: `https://www.debian.org/doc/manuals/debian-faq/pkg-basics.en.html`
