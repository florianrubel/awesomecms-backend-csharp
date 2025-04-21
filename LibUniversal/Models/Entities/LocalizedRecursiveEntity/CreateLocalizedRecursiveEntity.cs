using LibUniversal.Models.Entities.RecursiveEntity;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace LibUniversal.Models.Entities.LocalizedRecursiveEntity
{
    public class CreateLocalizedRecursiveEntity<EntityType> : CreateRecursiveEntity<EntityType>
    {
        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocaleId)]
        [Required]
        public Guid? LocaleId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_LocalizationParentId)]
        [Required]
        public Guid? LocalizationParentId { get; set; }

        [SwaggerParameter(LibUniversal.Entities.LocalizedRecursiveEntity<EntityType>.DOC_UseLocalizationFallback)]
        public bool UseLocalizationFallback { get; set; }
    }
}
