using RealEstate.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models.Entities.Listings
{
    public class Review : IDeletableEntity
    {
        [Key]
        public string Review_Id { get; init; }

        public string Review_Title { get; set; }

        public string Review_Content { get; set; }

        public string Review_Rating { get; set; }

        public DateTime Date_Posted { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string ListingId { get; set; }
        public string ReviewId { get; set; }
        public Listing Listing { get; set; }
    }
}
