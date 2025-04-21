using LibContent.Entities;
using LibContent.Models.Page;
using LibUniversal.Entities;
using LibUniversal.Models.Entities.UuidBaseEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace LibContent.Models.Cache
{
    public class PageCacheItem : ViewUuidBaseEntity
    {
        [SwaggerParameter(LibContent.Entities.Page.DOC_Title)]
        public string Title { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_NavigationTitle)]
        public string? NavigationTitle { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_MetaDescription)]
        public string? MetaDescription { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_MetaTags)]
        public Dictionary<string, MetaTag>? MetaTags { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_IsRoot)]
        public bool IsRoot { get; set; } = false;

        [SwaggerParameter(LibContent.Entities.Page.DOC_Domain)]
        public string? Domain { get; set; }

        [SwaggerParameter(RecursiveEntity<PageCacheItem>.DOC_Order)]
        public int Order { get; set; }

        [SwaggerParameter(LibContent.Entities.Page.DOC_Slug)]
        public string slug { get; set; }

        [SwaggerParameter("Relative path within the page tree.")]
        public string RelativePath { get; set; }

        [SwaggerParameter("Full path with the domain.")]
        public string Route { get; set; }

        [SwaggerParameter(LocalizedRecursiveEntity<PageCacheItem>.DOC_LocaleId)]
        public Guid LocaleId { get; set; }

        public List<ContentElementCacheItem> ContentElements { get; set; }
    }
}
