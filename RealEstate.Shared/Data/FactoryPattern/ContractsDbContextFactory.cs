using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.FactoryPattern
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
