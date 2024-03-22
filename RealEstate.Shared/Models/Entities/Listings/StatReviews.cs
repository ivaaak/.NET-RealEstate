#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class StatReviews : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }
        public decimal Cleanliness { get; set; }
        public decimal Communication { get; set; }
        public decimal CheckIn { get; set; }
        public decimal Accuracy { get; set; }
        public decimal Location { get; set; }
        public decimal Value { get; set; }

    }
}
