using ExternalAPIsMicroservice.Services.Interfaces;

namespace ExternalAPIsMicroservice.Services
{
    public class ZillowAgentService : IZillowAgentService
    {
        private readonly HttpClient client;

        public ZillowAgentService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "SIGN-UP-FOR-KEY");
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "zillow-com1.p.rapidapi.com");
        }

        public async Task<string> FindAgent(string searchParams)
        {
            string url = $"https://zillow-com1.p.rapidapi.com/findAgent?{searchParams}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetAgentDetails(string username)
        {
            string encodedUsername = Uri.EscapeDataString(username);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/agentDetails?username={encodedUsername}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetAgentReviews(string username)
        {
            string encodedUsername = Uri.EscapeDataString(username);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/agentReviews?username={encodedUsername}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetAgentActiveListings(string username)
        {
            string encodedUsername = Uri.EscapeDataString(username);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/agentActiveListings?username={encodedUsername}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetAgentSoldListings(string username)
        {
            string encodedUsername = Uri.EscapeDataString(username);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/agentSoldListings?username={encodedUsername}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        public async Task<string> GetAgentRentalListings(string username)
        {
            string encodedUsername = Uri.EscapeDataString(username);
            string apiUrl = $"https://zillow-com1.p.rapidapi.com/agentRentalListings?username={encodedUsername}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
