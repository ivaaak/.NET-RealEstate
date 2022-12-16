using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;

namespace RealEstate.Models.ViewModels.Search
{
    public class SearchViewModel
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Client>? Clients { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

        public IEnumerable<Estate>? Estates { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}