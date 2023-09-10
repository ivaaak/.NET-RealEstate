using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.QueryObjects;

namespace EstatesMicroservice.Services.Interfaces
{
    public interface IEstateQueryService
    {
        Task<PagedResult<EstateDTO>> FindByCriteriaAsync(SearchCriteriaObject criteria);
    }
}
