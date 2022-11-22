using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Payment_Frequency
    {
        [Key]
        public int Id { get; set; }

        public string Payment_Frequency_Name { get; set; }
    }
}
