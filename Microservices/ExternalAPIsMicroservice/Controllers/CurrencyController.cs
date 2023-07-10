using ExternalAPIsMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalAPIsMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyConverterService _currencyConverter;

        public CurrencyController(CurrencyConverterService currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalRates(string baseCurrency, string date)
        {
            try
            {
                string response = await _currencyConverter.GetHistoricalRates(baseCurrency, date);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
