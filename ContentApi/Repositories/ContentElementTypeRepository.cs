using ContentApi.DbContexts;
using ContentApi.Services.ProductCache;
using LibContent.Entities;
using LibDb.Models.Api;
using LibUniversal.Helpers;
using LibUniversal.Models.Api;
using LibUniversal.StaticServices;

namespace ContentApi.Repositories
{
    public class ContentElementTypeRepository
        : LibDb.Repositories.UuidBaseRepository<MainDbContext, ContentElementType, SearchParameters>
        , IContentElementTypeRepository<ContentElementType, SearchParameters>
    {
        private readonly IContentCacheService _contentCacheService;

        public ContentElementTypeRepository(MainDbContext context, IContentCacheService contentCacheService) : base(context)
        {
            _contentCacheService = contentCacheService;
        }

        public void EnsureIntegrity(ContentElementType entity)
        {
            if (entity.Slug == null || entity.Slug.Trim().Length == 0)
            {
                entity.Slug = TextService.GetSlug(entity.Name);
            }
        }

        public async override Task<ContentElementType> Create(ContentElementType entity)
        {
            EnsureIntegrity(entity);

            var result = await base.Create(entity);

            return result;
        }

        public async override Task<IEnumerable<ContentElementType>> CreateRange(IEnumerable<ContentElementType> entities)
        {
            foreach (var entity in entities)
            {
                EnsureIntegrity(entity);
            }
            var results = await base.CreateRange(entities);

            return results;
        }

        public async override Task<PagedList<ContentElementType>> GetMultiple(SearchParameters parameters)
        {
            var collection = _dbSet as IQueryable<ContentElementType>;

            //if (parameters.SearchQuery != null && parameters.SearchQuery.Length >= InputSizes.DEFAULT_TEXT_MIN_LENGTH)
            //{
            //    collection = collection.Where(r =>
            //        (r.Properties != null && r.Properties.Values() .Contains(parameters.SearchQuery.ToLower()))
            //}

            collection = collection.ApplySort(parameters.OrderBy);

            var pagedList = await PagedList<ContentElementType>.Create(collection, parameters.Page, parameters.PageSize);

            return pagedList;
        }

        public async override Task<ContentElementType> Update(ContentElementType entity, ContentElementType? oldEntity = null)
        {
            EnsureIntegrity(entity);
            var result = await base.Update(entity, oldEntity);

            return result;
        }

        public async override Task<IEnumerable<ContentElementType>> UpdateRange(IEnumerable<ContentElementType> entities, IEnumerable<ContentElementType>? oldEntities = null)
        {
            foreach (var entity in entities)
            {
                EnsureIntegrity(entity);
            }
            var results = await base.UpdateRange(entities, oldEntities);

            return results;
        }
    }
}
