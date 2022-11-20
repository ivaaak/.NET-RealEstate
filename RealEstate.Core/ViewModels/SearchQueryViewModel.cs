using RealEstate.Infrastructure.Entities;
using Property = RealEstate.Infrastructure.Entities.Property;

namespace RealEstate.Core.ViewModels
{
    public class SearchQueryViewModel
    {
        public string? SearchQuery { get; set; }

        public IEnumerable<Agent>? People { get; set; }

        public IEnumerable<Property>? Properties { get; set; }

        public IEnumerable<Listing>? Listings { get; set; }
    }
}