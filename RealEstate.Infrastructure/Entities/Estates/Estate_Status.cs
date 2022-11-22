using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class Estate_Status
    {
        [Key]
        public int Id { get; init; }

        public string Estate_Status_Name { get; init; }
    }
}