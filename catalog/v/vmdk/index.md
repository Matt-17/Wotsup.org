---
overview: ".vmdk files are VMware Virtual Machine Disk images: a disk format used by VMware products and supported by many other virtualization tools."
extensions:
  - name: "VMware Virtual Machine Disk"
    description: "Virtual disk format for VMware virtual machines, with descriptor and extent files"
    categories:
    - hardware-formats
    author: "VMware"
    link: "https://github.com/libyal/libvmdk"
---

## VMDK

VMDK (Virtual Machine Disk) is the virtual disk format of VMware Workstation,
Fusion, Player and ESXi. It was designed by VMware, and has become a common
interchange format; it is also supported by VirtualBox, QEMU and others, and is
the disk format used inside OVA packages.

### Structure

A virtual disk can consist of a small text descriptor file that describes the
disk geometry, type and list of extents, plus one or more extent files holding the
data. The descriptor can also be embedded in a single file. Sparse extents begin
with the magic `KDMV`, followed by a header with capacity, grain size and the
location of the grain directory. Common disk types include monolithic sparse,
monolithic flat, split into 2 GB extents, and, on ESXi, `-flat` and `-delta`
extents. Snapshots are stored as child disks that refer to a parent.

### Adoption And Tooling

VMware products create and manage VMDK files, and the `vmware-vdiskmanager` and
`qemu-img` tools can convert them to and from raw, qcow2 and VHD formats. Open
source libraries such as libvmdk provide read access without VMware software.
VMware has published a technical note on the format, but older links to it have
moved, so consult current VMware documentation.

### Preservation And Security Notes

Keep descriptor files and all extent files together, along with any parent
disks, since a VMDK that refers to missing extents cannot be opened. Disk images
contain whole file systems, including deleted data and possible credentials, and
should be treated accordingly.

### Further Reading

- libvmdk project (libyal): `https://github.com/libyal/libvmdk`
