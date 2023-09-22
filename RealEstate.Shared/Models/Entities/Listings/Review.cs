#nullable disable
using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class Review : IDeletableEntity
    {
        [Key]
        public string Id { get; set; }

        public string Review_Title { get; set; }

        public string Review_Content { get; set; }

        public string Review_Rating { get; set; }

        public DateTime Date_Posted { get; set; }


        public string Listing_Id { get; set; }
        public Listing Listing { get; set; }


        // IDeletableEntity
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
