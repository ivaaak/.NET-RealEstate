#nullable disable
using Microsoft.AspNetCore.Identity;
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Agent : IdentityUser, IDeletableEntity
    {
        [Key]
        public string Agent_Id { get; init; }

        public string Agent_Name { get; set; }

        public string Agent_Address { get; set; }

        public string Contact_Person { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string EMail { get; set; }

        public string Agent_Details { get; set; }

        public DateTime Time_Created { get; init; }

        public Contact Contact { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }

        public Agency Agency { get; set; }
        public List<Listing> Listings { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
