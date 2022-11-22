using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class City
    {
        [Key]
        public int Id { get; init; }

        public string City_Name { get; init; }

        public int Country_Id { get; init; }
    }
}