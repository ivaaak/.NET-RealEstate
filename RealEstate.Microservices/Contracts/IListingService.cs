using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Listings;

namespace RealEstate.Microservices.Contracts
{
    public interface IListingService
    {
        Task<Listing> GetListingById(int id);

        Task<ListingViewModel> GetListingForEdit(int id);

        Task<IEnumerable<ListingViewModel>> GetListings();

        Task<bool> UpdateListing(ListingViewModel model);

        Task<bool> DeleteListing(int id);

        Task<IEnumerable<ListingViewModel>> SearchListings(string searchTerm);
    }
}
