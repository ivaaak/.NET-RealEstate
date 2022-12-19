using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Listings;

namespace RealEstate.Microservices.Contracts
{
    public interface IListingService
    {
        // GET BY ID
        Task<Listing> GetListingById(int id);
        
        // GET FOR EDIT
        Task<ListingViewModel> GetListingForEdit(int id);

        // GET LISTINGS
        Task<IEnumerable<ListingViewModel>> GetListings();

        // UPDATE
        Task<bool> UpdateListing(ListingViewModel model);

        // DELETE
        Task<bool> DeleteListing(int id);
        
        // SEARCH
        Task<IEnumerable<ListingViewModel>> SearchListings(string searchTerm);
    }
}
