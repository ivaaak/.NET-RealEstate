#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Host : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string PictureUrl { get; set; }
        public long CreateAt { get; set; }
        public bool IsSuperhost { get; set; }
        public int PolicyNumber { get; set; }
        public string ResponseTime { get; set; }


        // Navigation Property
        public List<Estate> Estates { get; set; }
    }
}