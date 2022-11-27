using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data.Identity;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Contracts;

namespace RealEstate.Infrastructure.Context
{
    public class ContractsDBContext : IdentityDbContext<ApplicationUser>
    {
        public ContractsDBContext(DbContextOptions<ContractsDBContext> options)
            : base(options) {}

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Contract_Invoice> Contract_Invoices { get; set; }

        public DbSet<Contract_Type> Contract_Type { get; set; }

        public DbSet<Payment_Frequency> Payment_Frequencies { get; set; }

        public DbSet<Under_Contract> Under_Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract_Invoice>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Contract_Type>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Payment_Frequency>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Under_Contract>().HasIndex(ci => ci.Id).IsUnique();

            modelBuilder
                .Entity<Contract>()
                .HasOne(cl => cl.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(cl => cl.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);

            //TODO add more relations
            /*
            modelBuilder
               .Entity<Client>()
               .HasOne(c => c.Contracts)
               .WithMany(cl => cl.)
               .HasForeignKey<Contact>(cl => cl.Contact_Details)
               .OnDelete(DeleteBehavior.Restrict);
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}