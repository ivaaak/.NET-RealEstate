using Microsoft.EntityFrameworkCore;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.Data.Context
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

            modelBuilder
                .Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(cl => cl.Cities)
                .HasForeignKey(c => c.Country_Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Category>()
                .HasKey(t => new { t.Id });
            /*
                        modelBuilder.Entity<Category>()
                            .HasOne(pt => pt.Estate)
                            .WithMany(p => p.Categories)
                            .HasForeignKey(pt => pt.EstateId);

                        modelBuilder.Entity<Category>()
                            .HasOne(pt => pt.Estate)
                            .WithMany(t => t.Estates)
                            .HasForeignKey(pt => pt.CategoryId);


                        modelBuilder.Entity<Estate>()
                            .HasOne(e => e.Address)
                            .WithMany(i => i.)
                            .HasForeignKey<In_Charge>(i => i.EstateId);


                        modelBuilder
                            .Entity<Estate>()
                            .HasOne(e => e.Estate_Type)
                            .WithMany(cl => cl.Estates)
                            .HasForeignKey(e => e.EstateTypeId)
                            .OnDelete(DeleteBehavior.Restrict);

                        modelBuilder
                            .Entity<Estate>()
                            .HasOne(e => e.Estate_Status_Id)
                            .WithMany(cl => cl.Estates)
                            .HasForeignKey(e => e.EstateStatusId)
                            .OnDelete(DeleteBehavior.Restrict);

            */
            base.OnModelCreating(modelBuilder);
        }
    }
}