using LibContent.Entities;
using LibContent.Models.Cache;
using LibUniversal.StaticServices;

namespace ContentApi.StaticServices
{
    public static class PageTreeService
    {
        public static string ResolveSlug(Page page)
        {
            var slugSource = page.Title;
            if (page.NavigationTitle != null) slugSource = page.NavigationTitle;

            var slug = TextService.GetSlug(slugSource);

            if (page.slug == null) return slug;

            if (!page.LockSlug && page.slug != slug) return slug;

            return page.slug;
        }

        public static void ResolveRoute(PageCacheItem cacheItem, Page? parent)
        {
            if (cacheItem.IsRoot)
            {
                cacheItem.RelativePath = "";
                cacheItem.Route = cacheItem.Domain ?? "";
                return;
            }
            cacheItem.RelativePath = $"/{cacheItem.slug}";

            if (parent == null) return;

            if (parent.IsRoot)
            {
                cacheItem.Domain = parent.Domain;
                cacheItem.Route = $"{cacheItem.Domain}{cacheItem.RelativePath}";
                return;
            }

            var parentSlug = parent.slug ?? ResolveSlug(parent);
            cacheItem.RelativePath = $"/{parentSlug}{cacheItem.RelativePath}";

            if (parent.Parent != null) ResolveRoute(cacheItem, parent.Parent);
        }
    }
}
