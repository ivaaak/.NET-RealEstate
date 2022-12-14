using Microsoft.AspNet.Identity.EntityFramework;
using RealEstate.Models.Entities.BaseEntityModel;
using RealEstate.Models.Entities.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models.Entities.Clients
{
    public class Client : IdentityUser, IDeletableEntity
    {
        [ForeignKey("Client_Id")]
        public string Client_Id { get; init; }

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


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
