#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class ReviewBy : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string ImgUrl { get; set; }
    }
}