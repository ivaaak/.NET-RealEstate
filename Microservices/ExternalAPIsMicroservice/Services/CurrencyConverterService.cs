using RealEstate.Shared;

namespace ExternalAPIsMicroservice.Services
{
    public class CurrencyConverterService
    {
        private const string ApiKey = GlobalConstants.CURRENCY_API_KEY;

        private const string BaseUrl = "https://api.currencyapi.com/v3/historical/historical";

        public async Task<string> GetHistoricalRates(string baseCurrency, string date)
        {
            try
            {
                string url = $"{BaseUrl}?apikey={ApiKey}&base_currency={baseCurrency}&date={date}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in API Call: " + ex.Message);
                throw;
            }
        }
    }
}
