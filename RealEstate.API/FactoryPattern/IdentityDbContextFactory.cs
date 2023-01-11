using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.API.FactoryPattern
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityUsersDBContext>
    {
        public IdentityUsersDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityUsersDBContext>();
            optionsBuilder.UseNpgsql("");

            return new IdentityUsersDBContext(optionsBuilder.Options);
        }
    }
}
