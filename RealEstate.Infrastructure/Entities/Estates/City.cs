using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class City
    {
        [Key]
        public int Id { get; init; }

        public string City_Name { get; init; }
        
        [ForeignKey("Country_Id")]
        public int Country_Id { get; init; }

        public IEnumerable<Estate> Estates { get; init; }
    }
}