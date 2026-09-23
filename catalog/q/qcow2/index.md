---
overview: ".qcow2 files are QEMU Copy-On-Write version 2 disk images: a virtual disk format supporting thin provisioning, snapshots, backing files, compression and encryption."
extensions:
  - name: "QEMU Copy On Write 2"
    description: "Virtual disk image format of QEMU/KVM with snapshots and backing files"
    categories:
    - hardware-formats
    author: "QEMU project"
    link: "https://qemu-project.gitlab.io/qemu/interop/qcow2.html"
---

## QCOW2

QCOW2 is the native disk image format of QEMU and is widely used with KVM, libvirt
and OpenStack. It succeeds the original QCOW format and stores a virtual disk as
a file that grows as the guest writes data, rather than allocating the full size
up front.

### Structure

A qcow2 file begins with the magic bytes `QFI` followed by `0xFB`. The disk is
divided into clusters (64 KB by default) that are mapped through a two-level
table (L1 and L2 tables), with reference counts tracking cluster usage. Version 3
of the format added feature bits, lazy reference counts, zero clusters and
extended header fields. Notable capabilities include internal snapshots, backing
files (an image that stores only the differences from a base image), optional
zlib or zstd compression of clusters, and encryption.

### Tooling

`qemu-img` creates, inspects, checks, resizes and converts qcow2 images to and
from raw, VHD, VHDX, VMDK and other formats. Many cloud providers distribute
virtual machine templates as qcow2 images, for example Linux cloud images used in
OpenStack and Proxmox environments. The format is documented in the QEMU
specification.

### Preservation And Security Notes

Images with a backing file depend on that file remaining available at the same
path; use `qemu-img convert` to create a standalone image for archiving. Backing
file paths in untrusted images can point to arbitrary host files, so inspect
unfamiliar images with `qemu-img info` and avoid running them with privileged
access to the host. Legacy QCOW encryption is considered weak; modern qcow2 uses
LUKS.

### Further Reading

- QCOW2 image format specification: `https://qemu-project.gitlab.io/qemu/interop/qcow2.html`
