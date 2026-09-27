---
overview: ".so files are shared objects: ELF dynamic libraries used on Linux and most Unix-like systems, loaded by the dynamic linker at program start or on demand."
extensions:
  - name: "Shared object (ELF dynamic library)"
    description: "ELF shared library loaded by the dynamic linker on Linux, BSD, and other Unix-like systems"
    categories:
    - binaries
    author: "Unix System Laboratories / Tool Interface Standards Committee"
    link: "https://refspecs.linuxfoundation.org/elf/elf.pdf"
---

## SO (Shared Object)

A `.so` file is a shared library for Unix-like systems. Programs that depend on
it reference it by name and the dynamic linker (`ld.so` on Linux) maps it into
memory when the program starts, or later through `dlopen`. Many processes can
share the same read-only code pages, and libraries can be updated independently
of the programs that use them. The equivalent formats are `.dll` on Windows and
`.dylib` on macOS.

### Structure

A shared object is an ELF file, beginning with the magic bytes `0x7F 'E' 'L' 'F'`,
with file type `ET_DYN`. The dynamic section lists needed libraries, the
library's own name (`SONAME`), and the symbol tables used for linking. Library
files are usually versioned through the file name, for example `libfoo.so.1.2.3`,
with symbolic links such as `libfoo.so.1` (the SONAME) and `libfoo.so` (used
when linking at build time). Android native libraries are also `.so` files.

### Tooling

Common tools for inspecting shared objects are `readelf`, `objdump`, `nm`, and
`ldd`. Search paths are controlled by system configuration and variables such as
`LD_LIBRARY_PATH`.

### Preservation And Security Notes

A shared object is built for a specific processor architecture, operating
system ABI, and set of dependent libraries; record these when archiving.
Environment variables such as `LD_PRELOAD` and `LD_LIBRARY_PATH` can cause
unintended libraries to be loaded, so they should be handled carefully in
privileged programs. Treat unknown `.so` files as executable code.

### Further Reading

- ELF specification (Tool Interface Standards): `https://refspecs.linuxfoundation.org/elf/elf.pdf`
- ld.so manual page: `https://man7.org/linux/man-pages/man8/ld.so.8.html`
