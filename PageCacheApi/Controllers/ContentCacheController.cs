using ContentCacheApi.Services;
using LibContent.Entities;
using LibContent.Models.Cache;
using LibUniversal.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PageCacheApi.Controllers
{
    [ApiController]
    [Route("page-cache")]
    public class ContentCacheController : BasicControllerTemplate
    {
        private readonly IContentCacheService _pageCacheService;

        public ContentCacheController(IContentCacheService pageCacheService)
        {
            _pageCacheService = pageCacheService;
        }

        [HttpGet]
        [Route("by-id/{pageId}")]
        public async Task<ActionResult<PageCacheItem>> GetById(Guid pageId)
        {
            var result = await _pageCacheService.GetPageCache(pageId);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("by-route")]
        public async Task<ActionResult<PageCacheItem?>> GetByRoute([FromBody] RouteCacheRequest routeCacheRequest)
        {
            var routeCache = await _pageCacheService.GetRouteCache(routeCacheRequest.Route);
            if (routeCache == null) return BadRequest();
            var result = await _pageCacheService.GetPageCache((Guid)routeCache);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PageCacheItem>> Set([FromBody] PageCacheItem page)
        {
            await _pageCacheService.SetRouteCache(
                new CreateRouteCache
                {
                    Route = page.Route,
                    PageId = page.Id
                }
            );
            return await _pageCacheService.SetPageCache(page);
        }
    }
}
