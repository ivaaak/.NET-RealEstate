using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class Estate_Type
    {
        [Key]
        public int Id { get; init; }

        public string Type_Name { get; init; }
    }
}