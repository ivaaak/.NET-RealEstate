using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace EstatesMicroservice.Services.Interfaces
{
    public interface IFavoritesService
    {
        Task AddEstateToClient(string clientId, Estate estate);

        Task AddExistingEstateToClientUsingId(string estateId, string clientId);

        Task RemoveEstateFromClientUsingId(string estateId, string clientId);

        Task<bool> ClientHasEstateUsingId(string estateId, string clientId);


        // Listings
        Task AddListingToClient(string clientId, Listing listing);

        Task<bool> RemoveListingFromClient(string clientId, string listingId);

        Task<bool> ClientHasListing(string clientId, string listingId);

    }
}
