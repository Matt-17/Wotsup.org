---
overview: ".vhd files are Virtual Hard Disk images: a Microsoft format that stores the contents of a virtual machine disk as a single file."
extensions:
  - name: "Virtual Hard Disk"
    description: "Microsoft virtual disk image format with fixed, dynamic and differencing variants"
    categories:
    - hardware-formats
    - windows
    author: "Microsoft"
    link: "https://github.com/libyal/libvhdi"
---

## VHD

VHD (Virtual Hard Disk) is a disk image format originally created by Connectix
for Virtual PC and later adopted by Microsoft for Virtual Server and Hyper-V. A
VHD file presents itself to a virtual machine as a block device, and Windows can
also mount VHD files directly as drives. Microsoft published the format under its
Open Specification Promise in 2005.

### Structure

A VHD ends with a 512-byte footer whose first eight bytes are `conectix`;
dynamic and differencing disks also repeat this footer at the start of the file.
There are three disk types. Fixed disks allocate the whole size up front.
Dynamic disks grow as data is written and use a block allocation table.
Differencing disks store only changes relative to a parent VHD. The format's
maximum size is just under 2 TB.

### Adoption And Tooling

VHD is supported by Hyper-V, Windows disk management, Virtual PC, VirtualBox,
QEMU and many backup and imaging tools. Windows backup has used it for system
images. The newer VHDX format has replaced it in Hyper-V for large disks and
better resilience, and Hyper-V can convert between the two.

### Preservation And Security Notes

A VHD holds a complete file system and may contain deleted data, credentials or
malware, so handle images from other parties as untrusted. Open source
documentation of the format is maintained by the libyal project, which also
provides tools for reading VHD files on other platforms.

### Further Reading

- libvhdi project and format documentation (libyal): `https://github.com/libyal/libvhdi`
- VHDX specification (successor format): `https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-vhdx/`
