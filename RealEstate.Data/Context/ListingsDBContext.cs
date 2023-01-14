using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Listing>().HasIndex(li => li.Id).IsUnique();

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
               .HasForeignKey<Estate>(es => es.Listing)
               .OnDelete(DeleteBehavior.Restrict);

            // GPT
            modelBuilder
                .Entity<Agent>()
                .HasOne(a => a.Agency)
                .WithMany(ag => ag.Agents)
                .HasForeignKey(a => a.Agency.Name)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Comment>()
                .HasOne(c => c.Listing)
                .WithMany(l => l.Comments)
                .HasForeignKey(c => c.Comment_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<PriceHistory>()
                .HasOne(ph => ph.Listing)
                .WithMany(l => l.PriceHistories)
                .HasForeignKey(ph => ph.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasKey(t => new { t.ListingId, t.ReviewId });

            modelBuilder.Entity<Review>()
                .HasOne(pt => pt.Listing)
                .WithMany(p => p.Reviews)
                .HasForeignKey(pt => pt.ListingId);

            modelBuilder.Entity<Review>()
                .HasOne(pt => pt.Listing)
                .WithMany(t => t.Reviews)
                .HasForeignKey(pt => pt.ReviewId);


            modelBuilder.Entity<Listing>()
                .HasKey(t => new { t.AgentId, t.ListingId });

            modelBuilder.Entity<Listing>()
                .HasOne(pt => pt.Agent)
                .WithMany(p => p.Listings)
                .HasForeignKey(pt => pt.AgentId);
            /*
            modelBuilder.Entity<Listing>()
                .HasOne(pt => pt.Estate)
                .WithMany(t => t.)
                .HasForeignKey(pt => pt.ListingId);
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}