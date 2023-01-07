using Microsoft.AspNetCore.Identity;
using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Clients;
using RealEstate.Models.Entities.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models.Entities.Listings
{
    public class Agent : IdentityUser, IDeletableEntity
    {
        [ForeignKey("Agent_Id")]
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


        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
