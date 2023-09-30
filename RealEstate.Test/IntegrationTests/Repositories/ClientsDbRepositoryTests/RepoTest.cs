using ClientsMicroservice.Data.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Repository;
using RealEstate.Shared.Models.Entities.Clients;
using Xunit;
using Xunit.Abstractions;

namespace RealEstate.Test.IntegrationTests.Repositories.ClientsDbRepositoryTests
{
    public class GetById
    {
        private readonly ClientsDBContext _clientsContext;
        private readonly ClientsDbRepository _clientsRepository;
        private readonly ITestOutputHelper _output;
        private readonly ICacheService cacheService;
        public GetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<ClientsDBContext>()
                .UseInMemoryDatabase(databaseName: "TestClient")
                .Options;
            _clientsContext = new ClientsDBContext(dbOptions);
            _clientsRepository = new ClientsDbRepository(_clientsContext, cacheService);
        }

        [Fact]
        public async Task GetsExistingClient()
        {
            var existingClient = new Client()
            {

            };
            _clientsContext.Clients.Add(existingClient);
            _clientsContext.SaveChanges();
            string clientId = existingClient.Id;
            _output.WriteLine($"clientId: {clientId}");

            var clientFromRepo = await _clientsRepository.GetByIdAsync<Client>(clientId);
            Assert.AreEqual("thing", clientFromRepo.Id);
        }
    }
}
