using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Core.ViewModels
{
    public class SearchQueryViewModel
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Employee>? People { get; set; }

        public IEnumerable<Estate>? Properties { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}