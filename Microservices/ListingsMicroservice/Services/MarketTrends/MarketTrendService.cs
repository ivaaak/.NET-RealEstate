using EstatesMicroservice.Services;

namespace ListingsMicroservice.Services.MarketTrends
{
    public class MarketTrendService : IMarketTrendService
    {
        private readonly EstateService estateService;

        public MarketTrendService(
            EstateService _estateService)
        {
            estateService = _estateService;
        }

        public decimal GetAveragePrice()
        {
            // retrieve the list of estates from the database
            var estates = estateService.GetEstates().Result.ToList();

            // calculate the sum of the prices
            decimal sum = 0;
            foreach (var estate in estates)
            {
                sum += estate.Listing.Price;
            }

            // calculate the average price
            decimal average = sum / (decimal)estates.Count;

            return average;
        }

        public double GetAveragePricePerSquareMeter()
        {
            // retrieve the list of estates from the database
            var estates = estateService.GetEstates().Result.ToList();

            // calculate the sum of the prices
            double sum = 0;
            foreach (var estate in estates)
            {
                sum += estate.Listing.PricePerSquareMeter;
            }

            // calculate the average price
            double average = sum / (double)estates.Count;

            return average;
        }
    }
}
