using LibContent.Entities;
using LibUniversal.Entities;
using LibUniversal.Models.Entities.UuidBaseEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace LibContent.Models.Cache
{
    public class ContentElementCacheItem : ViewUuidBaseEntity
    {
        [SwaggerParameter(ContentElementType.DOC_Slug)]
        public string ContentElementTypeSlug { get; set; }

        [SwaggerParameter(ContentElementType.DOC_FieldConfig)]
        public string ContentELementTypeFieldConfig { get;set; }

        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_Properties)]
        public Dictionary<string, object> Properties { get; set; }

        [SwaggerParameter(RecursiveEntity<PageCacheItem>.DOC_Order)]
        public int Order { get; set; }

        [SwaggerParameter(LocalizedRecursiveEntity<ContentElementCacheItem>.DOC_LocaleId)]
        public Guid LocaleId { get; set; }
    }
}
