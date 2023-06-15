using ExternalAPIsMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExternalAPIsMicroservice.Controllers
{
    [ApiController]
    [Route("api/zillow/agent")]
    public class ZillowAgentController : ControllerBase
    {
        private readonly ZillowAgentService agentService;

        public ZillowAgentController(ZillowAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet("findAgent")]
        public async Task<IActionResult> FindAgent(string searchParams)
        {
            try
            {
                var result = await agentService.FindAgent(searchParams);
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
                var result = await agentService.GetAgentDetails(username);
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
                var result = await agentService.GetAgentReviews(username);
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
                var result = await agentService.GetAgentActiveListings(username);
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
                var result = await agentService.GetAgentSoldListings(username);
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
                var result = await agentService.GetAgentRentalListings(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
