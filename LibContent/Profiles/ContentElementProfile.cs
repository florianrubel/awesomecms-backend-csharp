using LibContent.Entities;
using LibContent.Models.Cache;
using LibContent.Models.Entities.ContentElement;
using LibUniversal.Profiles;

namespace LibContent.Profiles
{
    public class ContentElementProfile : DefaultProfile<
        ContentElement,
        ViewContentElement,
        CreateContentElement,
        PatchContentElement
    >
    {
        public ContentElementProfile() : base()
        {
            CreateMap<ContentElement, ContentElementCacheItem>();
        }
    }
}
