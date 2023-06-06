using ExternalAPIsMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Misc;
using System.Net;

namespace ExternalAPIsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/scraper/
    public class ScraperController : ControllerBase
    {
        private readonly IScraperService _scraperService;

        private readonly ILogger<ScraperController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public ScraperController(
            IScraperService scraper,
            ILogger<ScraperController> logger, 
            IPublishEndpoint publishEndpoint) 
        {
            _scraperService = scraper ?? throw new ArgumentNullException(nameof(scraper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpPost]
        [Route("runScraper")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult<string> RunScraperAndSaveToDB([FromBody] ChargeDataModel model)
        {
            try
            {
                _scraperService.RunScraper();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}