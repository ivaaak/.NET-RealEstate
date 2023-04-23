#nullable disable
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Agency
    {
        [Key]
        public string Agency_Id { get; set; }
        public string Name { get; init; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public string Website { get; set; }

        public string Phone_Number { get; set; }

        public string Address { get; set; }

        public List<Agent> Agents { get; set; }

        public List<Listing> Listings { get; set; }

    }
}
