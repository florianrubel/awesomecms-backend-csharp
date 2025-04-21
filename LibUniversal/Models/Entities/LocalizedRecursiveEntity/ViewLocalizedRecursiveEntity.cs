using LibUniversal.Models.Entities.RecursiveEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace LibUniversal.Models.Entities.LocalizedRecursiveEntity
{
    public class ViewLocalizedRecursiveEntity<EntityType> : ViewRecursiveEntity<EntityType>
    {
        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocaleId)]
        public Guid LocaleId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocalizationParentId)]
        public Guid? LocalizationParentId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_UseLocalizationFallback)]
        public bool UseLocalizationFallback { get; set; }
    }
}
