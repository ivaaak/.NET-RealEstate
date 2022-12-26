using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Context;

namespace RealEstate.Test.Data
{
    public class InMemoryDbContext : DbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);

            context.Database.EnsureCreated();

        }

        public ApplicationDbContext CreateContext() => new ApplicationDbContext(dbContextOptions);

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
