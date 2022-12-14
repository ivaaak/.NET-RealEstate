using Microsoft.AspNet.Identity.EntityFramework;
using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.Models.Entities.Listings
{
    public class Company : IdentityUser, IDeletableEntity
    {
        public Company() : base()
        {
            Listings = new List<Listing>();

            Estates = new List<Estate>();

            Employees = new List<Employee>();
        }

        public string Company_Name { get; init; }

        public string Company_Description { get; init; }

        public int Employee_Count { get; init; }

        public IEnumerable<Employee> Employees { get; init; }

        public IEnumerable<Listing> Listings { get; set; }

        public IEnumerable<Estate> Estates { get; init; }


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
