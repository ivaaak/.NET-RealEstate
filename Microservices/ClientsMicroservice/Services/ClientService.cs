using ClientsMicroservice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Clients;

namespace ClientsMicroservice.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientsDbRepository _clientsDbRepository;

        public ClientService(IClientsDbRepository clientsDbRepository)
        {
            _clientsDbRepository = clientsDbRepository;
        }

        public async Task<Client> GetClientById(string clientId)
        {
            var client = await _clientsDbRepository.GetByIdAsync<Client>(clientId);

            return client;
        }

        public List<Client> GetAllClients()
        {
            var clients = _clientsDbRepository.All<Client>().ToList();

            return clients;
        }

        public async Task<bool> ClientExists(string clientId)
        {
            // Read-only check so the entity isn't tracked before a subsequent Update() of the same key
            return await _clientsDbRepository.AllReadonly<Client>(c => c.Id == clientId).AnyAsync();
        }


        public async Task<Client> AddClient(Client client)
        {
            try
            {
                await _clientsDbRepository.AddAsync(client);

                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the client: {ex.Message}");

                throw;
            }
        }

        public Client UpdateClient(Client client)
        {
            try
            {
                _clientsDbRepository.Update(client);
                _clientsDbRepository.SaveChanges();

                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the client: {ex.Message}");

                throw;
            }
        }
        public async Task SoftDeleteClient(string clientId)
        {
            await _clientsDbRepository.DeleteAsync<Client>(clientId);
        }

        public async Task<bool> HardDeleteClient(string clientId)
        {
            try
            {
                await _clientsDbRepository.DeleteAsync<Client>(clientId);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the client: {ex.Message}");

                throw;
            }
        }
    }
}
