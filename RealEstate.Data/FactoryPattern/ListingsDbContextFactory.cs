using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.Data.FactoryPattern
{
    public class ListingsDbContextFactory : IDesignTimeDbContextFactory<ListingsDBContext>
    {
        public ListingsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ListingsDBContext>();
            optionsBuilder.UseNpgsql("");

            return new ListingsDBContext(optionsBuilder.Options);
        }
    }
}
