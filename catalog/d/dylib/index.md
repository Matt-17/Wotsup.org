---
overview: ".dylib files are dynamic libraries for macOS and other Apple platforms, stored in the Mach-O format and loaded by the dynamic linker (dyld)."
extensions:
  - name: "Mach-O dynamic library"
    description: "Apple dynamic shared library in Mach-O format, loaded by dyld"
    categories:
    - binaries
    author: "Apple Inc."
    link: "https://developer.apple.com/library/archive/documentation/DeveloperTools/Conceptual/DynamicLibraries/100-Articles/OverviewOfDynamicLibraries.html"
---

## DYLIB (Dynamic Library)

A `.dylib` is a dynamically linked library on macOS, iOS, and related Apple
platforms. It plays the same role as `.so` on Linux and `.dll` on Windows:
executable code that several programs can share and that is bound to them when
they are launched or by explicit loading (`dlopen`). Related Apple containers
include frameworks (`.framework` bundles that contain a dylib together with
headers and resources) and plug-in bundles (`.bundle`).

### Structure

A dylib is a Mach-O file whose file type is `MH_DYLIB`. A Mach-O file starts
with a magic number: `0xFEEDFACF` for 64-bit and `0xFEEDFACE` for 32-bit images
(stored in the byte order of the file). A header is followed by load commands
describing segments, symbol tables, and dependencies. A dylib carries an
"install name" recorded in the file, which is the path that programs linking
against it will use to find it, often written with `@rpath`, `@executable_path`,
or `@loader_path` prefixes. Universal ("fat") files wrap several architecture
slices, for instance Intel and Apple silicon, in one file with a different
header magic.

### Tooling

Apple's `otool` and `install_name_tool`, as well as `lipo` for universal files,
are used to inspect and modify dylibs. Recent macOS versions keep many system
libraries in a shared cache instead of individual files.

### Preservation And Security Notes

Binaries are tied to an architecture and operating system version. On current
macOS, code signing and notarization apply, and modifying a signed dylib
invalidates its signature. Treat unknown dylibs as executable code.

### Further Reading

- Overview of Dynamic Libraries (Apple): `https://developer.apple.com/library/archive/documentation/DeveloperTools/Conceptual/DynamicLibraries/100-Articles/OverviewOfDynamicLibraries.html`
- Mach-O loader header (Apple open source): `https://github.com/apple-oss-distributions/xnu/blob/main/EXTERNAL_HEADERS/mach-o/loader.h`
