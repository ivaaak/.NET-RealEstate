using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.FactoryPattern
{
    public class EstatesDbContextFactory : IDesignTimeDbContextFactory<EstatesDBContext>
    {
        public EstatesDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstatesDBContext>();
            optionsBuilder.UseNpgsql("");

            return new EstatesDBContext(optionsBuilder.Options);
        }
    }
}
