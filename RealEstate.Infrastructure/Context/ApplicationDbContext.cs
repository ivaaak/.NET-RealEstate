using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data.Identity;

namespace RealEstate.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Deal> Deals { get; set; }
        
        //public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
                .HasIndex(c => c.Id)
                .IsUnique();

            modelBuilder
                .Entity<Property>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Properties)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Property>()
                .HasOne(c => c.Agent)
                .WithMany(d => d.Properties)
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Agent>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Agent>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}