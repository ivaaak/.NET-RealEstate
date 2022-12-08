using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Contracts;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<Contact> Contacts { get; set; }

        DbSet<Contract> Contracts { get; set; }

        DbSet<Contract_Invoice> Contract_Invoices { get; set; }

        DbSet<Contract_Type> Contract_Types { get; set; }

        DbSet<Payment_Frequency> Payment_Frequencies { get; set; }

        DbSet<Under_Contract> Under_Contracts { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<City> Cities { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<Estate> Estates { get; set; }

        DbSet<Estate_Status> Estate_Statuses { get; set; }

        DbSet<Estate_Type> Estate_Types { get; set; }

        DbSet<In_Charge> In_Charge { get; set; }

        DbSet<Company> Companies { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Listing> Listings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task AddRangeAsync(params object[] entities);

        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}
