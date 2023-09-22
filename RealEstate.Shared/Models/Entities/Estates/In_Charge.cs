#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class In_Charge : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public int Estate_Id { get; init; }

        public int Employee_Id { get; init; }

        public DateTime Date_From { get; init; }

        public DateTime Date_To { get; init; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}