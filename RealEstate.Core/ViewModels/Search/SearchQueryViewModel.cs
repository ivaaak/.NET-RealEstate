using RealEstate.Infrastructure.Entities.Clients;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Core.ViewModels.Search
{
    public class SearchQueryViewModel
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Client>? Clients { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

        public IEnumerable<Estate>? Estates { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}