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
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        private readonly ILogger<OfferController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public OfferController(
            IOfferService offerService,
            ILogger<OfferController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        [HttpPost]
        public IActionResult UploadOffer(int userId, Offer model)
        {
            try
            {
                _offerService.ValidateModel(model);
                _offerService.UploadOffer(userId, model);
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
        public IActionResult GetOffersList(int userId)
        {
            try
            {
                var offers = _offerService.GetOffersList(userId);
                return Ok(offers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("DownloadOffer/{userId}/{offerId}")]
        public async Task<IActionResult> DownloadOffer(int userId, int offerId)
        {
            // Check if the user has the offer
            if (!await _offerService.CheckIfUserHasOffer(userId, offerId))
            {
                // Return a "not found" error if the user doesn't have the offer
                return NotFound();
            }

            try
            {
                // Download the offer
                await _offerService.DownloadOffer(Response, userId, offerId);
            }
            catch (Exception ex)
            {
                // Return an "internal server error" if something goes wrong during the download
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOffer(int userId, int offerId)
        {
            try
            {
                // Check if the user has the offer
                bool hasOffer = await _offerService.CheckIfUserHasOffer(userId, offerId);
                if (!hasOffer)
                {
                    throw new Exception("The user does not have this offer");
                }

                // Delete the offer
                // (Implementation details will depend on the specific storage system being used)
                await _offerService.DeleteOffer(userId, offerId);
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
        public async Task<IActionResult> CheckIfUserHasOffer(int userId, int offerId)
        {
            try
            {
                bool result = await _offerService.CheckIfUserHasOffer(userId, offerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public IActionResult ValidateOffer(Offer model)
        {
            try
            {
                _offerService.ValidateModel(model);
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
        // http://localhost:9002/api/offer/gethealth
        // http://localhost:9000/api/offer/gethealth behind gateway
        public string getHealth() => "Contracts Microservice up and running";

        static string GetContentTypeUtil()
        {
            return System.Net.Mime.MediaTypeNames.Application.Octet;
        }
    }
}
