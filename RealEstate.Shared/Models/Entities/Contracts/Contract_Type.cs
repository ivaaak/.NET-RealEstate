using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Contracts
{
    public class Contract_Type : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Contract_Type_Name { get; set; }

        public decimal Fee_Percentage { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
