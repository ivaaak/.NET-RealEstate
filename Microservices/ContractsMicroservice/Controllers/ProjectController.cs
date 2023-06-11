using ContractsMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Misc;

namespace ContractsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _documentService;

        private readonly ILogger<ProjectController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public ProjectController(
            IProjectService documentService,
            ILogger<ProjectController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        [HttpPost]
        public IActionResult UploadProject(int userId, Project model)
        {
            try
            {
                _documentService.ValidateModel(model);
                _documentService.UploadProject(userId, model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                // Log the error
                // Return a BadRequest response with a validation error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the error
                // Return a 500 Internal Server Error response
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetProjectsList(int userId)
        {
            try
            {
                var documents = _documentService.GetProjectsList(userId);
                return Ok(documents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("/{userId}/{documentId}")]
        public async Task<IActionResult> DownloadProject(int userId, int documentId)
        {
            // Check if the user has the document
            if (!await _documentService.CheckIfUserHasProject(userId, documentId))
            {
                // Return a "not found" error if the user doesn't have the document
                return NotFound();
            }

            try
            {
                // Download the document
                await _documentService.DownloadProject(Response, userId, documentId);
            }
            catch (Exception ex)
            {
                // Return an "internal server error" if something goes wrong during the download
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int userId, int documentId)
        {
            try
            {
                // Check if the user has the document
                bool hasProject = await _documentService.CheckIfUserHasProject(userId, documentId);
                if (!hasProject)
                {
                    throw new Exception("The user does not have this document");
                }

                // Delete the document
                // (Implementation details will depend on the specific storage system being used)
                await _documentService.DeleteProject(userId, documentId);
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
        public async Task<IActionResult> CheckIfUserHasProject(int userId, int documentId)
        {
            try
            {
                bool result = await _documentService.CheckIfUserHasProject(userId, documentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult ValidateProject(Project model)
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
