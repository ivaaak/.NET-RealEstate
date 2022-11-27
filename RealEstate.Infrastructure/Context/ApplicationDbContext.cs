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
            : base(options) {}

        public DbSet<Estate> Estates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contract> Contract { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}