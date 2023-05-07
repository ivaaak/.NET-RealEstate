#nullable disable
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Address
    {
        [Key]
        public string Address_Id { get; set; }

        public string City { get; set; }

        public string Neighbourhood { get; set; }

        public string Street { get; set; }

        public int? PostalCode { get; set; }

        // x, y coords - to use in geolocation?
        public string MapCoordinates { get; set; }
    }
}
