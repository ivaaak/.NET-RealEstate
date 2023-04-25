using ContractsMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Misc;

namespace UtilitiesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        private readonly ILogger<DocumentController> _logger;

        public DocumentController(
            IDocumentService documentService,
            ILogger<DocumentController> logger)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }


        [HttpPost]
        [Route("api/[controller]/upload")]
        public IActionResult UploadDocument(int userId, DocumentModel model)
        {
            try
            {
                _documentService.ValidateModel(model);
                _documentService.UploadDocument(userId, model);
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
        [Route("api/[controller]/getdocuments")]
        public IActionResult GetDocumentsList(int userId)
        {
            try
            {
                var documents = _documentService.GetDocumentsList(userId);
                return Ok(documents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("api/[controller]/download/{userId}/{documentId}")]
        public async Task<IActionResult> DownloadDocument(int userId, int documentId)
        {
            // Check if the user has the document
            if (!await _documentService.CheckIfUserHasDocument(userId, documentId))
            {
                // Return a "not found" error if the user doesn't have the document
                return NotFound();
            }

            try
            {
                // Download the document
                await _documentService.DownloadDocument(Response, userId, documentId);
            }
            catch (Exception ex)
            {
                // Return an "internal server error" if something goes wrong during the download
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok();
        }


        public async Task<IActionResult> DeleteDocument(int userId, int documentId)
        {
            try
            {
                // Check if the user has the document
                bool hasDocument = await _documentService.CheckIfUserHasDocument(userId, documentId);
                if (!hasDocument)
                {
                    throw new Exception("The user does not have this document");
                }

                // Delete the document
                // (Implementation details will depend on the specific storage system being used)
                await _documentService.DeleteDocument(userId, documentId);
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
        [Route("api/[controller]/checkdocument")]
        public async Task<IActionResult> CheckIfUserHasDocument(int userId, int documentId)
        {
            try
            {
                bool result = await _documentService.CheckIfUserHasDocument(userId, documentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("api/[controller]/validatemodel")]
        public IActionResult ValidateModel(DocumentModel model)
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
                var mimeType = GetContentTypeUtil(Path.GetExtension(fileName));
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

        static string GetContentTypeUtil(string fileName)
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }
    }
}
