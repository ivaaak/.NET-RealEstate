#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Misc
{
    public class EstateFilter
    {
        public string LikeByUser { get; set; }
        public string Place { get; set; }
        public string Label { get; set; }
        public string HostId { get; set; }
        public string City_Id { get; set; }
        public bool Pets_Allowed { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Balconies { get; set; }
        public int Garages { get; set; }
        public int Floor_Space_Square_Meters { get; set; }
    }
}