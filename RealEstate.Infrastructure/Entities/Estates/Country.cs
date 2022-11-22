using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class Country
    {
        [Key]
        public int Id { get; init; }

        public string Country_Name { get; init; }
    }
}