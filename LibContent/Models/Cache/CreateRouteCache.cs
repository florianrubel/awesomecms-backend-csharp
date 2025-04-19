using System.ComponentModel.DataAnnotations;

namespace LibContent.Models.Cache
{
    public class CreateRouteCache
    {
        [Required]
        public Guid? PageId { get; set; }

        public string Route { get; set; }
    }
}
