using ExternalAPIsMicroservice.Services.Interfaces;

namespace ExternalAPIsMicroservice.Services
{
    // https://rapidapi.com/apimaker/api/zillow-com1/
    public class ZillowApiService : IZillowApiService
    {
        private readonly HttpClient client;

        public ZillowApiService(string ZillowApiKey)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", ZillowApiKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "zillow-com1.p.rapidapi.com");
        }

        public async Task<string> GetProperty(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/property?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetPropertyImages(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/images?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetExtendedSearch(string searchParams)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/propertyExtendedSearch?{searchParams}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetPriceAndTaxHistory(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/priceAndTaxHistory?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> SearchByUrl(string url)
        {
            string encodedUrl = Uri.EscapeDataString(url);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/searchByUrl?url={encodedUrl}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetPropertyComps(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/propertyComps?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetPropertyByCoordinates(string lat, string lon)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/propertyByCoordinates?latitude={lat}&longitude={lon}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetPropertyByMls(string mlsNumber)
        {
            string encodedMlsNumber = Uri.EscapeDataString(mlsNumber);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/propertyByMls?mls={encodedMlsNumber}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetLocationSuggestions(string query)
        {
            string encodedQuery = Uri.EscapeDataString(query);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/locationSuggestions?query={encodedQuery}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetRentEstimate(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/rentEstimate?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetWalkAndTransitScore(string lat, string lon)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/walkAndTransitScore?latitude={lat}&longitude={lon}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetBuilding(string buildingId)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/building?buildingId={buildingId}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetZestimateHistory(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/zestimateHistory?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> Ping()
        {
            string url = "https://zillow-com1.p.rapidapi.com/ping";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> BuildWebUrl(string zpid)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/buildWebUrl?zpid={zpid}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
