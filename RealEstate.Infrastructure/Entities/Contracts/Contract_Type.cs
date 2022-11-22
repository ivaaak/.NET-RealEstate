using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Contract_Type
    {
        [Key]
        public int Id { get; set; }

        public string Contract_Type_Name { get; set; }    

        public decimal Fee_Percentage { get; set; }
    }
}
