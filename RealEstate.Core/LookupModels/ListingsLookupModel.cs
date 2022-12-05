using RealEstate.Core.Mapping;
using RealEstate.Infrastructure.Entities.Estates;
using RealEstate.Infrastructure.Entities.Listings;

namespace RealEstate.Core.LookupModels
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
