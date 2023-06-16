using ExternalAPIsMicroservice.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExternalAPIsMicroservice.Controllers
{
    [ApiController]
    [Route("api/zillow")]
    public class ZillowApiController : ControllerBase
    {
        private readonly ZillowApiService _zillowService;

        private readonly IPublishEndpoint _publishEndpoint;

        private readonly ILogger<ZillowApiController> _logger;

        public ZillowApiController(
            ZillowApiService zillowService, 
            IPublishEndpoint publishEndpoint,
            ILogger<ZillowApiController> logger)
        {
            _zillowService = zillowService ?? throw new ArgumentNullException(nameof(zillowService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("property")]
        public async Task<IActionResult> GetProperty(string zpid)
        {
            try
            {
                var result = await _zillowService.GetProperty(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("images")]
        public async Task<IActionResult> GetPropertyImages(string zpid)
        {
            try
            {
                var result = await _zillowService.GetPropertyImages(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("propertyExtendedSearch")]
        public async Task<IActionResult> GetExtendedSearch(string searchParams)
        {
            try
            {
                var result = await _zillowService.GetExtendedSearch(searchParams);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("priceAndTaxHistory")]
        public async Task<IActionResult> GetPriceAndTaxHistory(string zpid)
        {
            try
            {
                var result = await _zillowService.GetPriceAndTaxHistory(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("searchByUrl")]
        public async Task<IActionResult> SearchByUrl(string url)
        {
            try
            {
                var result = await _zillowService.SearchByUrl(url);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("propertyComps")]
        public async Task<IActionResult> GetPropertyComps(string zpid)
        {
            try
            {
                var result = await _zillowService.GetPropertyComps(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("propertyByCoordinates")]
        public async Task<IActionResult> GetPropertyByCoordinates(string lat, string lon)
        {
            try
            {
                var result = await _zillowService.GetPropertyByCoordinates(lat, lon);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("propertyByMls")]
        public async Task<IActionResult> GetPropertyByMls(string mlsNumber)
        {
            try
            {
                var result = await _zillowService.GetPropertyByMls(mlsNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("locationSuggestions")]
        public async Task<IActionResult> GetLocationSuggestions(string query)
        {
            try
            {
                var result = await _zillowService.GetLocationSuggestions(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("rentEstimate")]
        public async Task<IActionResult> GetRentEstimate(string zpid)
        {
            try
            {
                var result = await _zillowService.GetRentEstimate(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("walkAndTransitScore")]
        public async Task<IActionResult> GetWalkAndTransitScore(string lat, string lon)
        {
            try
            {
                var result = await _zillowService.GetWalkAndTransitScore(lat, lon);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("building")]
        public async Task<IActionResult> GetBuilding(string buildingId)
        {
            try
            {
                var result = await _zillowService.GetBuilding(buildingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("zestimateHistory")]
        public async Task<IActionResult> GetZestimateHistory(string zpid)
        {
            try
            {
                var result = await _zillowService.GetZestimateHistory(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            try
            {
                var result = await _zillowService.Ping();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("buildWebUrl")]
        public async Task<IActionResult> BuildWebUrl(string zpid)
        {
            try
            {
                var result = await _zillowService.BuildWebUrl(zpid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
