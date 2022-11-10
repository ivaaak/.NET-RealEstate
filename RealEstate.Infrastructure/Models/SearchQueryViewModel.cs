using RealEstate.Infrastructure.Data;
using Property = RealEstate.Infrastructure.Data.Property;

namespace RealEstate.Infrastructure.Models
{
    public class SearchQueryViewModel
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Agent>? People { get; set; }

        public IEnumerable<Property>? Properties { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}