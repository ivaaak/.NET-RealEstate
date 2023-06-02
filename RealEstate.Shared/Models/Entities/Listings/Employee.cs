#nullable disable
using Microsoft.AspNetCore.Identity;
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Estates;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Employee : IdentityUser, IDeletableEntity
    {
        public Employee() : base()
        {
            Listings = new List<Listing>();

            Estates = new List<Estate>();
        }

        [Key]
        public string Employee_Id { get; init; }

        public string First_Name { get; init; }

        public string Last_Name { get; init; }

        public Company Company { get; init; }

        public IEnumerable<Listing> Listings { get; set; }

        public IEnumerable<Estate> Estates { get; init; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
