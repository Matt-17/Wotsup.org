---
layout: extensions_panel
title: Categories
permalink: /extensions/
---

<div class="categories-wrapper">

    {% assign all_categories = site.data.categories.categories | sort: "name" %}

    <header class="categories-header">
        <h1>{{ page.title | default: "All Categories" }}</h1>
        <p class="categories-tagline">Browse and explore file formats organized by category.</p>
        
        <p>
        Discover <strong>{{ all_categories.size }}</strong> categories covering thousands of file formats. Select a category below to browse specifications, hardware notes, and implementation guides.
        </p>
        
    </header>

    <div class="categories-grid">
        {% for category in all_categories %}
            {% assign count = site.data.catalog_flat | where_exp: "item", "item.category == category.slug or item.categories contains category.slug" | size %}
            
            <a class="category-card" href="/categories/{{ category.slug }}">
                <div class="category-content">
                    <h2>{{ category.name }}</h2>
                    <p>{{ category.description }}</p>
                </div>
                <div class="category-meta">
                    <span class="badge">{{ count }} format{% if count != 1 %}s{% endif %}</span>
                </div>
            </a>
        {% endfor %}
    </div>

</div>

<style>
    .categories-wrapper {
        max-width: 100%;
        margin: 0 auto;
    }

    .categories-header {
        background: linear-gradient(120deg, rgba(37, 99, 235, 0.15), rgba(124, 58, 237, 0.15));
        border-bottom: 1px solid rgba(37, 99, 235, 0.2);
        padding: 3rem 1.5rem;
        margin-bottom: 2rem;
        border-radius: 12px;
        text-align: left;
    }

    .categories-header h1 {
        margin: 0 0 0.5rem;
        font-size: 2.2rem;
        font-weight: 700;
        background: linear-gradient(120deg, #2563eb, #7c3aed);
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
        background-clip: text;
        color: #7c3aed;
    }

    .categories-tagline {
        font-size: 1.1rem;
        color: #9ca3af;
        margin: 0 0 1.5rem 0;
    }

    .categories-grid {
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
        gap: 1.75rem;
    }

    .category-card {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        background: linear-gradient(135deg, rgba(37, 99, 235, 0.03), rgba(124, 58, 237, 0.04));
        border: 1px solid rgba(37, 99, 235, 0.15);
        padding: 1.75rem;
        border-radius: 12px;
        text-decoration: none;
        transition: all 0.3s ease;
    }

    .category-card:hover {
        background: linear-gradient(135deg, rgba(37, 99, 235, 0.08), rgba(124, 58, 237, 0.08));
        border-color: rgba(37, 99, 235, 0.3);
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        text-decoration: none;
    }

    .category-card h2 {
        margin: 0 0 0.75rem;
        font-size: 1.4rem;
        color: #e5e7eb;
        font-weight: 600;
    }

    .category-card:hover h2 {
        color: #7c3aed;
    }

    .category-card p {
        color: #9ca3af;
        font-size: 0.95rem;
        line-height: 1.5;
        margin: 0;
        margin-bottom: 1.5rem;
    }

    .category-meta {
        margin-top: auto; 
    }

    .badge {
        display: inline-block;
        font-size: 0.85rem;
        font-weight: 600;
        color: #3b82f6;
        background: rgba(37, 99, 235, 0.15);
        padding: 0.35rem 0.75rem;
        border-radius: 6px;
    }

    @media (max-width: 768px) {
        .categories-grid { grid-template-columns: 1fr; }
    }
</style>