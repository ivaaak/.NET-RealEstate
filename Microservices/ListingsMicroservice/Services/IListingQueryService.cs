using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.QueryObjects;

namespace ListingsMicroservice.Services
{
    public interface IListingQueryService
    {
        Task<PagedResult<ListingDTO>> FindByCriteriaAsync(SearchCriteriaObject criteria);
    }
}
