using Microsoft.AspNetCore.Identity;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.Infrastructure.Entities.Listings
{
    public class Employee : IdentityUser
    {
        public string First_Name { get; init; }

        public string Last_Name { get; init; }

        public IEnumerable<Listing> Listings { get; set; }

        public IEnumerable<Estate> Estates { get; init; }

        public Employee() : base()
        {
            Listings = new List<Listing>();

            Estates = new List<Estate>();
        }
    }
}
