# Custom sitemap generator for Wotsup.org
# Generates sitemap.xml with page URLs that do not include the trailing
# `.html` extension while leaving the actual permalinks and generated files
# unchanged (so server rewrite rules can continue to serve `/about` -> `/about.html`).

require 'rexml/document'
require 'fileutils'

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
        
        # Build path from directory + basename (without extension)
        # This avoids the .html suffix entirely
        dir = item.dir.to_s
        basename = item.basename.to_s
        
        # Remove .html, .md, or other extensions from basename
        basename_without_ext = basename.sub(/\.[^.]+$/, '')
        
        # Construct the clean URL path
        if basename_without_ext == 'index'
          # index files become just their directory (or root)
          loc_path = dir.empty? ? '/' : dir
          loc_path = '/' if loc_path == ''
        else
          # Regular files/pages
          loc_path = File.join(dir, basename_without_ext).gsub('\\', '/').sub(/^\/$/, '')
          loc_path = '/' if loc_path == '' || loc_path == '.'
        end
        
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
      # Ensure destination directory exists (Jekyll may not have created it yet)
      FileUtils.mkdir_p(File.dirname(dest_path))

      File.open(dest_path, 'w') do |f|
        formatter = REXML::Formatters::Pretty.new(2)
        formatter.compact = true
        formatter.write(sitemap, f)
      end
    end
  end
end
