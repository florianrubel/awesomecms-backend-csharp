using AutoMapper;
using ContentApi.Repositories;
using ContentApi.StaticServices;
using LibContent.Entities;
using LibContent.Models.Cache;
using LibContent.Models.Page;

namespace ContentApi.Factories
{
    public class PageCacheFactory
    {
        private readonly IMapper _mapper;

        public PageCacheFactory(
            IMapper mapper,
            IContentElementRepository<ContentElement, ContentELementS>
        )
        {
            _mapper = mapper;
        }

        private void ResolvePageLocalizationFallback(Page page, PageCacheItem subject)
        {
            if (!page.UseLocalizationFallback) return;
            if (page.LocalizationParent == null) return;

            if (subject.Title == null) subject.Title = page.LocalizationParent.Title;
            if (subject.NavigationTitle == null) subject.NavigationTitle = page.LocalizationParent.NavigationTitle;
            if (subject.MetaDescription == null) subject.MetaDescription = page.LocalizationParent.MetaDescription;
        }

        private void ResolveMetaTags(Page parent, PageCacheItem subject)
        {
            if (subject.MetaTags == null) subject.MetaTags = new Dictionary<string, MetaTag>();
            if (parent.MetaTags != null)
            {
                foreach (var metaTag in parent.MetaTags)
                {
                    if (metaTag.Value.DisableInheritance) continue;
                    if (subject.MetaTags.ContainsKey(metaTag.Key)) continue;

                    subject.MetaTags.Add(metaTag.Key, metaTag.Value);
                }
            }
            if (parent.InheritMetaTagsFromParent && parent.Parent != null)
            {
                ResolveMetaTags(parent.Parent, subject);
            } 
        }
        public PageCacheItem BuildPageCacheItem(Page page)
        {
            var cacheItem = _mapper.Map<PageCacheItem>(page);

            PageTreeService.ResolveRoute(cacheItem, page.Parent);
            if (page.InheritMetaTagsFromParent && page.Parent != null) ResolveMetaTags(page.Parent, cacheItem);

            ResolvePageLocalizationFallback(page, cacheItem);

            var contentElements = page.
            
            foreach(var contentElement in cacheItem.ContentElements)
            {
                contentElement.ContentElementTypeSlug = 
            }


            return cacheItem;
        }
    }
}
