using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.Entities.Listings;

namespace ListingsMicroservice.Services
{
    public interface IListingService
    {
        // CREATE
        Task<Listing> Create(Listing model);

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
