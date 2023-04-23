#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Listings
{
    public class PriceHistory
    {
        public string Id { get; set; }
        // price changes saved as a touple of the date and price
        [NotMapped]
        public Dictionary<DateTime, double> PriceHistoryTouples { get; set; }

        // <date - price of rent>
        [NotMapped]
        public Dictionary<DateTime, double> RentHistoryTouples { get; set; }

        // <date - number of listings>
        [NotMapped]
        public Dictionary<DateTime, int> OffersHistoryTouples { get; set; }

        // <date - number of searches>
        [NotMapped]
        public Dictionary<DateTime, int> SearchesHistoryTouples { get; set; }

        // <date - number of times viewed>
        [NotMapped]
        public Dictionary<DateTime, int> ViewsHistoryTouples { get; set; }

        [ForeignKey(nameof(Listing_Id))]
        public Listing Listing { get; set; }
        public string Listing_Id { get; set; }

    }
}
