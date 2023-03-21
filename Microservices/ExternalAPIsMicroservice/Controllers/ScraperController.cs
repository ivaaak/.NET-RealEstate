using ExternalAPIsMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Misc;

namespace ExternalAPIsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/payments/
    public class ScraperController
    {
        private readonly IScraperService scraper;

        public ScraperController(IScraperService scraper) 
        {
            this.scraper = scraper;
        }

        [HttpPost]
        [Route("runScraper")]
        public string RunScraperAndSaveToDB([FromBody] ChargeDataModel model)
        {
            try
            {
                scraper.RunScraper();
                return "Completed!";
            }
            catch (Exception ex)
            {
                return "Error while running scraper: ";
            }
        }
    }
}