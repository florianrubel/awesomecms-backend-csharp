using LibUniversal.Models.Entities.UuidBaseEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace LibUniversal.Models.Entities.LocalizedEntity
{
    public class PatchLocalizedEntity<EntityType> : PatchUuidBaseEntity
    {
        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocaleId)]
        public Guid? LocaleId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocalizationParentId)]
        public Guid? LocalizationParentId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_UseLocalizationFallback)]
        public bool? UseLocalizationFallback { get; set; }
    }
}
