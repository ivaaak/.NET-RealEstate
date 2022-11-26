using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Infrastructure.Context
{
    public class ListingsDBContext : IdentityDbContext<ApplicationUser>
    {
        public ListingsDBContext(DbContextOptions<ListingsDBContext> options)
            : base(options) {}

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .HasIndex(c => c.Id)
                .IsUnique();

            modelBuilder
                .Entity<Employee>()
                .HasOne(cl => cl.Company)
                .WithMany(cl => cl.Employees)
                .HasForeignKey(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
                .Entity<Listing>()
                .HasIndex(li => li.Id)
                .IsUnique();

            modelBuilder
               .Entity<Listing>()
               .HasOne(li => li.Estate)
               .WithOne(es => es.Listing)
               .HasForeignKey<Estate>(es => es.Listing)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}