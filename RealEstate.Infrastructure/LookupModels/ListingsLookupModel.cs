using RealEstate.Infrastructure.Mapping;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.Entities.Listings;

namespace RealEstate.Infrastructure.LookupModels
{
    public class ListingsLookupModel : IMapFrom<Listing>
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public Estate Estate { get; set; }

        public int Price { get; set; }

        public double PricePerSquareMeter { get; set; }
    }
}
