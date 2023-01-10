using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.API.FactoryPattern
{
    public class ClientsDbContextFactory : IDesignTimeDbContextFactory<ClientsDBContext>
    {
        public ClientsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClientsDBContext>();
            optionsBuilder.UseNpgsql("Data Source=blog.db");

            return new ClientsDBContext(optionsBuilder.Options);
        }
    }
}
