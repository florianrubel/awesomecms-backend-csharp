using LibContent.Models.Cache;

namespace ContentCacheApi.Services
{
    public interface IContentCacheService
    {
        Task<PageCacheItem?> GetPageCache(Guid id);
        Task<PageCacheItem> SetPageCache(PageCacheItem page);
        Task<CreateRouteCache> SetRouteCache(CreateRouteCache createRouteCache);
        Task<Guid?> GetRouteCache(string route);
    }
}