using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Contracts
{
    public class Under_Contract
    {
        [Key]
        public int Id { get; set; }

        public int Estate_Id { get; set; }

        public int Contract_Id { get; set; }
    }
}
