using LibUniversal.Models.Entities.LocalizedEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace LibContent.Models.Entities.ContentElement
{
    public class ViewContentElement : ViewLocalizedEntity<LibContent.Entities.ContentElement>
    {
        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_PageId)]
        public Guid? PageId { get; set; }

        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_ContentElementTypeId)]
        public Guid ContentElementTypeId { get; set; }

        [SwaggerParameter(LibContent.Entities.ContentElement.DOC_Properties)]
        public Dictionary<string, object> Properties { get; set; }
    }
}
