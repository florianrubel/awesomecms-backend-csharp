using Swashbuckle.AspNetCore.Annotations;

namespace LibUniversal.Models.Entities.RecursiveEntity
{
    public class RecursiveEntitySearchParameters
    {
        [SwaggerParameter("A comma separated list of guids with page ids.")]
        public string? ParentIds { get; set; }
    }
}
