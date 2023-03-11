using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Models.DTOs.Search
{
    public class SearchDTO
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Client>? Clients { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

        public IEnumerable<Estate>? Estates { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}