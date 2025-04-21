using LibContent.Entities;
using LibContent.Models.Cache;
using LibContent.Models.Entities.Page;
using LibUniversal.Profiles;

namespace LibContent.Profiles
{
    public class PageProfile : DefaultProfile<Page, ViewPage, CreatePage, PatchPage>
    {
        public PageProfile() : base()
        {
            CreateMap<Page, PageCacheItem>();
        }
    }
}
