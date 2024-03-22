#nullable disable
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Models.DTOs.Estates
{
    public class EstateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int City_Id { get; set; }
        public City City { get; set; }
        public string Type { get; set; }
        public List<string> ImgUrls { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public int Capacity { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Labels { get; set; }

        public string HostId { get; set; }
        public Host Host { get; set; }

        public int LocId { get; set; }
        public Location Loc { get; set; }

        public List<Review> Reviews { get; set; }
        public List<string> LikedByUsers { get; set; }
        public string RoomType { get; set; }
        public StatReviews StatReviews { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}