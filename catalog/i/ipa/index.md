---
overview: ".ipa files are iOS application archives: ZIP-based packages containing a signed app bundle for installation on iPhone, iPad, and other Apple devices."
extensions:
  - name: "iOS App Store Package"
    description: "ZIP archive containing a signed iOS/iPadOS app bundle"
    categories:
    - binaries
    - archive
    author: "Apple"
    link: "https://developer.apple.com/documentation/xcode/distributing-your-app-for-beta-testing-and-releases"
---

## IPA

An IPA (iOS App Store Package) is the archive format Apple uses to distribute
apps for iOS, iPadOS and related platforms. It is a ZIP file, so it starts with
the `PK` signature and can be unpacked with ordinary ZIP tools.

### Structure

The archive normally contains a top-level `Payload/` directory holding the app
bundle, a folder named `<AppName>.app`. Inside the bundle are the executable (a
Mach-O binary), `Info.plist` describing the app, resources such as storyboards,
images and localizations, and a `_CodeSignature/` directory. Packages may also
include additional top-level items depending on how the archive was produced.

### Distribution

IPAs are produced by Xcode when archiving and exporting an app. Apple requires
code signing and provisioning: apps are signed with a certificate and tied to a
provisioning profile, which determines whether the build may run on development
devices, ad hoc devices, enterprise-managed devices, or be submitted to App Store
Connect and TestFlight. Unsigned or improperly signed IPAs do not install on
stock devices.

### Preservation And Security Notes

Apps downloaded from the App Store are encrypted with FairPlay, so the
executable of a store IPA is not directly readable. For archiving, keep the
source project and signing configuration, since an old IPA may stop installing
once its certificates or profiles expire. IPAs from unofficial sources can be
modified and should not be installed without verification.

### Further Reading

- Distributing apps for beta testing and releases: `https://developer.apple.com/documentation/xcode/distributing-your-app-for-beta-testing-and-releases`
- Bundle resources: `https://developer.apple.com/documentation/bundleresources`
- Code signing: `https://developer.apple.com/support/code-signing/`
