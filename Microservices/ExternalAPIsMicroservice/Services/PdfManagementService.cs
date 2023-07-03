using RealEstate.Shared;
using System.Text;

namespace ExternalAPIsMicroservice.Services
{
    public class PdfManagementService
    {
        private const string ApiKey = GlobalConstants.CRAFTMYPDF_API_KEY;
        private const string BaseUrl = "https://craftmypdf-pdf-generation.p.rapidapi.com";
        private readonly HttpClient client = new HttpClient();

        private Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>
            {
                { "X-API-KEY", "<REQUIRED>" },
                { "X-RapidAPI-Key", ApiKey },
                { "X-RapidAPI-Host", "craftmypdf-pdf-generation.p.rapidapi.com" }
            };
        }

        public async Task<string> CreateMerge(string customContent)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "/create-merge");
                var headers = GetHeaders();

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                request.Content = new StringContent(customContent, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return body;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in API Call: " + ex.Message);
                throw;
            }
        }

        public string Create(string customContent)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "/create");
                var headers = GetHeaders();

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                request.Content = new StringContent(customContent, Encoding.UTF8, "application/json");

                var response = client.Send(request);
                response.EnsureSuccessStatusCode();

                var body = response.Content.ToString();
                Console.WriteLine(body);
                return body;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in API Call: " + ex.Message);
                throw;
            }
        }

        public async Task<string> CreateAsync(string customContent)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl + "/create-async");
                var headers = GetHeaders();

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                request.Content = new StringContent(customContent, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return body;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in API Call: " + ex.Message);
                throw;
            }
        }
    }
}
