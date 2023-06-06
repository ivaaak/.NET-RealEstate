using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace ListingsMicroservice.Data.Context
{
    public class ListingsDBContext : DbContext
    {
        public ListingsDBContext(DbContextOptions<ListingsDBContext> options)
            : base(options) { }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ListingStats> ListingStats { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Review> Review { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .HasOne(cl => cl.Company)
                .WithMany(cl => cl.Employees)
                .HasForeignKey(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Listing>()
               .HasOne(li => li.Estate)
               .WithOne(es => es.Listing)
               .HasForeignKey<Estate>(es => es.Id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Contact>()
               .HasOne(co => co.Client)
               .WithOne(cl => cl.Contact)
               .HasForeignKey<Contact>(co => co.Client_Id)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}