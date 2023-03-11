using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.Data.FactoryPattern
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
