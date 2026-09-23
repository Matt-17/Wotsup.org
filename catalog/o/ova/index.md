---
overview: ".ova files are Open Virtualization Archives: single-file tar packages containing an OVF descriptor and disk images for distributing virtual machines or appliances."
extensions:
  - name: "Open Virtualization Archive"
    description: "Tar archive packaging a virtual appliance in the OVF format"
    categories:
    - hardware-formats
    - archive
    author: "DMTF"
    link: "https://www.dmtf.org/sites/default/files/standards/documents/DSP0243_2.1.1.pdf"
---

## OVA

An OVA is the single-file form of the Open Virtualization Format (OVF), a
standard of the Distributed Management Task Force (DMTF) for packaging and
distributing virtual machines and virtual appliances in a way that is independent
of the hypervisor vendor. OVF has also been published as an ISO/IEC standard.

### Structure

An OVA is an uncompressed tar archive. The first file must be the OVF descriptor,
an XML document (`.ovf`) that describes the virtual hardware, networks, disks,
and optionally product information, license text and configuration properties.
The archive then contains the referenced virtual disk files, often in VMDK
format, and may include a manifest file (`.mf`) with checksums and a certificate
file (`.cert`) for signing. The same content can alternatively be stored as an
unpacked OVF folder with separate files.

### Adoption And Tooling

VMware vSphere, Workstation and Fusion, VirtualBox, and many other platforms
import and export OVA files, and the VMware OVF Tool provides command-line
conversion. Vendors often ship virtual appliances such as network devices or
security products as OVA files. Because the descriptor is hypervisor-neutral, some
settings may need adjustment after import on a different platform.

### Preservation And Security Notes

Because an OVA is a plain tar file, it can be opened with common archive tools to
inspect the descriptor and disks. Verify checksums from the manifest and any
certificate before deploying, since appliances contain complete operating
systems and may carry credentials or software of unknown origin.

### Further Reading

- DMTF OVF specification 2.1.1 (DSP0243): `https://www.dmtf.org/sites/default/files/standards/documents/DSP0243_2.1.1.pdf`
