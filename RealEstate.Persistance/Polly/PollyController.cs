using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Persistance.Polly
{
    public class PollyController : ControllerBase
    {
        private readonly Policies policies;

        public PollyController(Policies policies)
        {
            this.policies = policies;
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var client = new HttpClient();
            var response = await policies.AllPolicies.ExecuteAsync(() => client.GetAsync("http://example.com/data"));

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
        */
    }
}
