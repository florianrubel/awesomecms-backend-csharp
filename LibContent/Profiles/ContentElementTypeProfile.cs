using LibContent.Entities;
using LibContent.Models.Entities;
using LibContent.Models.Entities.ContentElementType;
using LibUniversal.Profiles;

namespace LibContent.Profiles
{
    public class ContentElementTypeProfile : DefaultProfile<
        ContentElementType,
        ViewContentElementType,
        CreateContentElementType,
        PatchContentElementType
    >
    {
    }
}
