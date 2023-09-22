#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Clients
{
    public class Contact : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; init; }

        public int Employee_Id { get; init; }

        public int Estate_Id { get; init; }

        public DateTime Contact_Time { get; init; }

        public string Contact_Details { get; init; }

        public Client Client { get; init; }
        public string Client_Id { get; init; }
        public string ApplicationUser_Id { get; set; }



        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
