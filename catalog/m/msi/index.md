---
overview: ".msi files are Windows Installer packages: structured-storage database files that describe how Windows installs, updates, and removes software."
extensions:
  - name: "Windows Installer package"
    description: "Database-based installation package processed by the Windows Installer service"
    categories:
    - windows
    - binaries
    author: "Microsoft"
    link: "https://learn.microsoft.com/en-us/windows/win32/msi/windows-installer-portal"
---

## MSI

An MSI file is an installation package for the Windows Installer service
(`msiexec.exe`). Instead of containing an installer program, an MSI is data: a
relational database that tells the service which files, registry entries,
shortcuts and services to install, and in what order.

### Structure

An MSI is an OLE compound (structured storage) file, so it starts with the bytes
`D0 CF 11 E0 A1 B1 1A E1`, the same signature as legacy Office documents. Inside
are tables such as `File`, `Component`, `Feature`, `Registry` and
`InstallExecuteSequence`, plus summary information and, optionally, embedded
cabinet (`.cab`) archives holding the files to install. Related files include
`.msp` (patches), `.mst` (transforms that customize a package) and `.msm` (merge
modules).

### Tooling

Packages are installed with `msiexec` (for example `msiexec /i package.msi /qn`
for silent installs), which supports logging and managed deployment. Authoring
tools include the WiX Toolset, Visual Studio-based setup projects and commercial
products. Installations are transactional and can be rolled back on failure.

### Preservation And Security Notes

MSI packages can run custom actions with elevated privileges, so verify the
Authenticode signature and the source before installing. Because an MSI is a
database, its contents can be inspected without installing it, which helps with
auditing and archiving.

### Further Reading

- Windows Installer portal: `https://learn.microsoft.com/en-us/windows/win32/msi/windows-installer-portal`
- Overview of Windows Installer: `https://learn.microsoft.com/en-us/windows/win32/msi/overview-of-windows-installer`
- Windows Installer file extensions: `https://learn.microsoft.com/en-us/windows/win32/msi/windows-installer-file-extensions`
