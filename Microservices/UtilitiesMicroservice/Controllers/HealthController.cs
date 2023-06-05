using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace UtilitiesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("/health")]
    public class HealthController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;
        public HealthController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        /// <summary>
        ///     Get Health
        /// </summary>
        /// <remarks>Provides an indication about the health of the API</remarks>
        /// <response code="200">API is healthy</response>
        /// <response code="503">API is unhealthy or in degraded state</response>
        [HttpGet]
        [ProducesResponseType(typeof(HealthReport), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = "Health_Get")]
        public async Task<IActionResult> Get()
        {
            var report = await _healthCheckService.CheckHealthAsync();

            return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
        }
    }
}
