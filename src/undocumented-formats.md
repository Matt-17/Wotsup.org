---
layout: page
title: Undocumented File Formats
description: File formats for which Wotsup.org still needs a specification, reliable source, or detailed technical notes.
permalink: /undocumented-formats/
---

{% assign backlog = site.data.undocumented_formats %}

These **{{ backlog.count }} formats** are known to the catalog, but Wotsup.org currently has no detailed format notes, no preserved local specification, and no active external reference for them.

This is a research backlog, not a claim that no documentation exists anywhere. A specification may survive in an old SDK, book, source repository, standards archive, magazine, disk image, or personal collection.

If you can identify or recover a source, [open a missing-specification issue](https://github.com/Matt-17/Wotsup.org/issues/new?template=missing-specification.yml) or [contribute it directly](/contributing/).

<div class="backlog-toolbar">
  <label for="backlog-filter">Filter the list</label>
  <input id="backlog-filter" type="search" placeholder="Extension, name, or category" autocomplete="off">
  <span id="backlog-count" aria-live="polite">{{ backlog.count }} formats</span>
</div>

<div class="backlog-table-wrap">
  <table class="undocumented-table" id="undocumented-formats">
    <thead>
      <tr>
        <th>Extension</th>
        <th>Known meaning</th>
        <th>Categories</th>
        <th>What is missing</th>
      </tr>
    </thead>
    <tbody>
      {% for format in backlog.formats %}
      <tr>
        <td><a href="{{ format.url | relative_url }}"><code>.{{ format.extension }}</code></a></td>
        <td>
          {{ format.name }}
          {% if format.additional_meanings > 0 %}<small>+{{ format.additional_meanings }} more meaning{% if format.additional_meanings != 1 %}s{% endif %}</small>{% endif %}
        </td>
        <td>{% for category in format.categories %}<span class="backlog-category">{{ category }}</span>{% endfor %}</td>
        <td>{{ format.reason }}</td>
      </tr>
      {% endfor %}
    </tbody>
  </table>
</div>

<script>
  (function () {
    const input = document.getElementById('backlog-filter');
    const rows = Array.from(document.querySelectorAll('#undocumented-formats tbody tr'));
    const count = document.getElementById('backlog-count');
    if (!input || !count) return;

    input.addEventListener('input', function () {
      const query = input.value.trim().toLowerCase();
      let visible = 0;
      rows.forEach(function (row) {
        const matches = !query || row.textContent.toLowerCase().includes(query);
        row.hidden = !matches;
        if (matches) visible++;
      });
      count.textContent = visible + (visible === 1 ? ' format' : ' formats');
    });
  })();
</script>
