using Microsoft.EntityFrameworkCore;
using Npgsql;
using RealEstate.Shared.Models.Entities.Clients;

namespace RealEstate.Shared.Data.Context
{
    public class ClientsDBContext : DbContext
    {
        public ClientsDBContext(DbContextOptions<ClientsDBContext> options)
            : base(options) { }


        public ClientsDBContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<ClientsDBContext>()
                .UseNpgsql(builder.ConnectionString);

            return optionsBuilder.Options;
        }


        public DbSet<Client> Clients { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(c => c.Client_Id).IsUnique();

            modelBuilder
                .Entity<Contact>()
                .HasOne(cl => cl.Client)
                .WithOne(c => c.Contact)
                .HasForeignKey<Client>(cl => cl.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Client>()
               .HasOne(c => c.Contact)
               .WithOne(cl => cl.Client)
               .HasForeignKey<Contact>(cl => cl.Contact_Details)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("\"Host=127.0.0.1;Port=32769;Database=Clients;Username=postgres;Password=postgrespw;");
            }
        }
        
    }
}