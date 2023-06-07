using RealEstate.Shared.Models.Entities.Clients;

namespace ClientsMicroservice.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientById(string clientId);

        List<Client> GetAllClients();

        Task<bool> ClientExists(string clientId);

        Task<Client> AddClient(Client client);

        Client UpdateClient(Client client);

        Task SoftDeleteClient(string clientId);

        Task<bool> HardDeleteClient(string clientId);
    }
}
