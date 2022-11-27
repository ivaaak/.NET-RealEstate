using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Contract_Invoice
    {
        [Key]
        public int Id { get; set; }

        public string Contract_Invoice_Name { get; set; }
    }
}
