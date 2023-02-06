using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Listings;

namespace ListingsMicroservice.Services
{
    public interface IListingService
    {
        // CREATE
        void Create(Listing model);

        // GET BY ID
        Task<Listing> GetListingById(int id);

        // GET FOR EDIT
        Task<ListingDTO> GetListingForEdit(int id);

        // GET LISTINGS
        Task<IEnumerable<ListingDTO>> GetListings();

        // UPDATE
        Task<bool> UpdateListing(ListingDTO model);

        // SOFT DELETE
        Task<bool> SoftDeleteListing(int id);

        // DELETE
        Task<bool> DeleteListing(int id);

        // SEARCH
        Task<IEnumerable<ListingDTO>> SearchListings(string searchTerm);
    }
}
