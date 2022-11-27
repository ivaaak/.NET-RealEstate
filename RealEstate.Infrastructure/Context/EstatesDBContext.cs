using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.Infrastructure.Context
{
    public class EstatesDBContext : IdentityDbContext<ApplicationUser>
    {
        public EstatesDBContext(DbContextOptions<EstatesDBContext> options)
            : base(options) {}

        public DbSet<Estate> Estates { get; set; }

        public DbSet<Estate_Status> Estate_Statuses { get; set; }

        public DbSet<Estate_Type> Estate_Types { get; set; }

        public DbSet<In_Charge> In_Charges { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estate>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Estate_Status>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Estate_Type>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<In_Charge>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => c.Id).IsUnique();

            modelBuilder
                .Entity<Estate>()
                .HasOne(cl => cl.City)
                .WithMany(c => c.Estates)
                .HasForeignKey(cl => cl.City_Id)
                .OnDelete(DeleteBehavior.Restrict);
            
            //TODO add more relations

            base.OnModelCreating(modelBuilder);
        }
    }
}