#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Estate_Type : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Type_Name { get; init; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}