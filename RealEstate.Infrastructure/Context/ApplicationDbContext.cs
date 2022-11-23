using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Entities;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Contracts;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estate> Estates { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Contract> Contract { get; set; }
        
        //public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.Id)
                .IsUnique();
            /*
            modelBuilder
                .Entity<Estate>()
                .HasOne(c => c.Estate_Type_Id)
                .WithMany(c => c.Properties)
                .HasForeignKey(c => c.)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder
                .Entity<Estate>()
                .HasOne(c => c.)
                .WithMany(d => d.Properties)
                .HasForeignKey(c => c.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Agent>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Agent>(d => d.Id)
                .OnDelete(DeleteBehavior.Restrict);
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}