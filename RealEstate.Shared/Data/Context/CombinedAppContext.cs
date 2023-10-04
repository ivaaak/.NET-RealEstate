using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Data.Context
{

    public class CombinedAppContext : DbContext //: IdentityDbContext<ApplicationUser>
    {
        public CombinedAppContext(DbContextOptions<CombinedAppContext> options)
            : base(options) { }
        public CombinedAppContext() { }

        // Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Contracts
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contract_Invoice> Contract_Invoices { get; set; }
        public DbSet<Contract_Type> Contract_Type { get; set; }
        public DbSet<Payment_Frequency> Payment_Frequencies { get; set; }
        public DbSet<Under_Contract> Under_Contracts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Checklist> Checklists { get; set; }

        // Estates
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Estate_Status> Estate_Statuses { get; set; }
        public DbSet<Estate_Type> Estate_Types { get; set; }
        public DbSet<In_Charge> In_Charges { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Listings
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
            modelBuilder.Entity<Contact>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract_Invoice>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Contract_Type>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Payment_Frequency>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Under_Contract>().HasIndex(ci => ci.Id).IsUnique();

            modelBuilder
                .Entity<Contact>()
                .HasOne(cl => cl.Client)
                .WithOne(c => c.Contact)
                .HasForeignKey<Client>(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Client>()
                .HasOne(c => c.Contact)
                .WithOne(cl => cl.Client)
                .HasForeignKey<Contact>(cl => cl.Contact_Details)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<PriceHistory>()
                .Ignore(ph => ph.OffersHistoryTouples);

            modelBuilder
                .Entity<Listing>()
                .HasOne(c => c.Estate)
                .WithOne(cl => cl.Listing)
                .HasForeignKey<Estate>(cl => cl.Listing_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Listing>()
                .HasOne(c => c.PriceHistory)
                .WithOne(cl => cl.Listing)
                .HasForeignKey<PriceHistory>(cl => cl.Listing_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Employee>()
                .HasOne(cl => cl.Company)
                .WithMany(cl => cl.Employees)
                .HasForeignKey(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
    // Comment this class out when creating migrations or updating db so nothing is generated twice
}