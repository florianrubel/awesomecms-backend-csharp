using LibContent.Entities;
using LibContent.Models.Cache;
using StackExchange.Redis;
using System.Text.Json;

namespace ContentCacheApi.Services
{
    public class ContentCacheService : IContentCacheService
    {
        private readonly string _connectionString;
        private const string PREFIX_PAGE = "PAGE:";
        private const string PREFIX_ROUTE = "ROUTE:";

        public ContentCacheService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Redis");
        }

        private string GetPageKey(Guid pageId)
        {
            return $"{PREFIX_PAGE}{pageId}";
        }

        private string GetRouteKey(string route)
        {
            return $"{PREFIX_ROUTE}{route}";
        }

        public async Task<PageCacheItem> SetPageCache(PageCacheItem page)
        {
            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = redis.GetDatabase();
            var key = GetPageKey(page.Id);
            var json = JsonSerializer.Serialize(page);
            await db.StringSetAsync(key, json);
            redis.Close();
            return page;
        }

        public async Task<PageCacheItem?> GetPageCache(Guid id)
        {
            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = redis.GetDatabase();
            var key = GetPageKey(id);
            var json = await db.StringGetAsync(key);
            if (json == RedisValue.Null) return null;
            var page = JsonSerializer.Deserialize<PageCacheItem>(json);
            redis.Close();
            return page;
        }

        public async Task<CreateRouteCache> SetRouteCache(CreateRouteCache createRouteCache)
        {
            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = redis.GetDatabase();
            var key = GetRouteKey(createRouteCache.Route);
            await db.StringSetAsync(key, createRouteCache.PageId.ToString());
            return createRouteCache;
        }

        public async Task<Guid?> GetRouteCache(string route)
        {
            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(_connectionString);
            var db = redis.GetDatabase();
            var key = GetRouteKey(route);
            var guid = db.StringGet(key);
            return guid == RedisValue.Null ? null : Guid.Parse(guid.ToString());
        }
    }

}
