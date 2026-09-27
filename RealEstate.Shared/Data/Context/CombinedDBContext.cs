using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;
using RealEstate.Shared.Models.Entities.Misc;

namespace RealEstate.Shared.Data.Context
{
    // Single application schema shared by all microservices.
    // Keycloak user tables (user_entity, user_attribute, ...) are NOT part of this schema -
    // they live in the Keycloak database and are accessed via ClientsMicroservice's UsersDBContext.
    public class CombinedDBContext : DbContext
    {
        public CombinedDBContext(DbContextOptions<CombinedDBContext> options) : base(options) { }

        // Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Contracts
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract_Invoice> Contract_Invoices { get; set; }
        public DbSet<Contract_Type> Contract_Types { get; set; }
        public DbSet<Payment_Frequency> Payment_Frequencies { get; set; }
        public DbSet<Under_Contract> Under_Contracts { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }

        // Estates
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Estate_Status> Estate_Statuses { get; set; }
        public DbSet<In_Charge> In_Charges { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Listings
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ListingStats> ListingStats { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // Utilities
        public DbSet<FileEntity> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GlobalConnectionStrings.RealEstate_DB_Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            ConfigureClientEntities(modelBuilder);
            ConfigureContractEntities(modelBuilder);
            ConfigureEstateEntities(modelBuilder);
            ConfigureListingEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureClientEntities(ModelBuilder modelBuilder)
        {
            // Roles are managed by Keycloak, not stored in the application schema
            modelBuilder.Entity<Client>().Ignore(c => c.Roles);

            // One-to-one: the Contact row holds the FK to its Client
            modelBuilder
                .Entity<Client>()
                .HasOne(c => c.Contact)
                .WithOne(co => co.Client)
                .HasForeignKey<Contact>(co => co.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureContractEntities(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Contracts)
                .HasForeignKey(c => c.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureEstateEntities(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Estate>()
                .HasOne(e => e.City)
                .WithMany(c => c.Estates)
                .HasForeignKey(e => e.City_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.Country_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Category>()
                .HasOne(c => c.Estate)
                .WithMany()
                .HasForeignKey(c => c.Estate_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureListingEntities(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Listing>()
                .HasOne(l => l.PriceHistory)
                .WithOne(ph => ph.Listing)
                .HasForeignKey<PriceHistory>(ph => ph.Listing_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Listing>()
                .HasOne(l => l.Category)
                .WithMany()
                .HasForeignKey(l => l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Listing>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.Listings)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.Company_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
