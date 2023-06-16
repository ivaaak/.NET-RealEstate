using ExternalAPIsMicroservice.Services.Interfaces;

namespace ExternalAPIsMicroservice.Services
{
    public class ZillowSimilarListingsService : IZillowSimilarListingsService
    {
        private readonly HttpClient client;

        public ZillowSimilarListingsService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "SIGN-UP-FOR-KEY");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "zillow-com1.p.rapidapi.com");
        }

        public async Task<string> GetSimilarProperties(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/similarProperty?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetSimilarSales(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/similarSales?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetSimilarForRent(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/similarForRent?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
