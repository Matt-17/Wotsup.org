---
overview: ".ipynb files are Jupyter Notebook documents: JSON files that combine code cells, their outputs, and Markdown text, used for interactive computing and data science."
extensions:
  - name: "Jupyter Notebook (IPython Notebook)"
    description: "JSON notebook format holding code, outputs, and narrative text (Project Jupyter nbformat)"
    categories:
    - documents
    - data-format
    author: "Project Jupyter"
    link: "https://nbformat.readthedocs.io/en/latest/format_description.html"
---

## Jupyter Notebook (.ipynb)

An .ipynb file is a Jupyter notebook: a single document that interleaves executable
code, the results of running it (text, tables, plots), and explanatory Markdown.
The extension stems from the format's origin in IPython Notebook; the format is now
maintained by Project Jupyter and is used with many languages through Jupyter
kernels, including Python, R, and Julia.

Technically a notebook is a UTF-8 JSON document defined by the `nbformat`
specification. The top-level object contains `metadata` (such as kernel and
language information), the version fields `nbformat` and `nbformat_minor`, and a
`cells` list. Each cell has a `cell_type` (`code`, `markdown`, or `raw`), its
`source`, and its own metadata; code cells also carry `outputs` and an
`execution_count`. Outputs such as images are embedded in the JSON, typically
base64-encoded, which can make notebooks large.

### Tooling

Notebooks are created and run in JupyterLab, the classic Notebook interface, and
editors such as VS Code, and are rendered by GitHub and by `nbconvert`, which can
export them to HTML, PDF, Markdown, and scripts. Because the format is JSON with
embedded outputs, version-control diffs are noisy; many projects strip outputs
before committing.

### Preservation And Security Notes

A notebook records code and results but not the software environment, so
reproducibility requires recording dependency versions separately. Opening a
notebook from an untrusted source can be risky because it may contain code and
HTML or JavaScript outputs; Jupyter uses a trust mechanism so that outputs from
untrusted notebooks are not executed, and cells should be reviewed before being run.

### Further Reading

- Notebook format specification: `https://nbformat.readthedocs.io/en/latest/format_description.html`
- Project Jupyter: `https://jupyter.org/`
