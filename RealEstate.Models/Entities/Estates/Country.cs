using RealEstate.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Estates
{
    public class Country : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public string Country_Name { get; init; }

        public List<City> Cities { get; init; }


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}