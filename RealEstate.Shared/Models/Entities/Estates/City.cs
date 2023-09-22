#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class City : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string City_Name { get; init; }

        [ForeignKey("Country_Id")]
        public int Country_Id { get; init; }
        public Country Country { get; init; }

        public IEnumerable<Estate> Estates { get; init; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}