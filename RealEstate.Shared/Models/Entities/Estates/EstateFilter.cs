#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class EstateFilter : IDeletableEntity
    {
        public string LikeByUser { get; set; }
        public string Place { get; set; }
        public string Label { get; set; }
        public string HostId { get; set; }
        public string IsPetAllowed { get; set; }
    }
}