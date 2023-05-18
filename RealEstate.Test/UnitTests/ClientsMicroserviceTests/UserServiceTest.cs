#nullable disable
using ClientsMicroservice.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RealEstate.Shared.Data.Repository;
using RealEstate.Test._TestSetup.Data;

namespace RealEstate.Test.UnitTests.ClientsMicroserviceTests
{
    public class UserServiceTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .BuildServiceProvider();
            //.AddSingleton<IUserService, UserService>()

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            var testDbContext = serviceProvider.GetService<ClientsDBContext>();

            await SeedDbAsync(testDbContext);
        }

        //AddActorToUserList - this uses api if actor isnt in db already
        [Test]
        public void GetUsers_ValidCall()
        {
            //var service = serviceProvider.GetService<IUserService>();
            //Assert.DoesNotThrow(() => service.GetUsers());
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
        private async Task SeedDbAsync(ClientsDBContext dbContext) //should be in memory/ repo?
        {
            var client = TestConstants.client;
            /*
            var estate = TestConstants.estate;
            var contract = TestConstants.contract;
            var listing = TestConstants.listing;
            var employee = TestConstants.employee;

            await dbContext.Estates.AddAsync(estate);
            await dbContext.Contracts.AddAsync(contract);
            await dbContext.Listings.AddAsync(listing);
            await dbContext.Employees.AddAsync(employee);
            */
            await dbContext.Clients.AddAsync(client);

            await dbContext.SaveChangesAsync();
            // Inherited from DbContext
        }
    }
}