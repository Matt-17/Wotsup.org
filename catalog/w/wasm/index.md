---
overview: ".wasm files are WebAssembly modules: a portable, compact binary instruction format for a stack-based virtual machine, run at near-native speed inside a sandbox in browsers and other hosts."
extensions:
  - name: "WebAssembly (Wasm) module"
    description: "Portable binary bytecode format for a sandboxed stack-based virtual machine"
    categories:
    - binaries
    - internet
    author: "W3C WebAssembly Community/Working Group"
    link: "https://webassembly.org/"
---

## WebAssembly (Wasm)

WebAssembly is a portable binary instruction format designed as a compilation target
for languages like C, C++, Rust, and Go, so that code written in them can run at
near-native speed on the web and in other environments. A `.wasm` file is a compact
module of bytecode for a stack-based virtual machine, standardized by the W3C. It
was created to give the web a fast, low-level, language-neutral execution target
alongside JavaScript, and it has since spread well beyond the browser to servers,
plug-in systems, and edge computing.

A Wasm module is organized into sections describing its types, imported and exported
functions, memory, tables, globals, and the function bodies themselves. It begins
with the magic bytes `\0asm` and a version number. Modules do not run on their own:
a host (a browser's JavaScript engine, or a standalone runtime) instantiates a
module, supplies its imports, and calls its exports. Crucially, execution is
sandboxed — a module can only access the linear memory and imported functions the
host grants it — which is central to its security model. The WebAssembly System
Interface (WASI) standardizes host capabilities for non-browser use.

### Text Format And Preservation Notes

Wasm has an equivalent human-readable text format (`.wat`) using S-expressions,
which aids inspection and debugging. For preservation, the binary `.wasm` is the
distributable artifact; keeping the source and build toolchain, or the `.wat`
disassembly, aids future understanding. The media type is `application/wasm`.

### Security Notes

Sandboxing is a design goal, but a Wasm module is still executable code, so hosts
should enforce strict import boundaries, resource (memory/CPU) limits, and validation
of the module before instantiation, and treat modules from untrusted sources
accordingly.

### Further Reading

- WebAssembly home page: `https://webassembly.org/`
- WebAssembly specification: `https://webassembly.github.io/spec/`
