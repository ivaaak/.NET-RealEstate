#nullable disable
using Microsoft.AspNetCore.Identity;
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Clients
{
    // should inherit ApplicationUser which inherits IdentityUser?
    public class Client : 
        //ApplicationUser, 
        IDeletableEntity
    {
        [Key]
        [ForeignKey("Id")]
        public string Id { get; set; }

        public string Client_Name { get; set; }

        public string Client_Address { get; set; }

        public string Contact_Person { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string EMail { get; set; }

        public string Client_Details { get; set; }

        public DateTime Time_Created { get; init; }

        public Contact Contact { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }

        public List<IdentityRole> Roles { get; set; }
        public List<Estate> Estates { get; set; }
        public List<Listing> Listings { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
