using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Test._TestSetup.Data
{
    public class InMemoryDbContext : DbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<CombinedAppContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<CombinedAppContext>()
                .UseSqlServer(connection)
                .Options;

            using var context = new CombinedAppContext(dbContextOptions);

            context.Database.EnsureCreated();

        }

        public CombinedAppContext CreateContext() => new CombinedAppContext(dbContextOptions);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(connection);
            }
        }
    }
}
