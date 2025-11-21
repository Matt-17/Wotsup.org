---
layout: default
title: Wotsup
description: A comprehensive file format specification resource
hero_cta_primary: /contributing/
hero_cta_secondary: /how-to/
---

<div class="landing-shell">
  <section class="landing-hero">
    <div class="landing-hero__content">
      <p class="hero-eyebrow">File Format Encyclopedia</p>
      <h1>Your resource for file format specifications.</h1>
      <p class="hero-lede">
        Wotsup.org is a community-driven archive providing hundreds of file format specifications,
        hardware notes, and implementation guides. Browse and contribute to help keep
        legacy data accessible.
      </p>
      <div class="hero-actions">
        <a class="btn btn-primary" href="/contributing/">Start contributing</a>
        <a class="btn" href="/how-to/">How to use</a>
      </div>
      <ul class="hero-pills">
        <li>{{ site.data.site_stats.file_formats_total }}+ file formats</li>
        <li>{{ site.data.site_stats.categories_total }}+ categories</li>
        <li>Community maintained</li>
      </ul>
    </div>
    <div class="landing-hero__panel">
      <img class="landing-hero__image" src="{{ '/assets/img/wotsup_560x320.png' | relative_url }}" alt="Wotsup" title="{{ site.title | escape }}" />
      <h3>Quick links</h3>
      <ul>
        <li><a href="/how-to/">How to use</a></li>
        <li><a href="/faq/">FAQ</a></li>
        <li><a href="/about/">About</a></li>
      </ul>
    </div>
  </section>

  <section class="landing-section metrics">
    <div class="section-heading">
      <p class="eyebrow">What's inside</p>
      <h2>A comprehensive format reference library.</h2>
    </div>
    <div class="metrics-grid">
      <article>
        <p class="metric-label">Formats documented</p>
        <p class="metric-value">{{ site.data.site_stats.file_formats_total }}</p>
        <p class="metric-detail">Detailed specifications, diagrams, and implementation tips.</p>
      </article>
      <article>
        <p class="metric-label">Categories covered</p>
        <p class="metric-value">{{ site.data.site_stats.categories_total }}</p>
        <p class="metric-detail">From graphics and audio to printers, CAD, and communications.</p>
      </article>
      <article>
        <p class="metric-label">Specs archived</p>
        <p class="metric-value">{{ site.data.site_stats.entries_total }}+</p>
        <p class="metric-detail">Reference files, whitepapers, and utility documentation.</p>
      </article>
    </div>
  </section>

  <section class="landing-section feature-grid">
    <article class="feature-card">
      <h3>Explore the collection</h3>
      <p>Browse by format and category to find specs and decoding notes. For keyword searches, try a search engine with <code>site:wotsup.org</code>.</p>
      <a href="/site-structure/">Explore the information architecture →</a>
    </article>
    <article class="feature-card">
      <h3>Engineering ready</h3>
      <p>Entries focus on structures, fields, and practical tips for building parsers.</p>
      <a href="/how-to/">Developer guidance →</a>
    </article>
    <article class="feature-card">
      <h3>Community powered</h3>
      <p>Submit corrections or new specs via GitHub. Every contribution is reviewed.</p>
      <a href="/contributing/">Contributing guide →</a>
    </article>
  </section>

  <section class="landing-section split-panel">
    <article>
      <p class="eyebrow">Get involved</p>
      <h3>Help expand the documentation.</h3>
      <p>Contribute format specifications, add implementation notes, or improve existing documentation.
        All contributions are welcome via GitHub.</p>
      <ul class="pill-list">
        <li>Submit specs via GitHub</li>
        <li>Add decoding tips</li>
        <li>Improve metadata + tagging</li>
      </ul>
    </article>
    <article>
      <p class="eyebrow">New to the archive?</p>
      <h3>Start with the quick guides.</h3>
      <p>Learn how to navigate the archive and find the format information you need.</p>
      <div class="link-grid">
        <a href="/how-to/">How to use Wotsup.org</a>
        <a href="/faq/">Frequently asked questions</a>
        <a href="/contact/">Contact + support</a>
      </div>
    </article>
  </section>

  <section class="landing-section timeline">
    <div class="section-heading">
      <p class="eyebrow">Recent additions</p>
      <h2>Latest updates to the catalog.</h2>
    </div>
    {% if site.data.recent_updates %}
    {% assign groups = site.data.recent_updates | group_by: 'last_change_date' %}
    {% assign groups = groups | sort: 'name' | reverse %}
    {% else %}
    {% assign groups = '' | split: '' %}
    {% endif %}
    <ol class="timeline-list">
      {% for g in groups limit:3 %}
      <li>
        <span class="timeline-date">{{ g.name | date: "%b %-d, %Y" }}</span>
        <div>
          {% assign limit = 10 %}
          {% for u in g.items limit:limit %}
            <p><strong>{{ u.name }}</strong> {{ u.change_type }} – <a href="{{ u.url }}">view</a></p>
          {% endfor %}
          {% if g.items.size > limit %}
            <p class="more-count">+{{ g.items.size | minus: limit }} more</p>
          {% endif %}
        </div>
      </li>
      {% endfor %}
    </ol>
  </section>

  <section class="landing-section cta-panel">
    <div>
      <h2>Ready to contribute?</h2>
      <p>Every contribution helps keep file format knowledge accessible. Fork the repo, add your notes,
        and submit a pull request.</p>
    </div>
    <div class="cta-actions">
    <a class="btn btn-primary" href="https://github.com/Matt-17/Wotsup.org">View the repository</a>
      <a class="btn" href="/contributing/">Contribution guide</a>
    </div>
  </section>

  <section class="landing-section tribute">
    <p>Built on the foundation of Wotsit.org, originally created by Paul Oliver and contributors worldwide.
      Thanks to their pioneering work in documenting file formats. <a href="/about/">Read more about Wotsup.org →</a>
    </p>
  </section>
</div>