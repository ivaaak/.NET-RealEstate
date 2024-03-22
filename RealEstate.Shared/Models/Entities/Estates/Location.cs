#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Location : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Lat { get; set; }
        public decimal Lan { get; set; }

        // Navigation Property
        public List<Estate> Estates { get; set; }
    }
}