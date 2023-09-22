using EstatesMicroservice.Services.Interfaces;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace EstatesMicroservice.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IEstatesDbRepository _estatesDbRepository;
        private readonly IClientsDbRepository _clientsDbRepository;

        public FavoritesService(
            IEstatesDbRepository estatesDbRepository,
            IClientsDbRepository clientsDbRepository)
        {
            _estatesDbRepository = estatesDbRepository;
            _clientsDbRepository = clientsDbRepository;
        }


        public async Task AddEstateToClient(string clientId, Estate estate)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);

            if (client != null)
            {
                client.Estates.Add(estate);
                _clientsDbRepository.Update(client);
            }
        }

        public async Task AddExistingEstateToClientUsingId(string estateId, string clientId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);
            var estate = await _estatesDbRepository.GetByIdAsync<Estate>(estateId);

            if (client != null && estate != null)
            {
                client.Estates.Add(estate);
                _clientsDbRepository.Update(client);
            }
        }

        public async Task RemoveEstateFromClientUsingId(string estateId, string clientId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);
            var estate = await _estatesDbRepository.GetByIdAsync<Estate>(estateId);

            if (client != null && estate != null)
            {
                client.Estates.Remove(estate);
                _clientsDbRepository.Update(client);
            }
        }

        public async Task<bool> ClientHasEstateUsingId(string estateId, string clientId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);
            var estate = await _estatesDbRepository.GetByIdAsync<Estate>(estateId);

            if (client != null && estate != null)
            {
                return client.Estates.Contains(estate);
            }

            return false;
        }

        // Listings
        public async Task AddListingToClient(string clientId, Listing listing)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);

            if (client != null)
            {
                client.Listings.Add(listing);
                _clientsDbRepository.Update(client);
            }
        }

        public async Task<bool> RemoveListingFromClient(string clientId, string listingId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);

            if (client != null)
            {
                var listingToRemove = client.Listings.Find(listing => listing.Id == listingId);
                if (listingToRemove != null)
                {
                    client.Listings.Remove(listingToRemove);
                    _clientsDbRepository.Update(client);
                    return true; // Listing removed successfully
                }
            }

            return false; // Listing not found or removal unsuccessful
        }


        public async Task<bool> ClientHasListing(string clientId, string listingId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);

            if (client != null)
            {
                return client.Listings.Exists(listing => listing.Id == listingId);
            }

            return false;
        }
    }
}

