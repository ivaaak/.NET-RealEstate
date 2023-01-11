using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.API.FactoryPattern
{
    public class ContractsDbContextFactory : IDesignTimeDbContextFactory<ContractsDBContext>
    {
        public ContractsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContractsDBContext>();
            optionsBuilder.UseNpgsql("");

            return new ContractsDBContext(optionsBuilder.Options);
        }
    }
}
