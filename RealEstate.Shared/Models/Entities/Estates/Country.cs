#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Country : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Country_Name { get; init; }

        public List<City> Cities { get; init; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}