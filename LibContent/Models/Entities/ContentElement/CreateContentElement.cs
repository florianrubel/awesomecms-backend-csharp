using LibUniversal.Models.Entities.LocalizedEntity;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace LibContent.Models.Entities.ContentElement
{
    public class CreateContentElement : CreateLocalizedEntity<LibContent.Entities.ContentElement>
    {
        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_PageId)]
        public Guid? PageId { get; set; }

        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_ContentElementTypeId)]
        [Required]
        public Guid? ContentElementTypeId { get; set; }

        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_Properties)]
        public Dictionary<string, object> Properties { get; set; }
    }
}
