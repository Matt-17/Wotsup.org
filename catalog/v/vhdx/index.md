---
overview: ".vhdx files are Hyper-V Virtual Hard Disk v2 images: a Microsoft virtual disk format supporting disks up to 64 TB with a metadata log for crash resilience."
extensions:
  - name: "Hyper-V Virtual Hard Disk v2"
    description: "Microsoft virtual disk image format succeeding VHD, with larger capacity and power-failure protection"
    categories:
    - hardware-formats
    - windows
    author: "Microsoft"
    link: "https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-vhdx/"
---

## VHDX

VHDX is the second-generation virtual hard disk format from Microsoft, introduced
with Windows Server 2012 and Hyper-V. It replaces the older VHD format for most
uses and is the default disk format for Hyper-V virtual machines. Windows can also
mount VHDX files directly as drives.

### Structure

A VHDX file starts with the ASCII signature `vhdxfile`. It contains a header
section with redundant headers, a region table, a metadata region, a block
allocation table (BAT), and a log. The log records metadata updates so that the
file can be recovered consistently after a power failure or crash. Improvements
over VHD include a maximum virtual disk size of 64 TB, support for 4 KB logical
sector sizes, larger block sizes, and alignment better suited to modern storage.
As with VHD, there are fixed, dynamic and differencing variants.

### Adoption And Tooling

VHDX is supported by Hyper-V, Windows disk management and PowerShell cmdlets such
as `Convert-VHD` and `Resize-VHD`. QEMU, VirtualBox and various libraries can read
it, and conversion tools can turn it into raw, qcow2 or VMDK images. Microsoft
publishes the format specification as part of its Open Specifications.

### Preservation And Security Notes

Treat a VHDX like a whole disk: it can contain deleted data, credentials and
malware. If a differencing disk is used, its parent file must be preserved
together with it. Never mount images from untrusted sources on a production
system.

### Further Reading

- VHDX Format Specification (MS-VHDX): `https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-vhdx/`
