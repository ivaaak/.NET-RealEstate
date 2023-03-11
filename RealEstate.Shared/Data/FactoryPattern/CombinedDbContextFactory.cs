using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.FactoryPattern
{
    public class CombinedDbContextFactory : IDesignTimeDbContextFactory<_CombinedContext>
    {
        public _CombinedContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<_CombinedContext>();
            optionsBuilder.UseNpgsql("");

            return new _CombinedContext(optionsBuilder.Options);
        }
    }
}
