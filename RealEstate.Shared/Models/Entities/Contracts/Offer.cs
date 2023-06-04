#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Clients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Contracts
{
    public class Offer : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Text_Content { get; set; }

        public bool IsPublic { get; set; }

        public bool IsCompleted { get; set; }

        [ForeignKey("Client_Id")]
        public string Client_Id { get; set; }

        public Client Client { get; set; }

        public string Employee_Id { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int Transaction_Id { get; set; }

        // Checklist Item

        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
