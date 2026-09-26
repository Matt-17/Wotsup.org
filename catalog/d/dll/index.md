---
overview: ".dll files are Windows Dynamic-Link Libraries: Portable Executable modules containing code and data that multiple programs can load and share at run time."
extensions:
  - name: "Windows Dynamic-Link Library (DLL)"
    description: "Portable Executable module with exported functions and resources, loaded at run time"
    categories:
    - binaries
    - windows
    author: "Microsoft"
    link: "https://learn.microsoft.com/en-us/windows/win32/debug/pe-format"
---

## DLL (Dynamic-Link Library)

A DLL is a library of code, data, and resources that Windows programs load when
they start or on demand, instead of linking the code statically into each
executable. Several processes can share one DLL, and a library can be updated
without rebuilding the programs that use it. Many Windows components and plug-in
systems are DLLs. Other extensions use the same structure, for example `.ocx`
(ActiveX controls), `.cpl` (Control Panel items), and `.drv`.

### Structure

A DLL is a Portable Executable (PE) file, the same format as `.exe`. It begins
with a DOS header starting with the bytes `MZ`, which points to a `PE\0\0`
signature, a COFF file header, an optional header, and a section table. A flag
in the COFF header marks the image as a DLL. Functions are made available
through the export table, found by name or ordinal, and the library lists the
modules it needs in its import table. An optional entry point (conventionally
`DllMain`) is called when the library is loaded into or unloaded from a process.
The `.dll` extension is also used for .NET assemblies, which are PE files that
additionally contain a CLR header and managed metadata.

### Preservation And Security Notes

A DLL is only meaningful together with the programs and the Windows version it
was built for, and with its dependencies; archive the whole installation when
preserving software. Because Windows searches several directories when resolving
a library name, applications can be tricked into loading a malicious DLL
("DLL hijacking" or search-order attacks). Handle unknown DLLs as executable
code, and prefer signed binaries and fully qualified load paths.

### Further Reading

- PE format specification (Microsoft): `https://learn.microsoft.com/en-us/windows/win32/debug/pe-format`
- Dynamic-link libraries (Microsoft): `https://learn.microsoft.com/en-us/windows/win32/dlls/dynamic-link-libraries`
