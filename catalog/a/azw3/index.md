---
overview: ".azw3 files are Kindle Format 8 (KF8) e-books: Amazon's second-generation Kindle format with improved HTML5 and CSS3 support, related to .mobi and .azw."
extensions:
  - name: "Kindle Format 8 (AZW3)"
    description: "Amazon Kindle e-book format with HTML5 and CSS3 support, built on the MOBI container"
    categories:
    - documents
    author: "Amazon"
    link: "https://wiki.mobileread.com/wiki/AZW3"
---

## AZW3

AZW3 is the file extension commonly used for Kindle Format 8 (KF8), the
e-book format Amazon introduced in 2011 with the Kindle Fire. It is the
successor to the older MOBI-based format and supports much more of HTML5 and
CSS3, including better layout, fonts, and styling. The related extension `.azw`
is used for Kindle books in the older MOBI format.

### Structure

Amazon has not published an official specification, so what is known comes from
community documentation such as the MobileRead wiki. An AZW3 file still uses the
Palm Database container and `BOOKMOBI` type and creator. It can be a combined
file that holds a KF8 section next to a legacy MOBI section for older devices.
The KF8 part stores the book's content as a set of markup and style
resources, plus images and fonts, with index records for the table of contents
and navigation. The metadata comes from EXTH records, similar to MOBI.

### Adoption

AZW3 is read by Kindle devices and apps and by software such as Calibre, which
can convert between AZW3, MOBI, and EPUB. Books bought from Amazon are
normally protected with DRM, while DRM-free AZW3 files, such as those made
with Calibre, can be freely read and converted.

### Preservation And Security Notes

Because the format is proprietary and undocumented, EPUB is a better choice
for long-term preservation. Keep a DRM-free EPUB or the source files when
possible. Parsers should check record offsets and decompressed sizes.

### Further Reading

- AZW3 (MobileRead Wiki): `https://wiki.mobileread.com/wiki/AZW3`
