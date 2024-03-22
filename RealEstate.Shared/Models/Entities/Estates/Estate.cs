#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using RealEstate.Shared.Models.Entities.Listings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class Estate : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("City_Id")]
        public string City_Id { get; set; }
        public City City { get; set; }
        public DateTime YearBuilt { get; set; }
        public string Type { get; set; }
        public List<string> ImgUrls { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public int Capacity { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Labels { get; set; }
      
        // Foreign Key
        public string HostId { get; set; }
        [ForeignKey("HostId")]
        public Host Host { get; set; }

        // Foreign Key
        public int LocId { get; set; }
        [ForeignKey("LocId")]
        public Location Loc { get; set; }

        public List<Review> Reviews { get; set; }
        public List<string> LikedByUsers { get; set; }
        public string RoomType { get; set; }
        public StatReviews StatReviews { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Balconies { get; set; }
        public int Garages { get; set; }
        public int Floor_Space_Square_Meters { get; set; }

        public bool Pets_Allowed { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
