using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Clients
{
    public class Contact : IDeletableEntity
    {
        [Key]
        public string Id { get; init; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; init; }

        public int Employee_Id { get; init; }

        public int Estate_Id { get; init; }

        public DateTime Contact_Time { get; init; }

        public string Contact_Details { get; init; }

        public Client Client { get; init; }
        public string Client_Id { get; init; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUser_Id { get; set; }



        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
