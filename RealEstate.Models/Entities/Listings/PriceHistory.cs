namespace RealEstate.Models.Entities.Listings
{
    public class PriceHistory
    {
        // price changes saved as a touple of the date and price
        public Dictionary<DateTime, double> PriceHistoryTouples { get; set; }

        // <date - price of rent>
        public Dictionary<DateTime, double> RentHistoryTouples { get; set; }

        // <date - number of listings>
        public Dictionary<DateTime, int> OffersHistoryTouples { get; set; }

        // <date - number of searches>
        public Dictionary<DateTime, int> SearchesHistoryTouples { get; set; }
        
        // <date - number of times viewed>
        public Dictionary<DateTime, int> ViewsHistoryTouples { get; set; }
    }
}
