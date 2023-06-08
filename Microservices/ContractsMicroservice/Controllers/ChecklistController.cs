using ContractsMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Contracts;

namespace ContractsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService _documentService;

        private readonly ILogger<ChecklistController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public ChecklistController(
            IChecklistService documentService,
            ILogger<ChecklistController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }



        [HttpGet]
        public IActionResult GetChecklistsList(int userId)
        {
            try
            {
                var documents = _documentService.GetChecklistsList(userId);
                return Ok(documents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteChecklist(int userId, int documentId)
        {
            try
            {
                // Check if the user has the document
                bool hasChecklist = await _documentService.CheckIfUserHasChecklist(userId, documentId);
                if (!hasChecklist)
                {
                    throw new Exception("The user does not have this document");
                }

                // Delete the document
                // (Implementation details will depend on the specific storage system being used)
                await _documentService.DeleteChecklist(userId, documentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error
                // (Implementation details will depend on the specific logging system being used)

                // Return an error response to the client
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> CheckIfUserHasChecklist(int userId, int documentId)
        {
            try
            {
                bool result = await _documentService.CheckIfUserHasChecklist(userId, documentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult ValidateChecklist(Checklist model)
        {
            try
            {
                _documentService.ValidateModel(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public string GetContentType(string fileName)
        {
            try
            {
                var mimeType = GetContentTypeUtil();
                if (string.IsNullOrEmpty(mimeType))
                {
                    throw new Exception($"Could not determine MIME type for file '{fileName}'");
                }

                return mimeType;
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error getting content type for file '{fileName}': {ex.Message}");
                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        // http://localhost:9002/api/document/gethealth
        // http://localhost:9000/api/document/gethealth behind gateway
        public string getHealth() => "Contracts Microservice up and running";

        static string GetContentTypeUtil()
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }
    }
}
