using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Test._TestSetup.Data
{
    public class InMemoryDbContext : DbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<CombinedDBContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<CombinedDBContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new CombinedDBContext(dbContextOptions);

            context.Database.EnsureCreated();

        }

        public CombinedDBContext CreateContext() => new CombinedDBContext(dbContextOptions);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlite(connection);
            }
        }
    }
}
