#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Host : IDeletableEntity
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}