# Custom sitemap generator for Wotsup.org
# Generates sitemap.xml with page URLs that do not include the trailing
# `.html` extension while leaving the actual permalinks and generated files
# unchanged (so server rewrite rules can continue to serve `/about` -> `/about.html`).

require 'rexml/document'

module Jekyll
  class CustomSitemap < Generator
    safe true
    priority :lowest

    def generate(site)
      base = site.config['url'].to_s.chomp('/')
      sitemap = REXML::Document.new
      sitemap << REXML::XMLDecl.new('1.0', 'UTF-8')
      urlset = sitemap.add_element('urlset', {
        'xmlns' => 'http://www.sitemaps.org/schemas/sitemap/0.9'
      })

      # Collect pages, posts and collection documents
      items = []
      items.concat(site.pages)
      if site.respond_to?(:posts)
        items.concat(site.posts.docs) if site.posts.respond_to?(:docs)
      end
      site.collections.each_value do |coll|
        items.concat(coll.docs)
      end

      # Deduplicate by path
      seen = {}
      items.each do |item|
        next if item.data['sitemap'] == false
        # item.url may end with .html; we want to strip it for sitemap loc
        loc_path = item.url.to_s.sub(/\.html$/i, '')
        # Ensure root path becomes '/'
        loc_path = '/' if loc_path == ''
        next if seen[loc_path]
        seen[loc_path] = true

        url = urlset.add_element('url')
        url.add_element('loc').text = base + loc_path

        # Add lastmod if available
        lastmod = nil
        if item.data['last_modified_at']
          lastmod = item.data['last_modified_at']
        elsif item.respond_to?(:date) && item.data['date']
          lastmod = item.data['date']
        end
        if lastmod
          url.add_element('lastmod').text = lastmod.to_s
        end
      end

      # Write sitemap.xml to destination
      dest_path = File.join(site.dest, 'sitemap.xml')
      File.open(dest_path, 'w') do |f|
        formatter = REXML::Formatters::Pretty.new(2)
        formatter.compact = true
        formatter.write(sitemap, f)
      end
    end
  end
end
