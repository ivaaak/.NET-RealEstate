using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Test.Data
{
    public class InMemoryDbContext : DbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<_CombinedContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<_CombinedContext>()
                .UseSqlServer(connection)
                .Options;

            using var context = new _CombinedContext(dbContextOptions);

            context.Database.EnsureCreated();

        }

        public _CombinedContext CreateContext() => new _CombinedContext(dbContextOptions);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO add entity relations
            base.OnModelCreating(modelBuilder);
        }
    }
}
