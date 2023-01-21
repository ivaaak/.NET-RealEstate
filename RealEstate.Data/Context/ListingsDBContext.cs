using Microsoft.EntityFrameworkCore;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;

namespace RealEstate.Data.Context
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
            modelBuilder.Entity<Employee>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Listing>().HasIndex(li => li.Listing_Id).IsUnique();

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
               .HasForeignKey<Estate>(es => es.Listing_Id)
               .OnDelete(DeleteBehavior.Restrict);

            // GPT
            modelBuilder
                .Entity<Agent>()
                .HasOne(a => a.Agency)
                .WithMany(ag => ag.Agents)
                .HasForeignKey(a => a.Agent_Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Review>()
                .HasOne(pt => pt.Listing)
                .WithMany(p => p.Reviews)
                .HasForeignKey(pt => pt.Listing_Id);

            modelBuilder.Entity<Review>()
                .HasOne(pt => pt.Listing)
                .WithMany(t => t.Reviews)
                .HasForeignKey(pt => pt.Review_Id);


            modelBuilder.Entity<Listing>()
                .HasKey(t => new { t.Agent_Id, t.Listing_Id });

            modelBuilder.Entity<Listing>()
                .HasOne(pt => pt.Agent)
                .WithMany(p => p.Listings)
                .HasForeignKey(pt => pt.Agent_Id);

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

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.PriceHistory)
                .WithOne(ph => ph.Listing)
                .HasForeignKey<PriceHistory>(ph => ph.Listing_Id);

            modelBuilder.Entity<Listing>()
                .HasMany(l => l.Reviews)
                .WithOne(r => r.Listing)
                .HasForeignKey(r => new { r.Listing_Id, r.Review_Id });


            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Estate)
                .WithOne(e => e.Listing)
                .HasForeignKey<Estate>(e => e.Estate_Status_Id);

            modelBuilder.Entity<Estate>()
                .HasOne(l => l.Listing)
                .WithOne(e => e.Estate)
                .HasForeignKey<Estate>(e => e.Listing_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}