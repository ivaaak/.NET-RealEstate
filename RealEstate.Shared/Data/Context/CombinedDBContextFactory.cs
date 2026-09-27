using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstate.Shared.Data.Context
{
    // Used by `dotnet ef` (migrations / database update) so it doesn't need to boot a microservice host
    public class CombinedDBContextFactory : IDesignTimeDbContextFactory<CombinedDBContext>
    {
        public CombinedDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CombinedDBContext>()
                .UseNpgsql(GlobalConnectionStrings.RealEstate_DB_Connection)
                .Options;

            return new CombinedDBContext(options);
        }
    }
}
