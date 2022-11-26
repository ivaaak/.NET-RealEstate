using Microsoft.AspNetCore.Identity;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.Infrastructure.Entities.Listings
{
    public class Company : IdentityUser
    {
        public string Company_Name { get; init; }

        public string Company_Description { get; init; }

        public int Employee_Count { get; init; }

        public IEnumerable<Employee> Employees { get; init; }

        public IEnumerable<Listing> Listings { get; set; }

        public IEnumerable<Estate> Estates { get; init; }

        public Company() : base()
        {
            Listings = new List<Listing>();

            Estates = new List<Estate>();

            Employees = new List<Employee>();
        }
    }
}
