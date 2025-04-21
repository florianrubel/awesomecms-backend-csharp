using Swashbuckle.AspNetCore.Annotations;

namespace LibContent.Models.Page
{
    public class MetaTag
    {
        [SwaggerParameter("Value of the meta tag.")]
        public string Value { get; set; }
"
        [SwaggerParameter("Prevents this meta tag from being inherited down the page tree.")]
        public bool DisableInheritance { get; set; }
    }
}
