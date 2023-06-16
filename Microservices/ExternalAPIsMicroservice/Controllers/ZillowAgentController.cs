using ExternalAPIsMicroservice.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExternalAPIsMicroservice.Controllers
{
    [ApiController]
    [Route("api/zillow/agent")]
    public class ZillowAgentController : ControllerBase
    {
        private readonly ZillowAgentService _agentService;

        private readonly IPublishEndpoint _publishEndpoint;

        private readonly ILogger<ZillowAgentController> _logger;

        public ZillowAgentController(
             ZillowAgentService agentService,
            IPublishEndpoint publishEndpoint,
            ILogger<ZillowAgentController> logger)
        {
            _agentService = agentService ?? throw new ArgumentNullException(nameof(agentService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ZillowAgentController(ZillowAgentService agentService)
        {
            this._agentService = agentService;
        }

        [HttpGet("findAgent")]
        public async Task<IActionResult> FindAgent(string searchParams)
        {
            try
            {
                var result = await _agentService.FindAgent(searchParams);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("agentDetails")]
        public async Task<IActionResult> GetAgentDetails(string username)
        {
            try
            {
                var result = await _agentService.GetAgentDetails(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("agentReviews")]
        public async Task<IActionResult> GetAgentReviews(string username)
        {
            try
            {
                var result = await _agentService.GetAgentReviews(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("agentActiveListings")]
        public async Task<IActionResult> GetAgentActiveListings(string username)
        {
            try
            {
                var result = await _agentService.GetAgentActiveListings(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("agentSoldListings")]
        public async Task<IActionResult> GetAgentSoldListings(string username)
        {
            try
            {
                var result = await _agentService.GetAgentSoldListings(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("agentRentalListings")]
        public async Task<IActionResult> GetAgentRentalListings(string username)
        {
            try
            {
                var result = await _agentService.GetAgentRentalListings(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
