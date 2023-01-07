using Microsoft.AspNetCore.Identity;
using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.Models.Entities.Listings
{
    public class Employee : IdentityUser, IDeletableEntity
    {
        public Employee() : base()
        {
            Listings = new List<Listing>();

            Estates = new List<Estate>();
        }

        public string First_Name { get; init; }

        public string Last_Name { get; init; }

        public Company Company { get; init; }

        public IEnumerable<Listing> Listings { get; set; }

        public IEnumerable<Estate> Estates { get; init; }

        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
