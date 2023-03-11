using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Identity;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Data.Context
{

    public class _CombinedContext : IdentityDbContext<ApplicationUser>
    {
        public _CombinedContext(DbContextOptions<_CombinedContext> options)
            : base(options) { }


        // Identity Users
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Contracts
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contract_Invoice> Contract_Invoices { get; set; }
        public DbSet<Contract_Type> Contract_Type { get; set; }
        public DbSet<Payment_Frequency> Payment_Frequencies { get; set; }
        public DbSet<Under_Contract> Under_Contracts { get; set; }

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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    // Comment this class out when creating migrations or updating db so nothing is generated twice
}