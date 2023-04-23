#nullable disable
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class ListingStats
    {
        [Key]
        public int ListingStats_Id { get; set; }

        public int TimesViewed { get; set; }

        public int TimesSaved { get; set; }

        public int TimesCommented { get; set; }

        public int TimesReviewed { get; set; }

        public int TimesRented { get; set; }

        public int TimesReported { get; set; }

        public PriceHistory PriceHistory { get; set; }
    }
}
