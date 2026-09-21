---
overview: ".apk files are Android application packages: ZIP-based archives containing the compiled code, resources, and manifest needed to install an app on Android devices."
extensions:
  - name: "Android Package"
    description: "ZIP-based installable package format for Android applications"
    categories:
    - binaries
    - archive
    author: "Google"
    link: "https://developer.android.com/guide/app-bundle"
---

## APK

An APK (Android Package) is the file format used to distribute and install
applications on Android. It is a ZIP archive, so it begins with the usual `PK`
signature and can be opened with any ZIP tool, but it follows a fixed layout that
the Android package installer expects.

### Structure

A typical APK contains `AndroidManifest.xml` (stored in a compiled binary XML
form), one or more `classes.dex` files with code for the Android Runtime,
`resources.arsc` with compiled resource tables, the `res/` and `assets/`
directories, optional native libraries under `lib/<abi>/`, and a `META-INF/`
directory holding signature data. Every APK must be signed before Android will
install it.

### Signing And Distribution

Android defines several signature schemes. The original JAR-style scheme (v1)
signs individual files listed in `META-INF/`; later schemes (v2, v3, v4) sign the
APK as a whole, with the signing block placed before the ZIP central directory,
which makes tampering easier to detect and installation faster. For Google Play,
developers now upload Android App Bundles (`.aab`) rather than APKs, and Play
generates device-specific APKs from them. APKs remain the format for sideloading
and for other app stores.

### Preservation And Security Notes

Because an APK is just a ZIP, its content can be inspected without installing
it, but decompiled or repackaged APKs lose their original signature. Sideloaded
APKs from untrusted sources are a common malware vector; verify the signing
certificate and use tools such as `apksigner verify` before installing.

### Further Reading

- Android App Bundle and APK overview: `https://developer.android.com/guide/app-bundle`
- apksigner tool: `https://developer.android.com/tools/apksigner`
- APK signature schemes: `https://source.android.com/docs/security/features/apksigning`
- Build from the command line: `https://developer.android.com/studio/build/building-cmdline`
