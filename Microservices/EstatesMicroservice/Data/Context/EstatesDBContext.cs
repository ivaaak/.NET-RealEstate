using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Data.Context
{
    public class EstatesDBContext : DbContext
    {
        public EstatesDBContext(DbContextOptions<EstatesDBContext> options)
            : base(options) { }

        public DbSet<Estate> Estates { get; set; }
        public DbSet<Estate_Status> Estate_Statuses { get; set; }
        public DbSet<Estate_Type> Estate_Types { get; set; }
        public DbSet<In_Charge> In_Charges { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Estate>()
                .HasOne(cl => cl.City)
                .WithMany(c => c.Estates)
                .HasForeignKey(cl => cl.City_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(cl => cl.Cities)
                .HasForeignKey(c => c.Country_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<PriceHistory>()
                .Ignore(ph => ph.OffersHistoryTouples);


            modelBuilder
                .Entity<Contact>()
                .HasOne(cl => cl.Client)
                .WithOne(c => c.Contact)
                .HasForeignKey<Client>(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Client>()
               .HasOne(c => c.Contact)
               .WithOne(cl => cl.Client)
               .HasForeignKey<Contact>(cl => cl.Contact_Details)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(c => c.Id).IsUnique();

            modelBuilder
               .Entity<Listing>()
               .HasOne(c => c.Estate)
               .WithOne(cl => cl.Listing)
               .HasForeignKey<Estate>(cl => cl.Listing_Id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Listing>()
               .HasOne(c => c.PriceHistory)
               .WithOne(cl => cl.Listing)
               .HasForeignKey<PriceHistory>(cl => cl.Listing_Id)
               .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}