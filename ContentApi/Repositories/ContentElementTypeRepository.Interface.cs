using LibContent.Entities;
using LibDb.Repositories;
using LibUniversal.Models.Api;

namespace ContentApi.Repositories
{
    public interface IContentElementTypeRepository<EntityType, SearchParametersType> : IUuidBaseRepository<EntityType, SearchParametersType>
        where EntityType : ContentElementType
        where SearchParametersType : SearchParameters
    {
    }
}