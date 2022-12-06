using RealEstate.Infrastructure.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Contract_Invoice : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Contract_Invoice_Name { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
