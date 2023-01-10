using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.API.FactoryPattern
{
    public class EstatesDbContextFactory : IDesignTimeDbContextFactory<EstatesDBContext>
    {
        public EstatesDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstatesDBContext>();
            optionsBuilder.UseNpgsql("Data Source=blog.db");

            return new EstatesDBContext(optionsBuilder.Options);
        }
    }
}
