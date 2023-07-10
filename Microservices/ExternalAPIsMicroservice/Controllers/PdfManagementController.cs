using ExternalAPIsMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExternalAPIsMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PdfManagementController : ControllerBase
    {
        private readonly PdfManagementService _pdfManagementService;

        public PdfManagementController(PdfManagementService pdfManagementService)
        {
            _pdfManagementService = pdfManagementService;
        }

        [HttpGet]
        public IActionResult Create(string customContent)
        {
            try
            {
                string response = _pdfManagementService.Create(customContent);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync(string customContent)
        {
            try
            {
                string response = await _pdfManagementService.CreateAsync(customContent);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateMerge(string customContent)
        {
            try
            {
                string response = await _pdfManagementService.CreateMerge(customContent);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
