#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Contracts
{
    public class Under_Contract : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public int Estate_Id { get; set; }

        public int Contract_Id { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
