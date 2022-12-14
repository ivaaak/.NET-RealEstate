using RealEstate.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Estates
{
    public class In_Charge : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public int Estate_Id { get; init; }

        public int Employee_Id { get; init; }

        public DateTime Date_From { get; init; }

        public DateTime Date_To { get; init; }


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}