using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Data.Context
{
    public class ContractsDBContext : DbContext
    {
        public ContractsDBContext(DbContextOptions<ContractsDBContext> options)
            : base(options) { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
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

            modelBuilder.Entity<Client>()
                .HasOne(cl => cl.Contact)
                .WithOne(c => c.Client)
                .HasForeignKey<Contact>(c => c.Client_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}