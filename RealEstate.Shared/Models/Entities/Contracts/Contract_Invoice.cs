#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Contracts
{
    public class Contract_Invoice : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Contract_Invoice_Name { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
