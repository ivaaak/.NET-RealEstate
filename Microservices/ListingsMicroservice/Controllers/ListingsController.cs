using ListingsMicroservice.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.Entities.Listings;
using System.Net;

namespace ListingsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]  // /api/listing
    public class ListingController : ControllerBase
    {
        private readonly IListingService _listingService;

        private readonly IMediator? _mediator;

        private readonly ILogger<ListingController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public ListingController(
            IListingService listingService,
            IMediator mediator,
            ILogger<ListingController> logger, 
            IPublishEndpoint publishEndpoint)
        {
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        // CREATE: api/listing/create  //object
        /// <summary>
        /// Creates an listing in the database if it doesnt already exist.
        /// </summary>
        /// <param name="listing"> listing Object </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/listing/create 
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpPost]
        public ActionResult Create(Listing listing)
        {
            var result = _listingService.Create(listing);

            if (result == null)
            {
                _logger.LogError($"Couldnt create Listing");
                return NotFound();
            }

            return Ok(result);
        }


        // GET: api/listing/getall
        /// <summary>
        /// Gets all listings from the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/listing/getall
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListingDTO>>> GetAll()
        {
            var result = await _listingService.GetListings();

            if (result == null)
            {
                _logger.LogError($"Couldnt get Listings");
                return NotFound(result);
            }

            return Ok(result);
        }


        // GET: api/listing/getbyid/5
        /// <summary>
        /// Gets an listing with the id if it exists.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/listing/getbyid/5
        ///
        /// </remarks>
        /// <returns> listing Object </returns>
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Listing>> GetById(int id)
        {
            var result = await _listingService.GetListingById(id);
            
            if (result == null)
            {
                _logger.LogError($"Couldnt get Listings Listing by ID");
                return NotFound(result);
            }

            return Ok(result);
        }


        // PUT: api/listing/update/5
        /// <summary>
        /// Updates an listing's values/properties.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <param name="listingObject"> listing - object </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/listing/update/5
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpPut]
        [Route("UpdateListing/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, ListingDTO listingObject)
        {
            var result = await _listingService.UpdateListing(listingObject);

            if (!result)
            {
                _logger.LogError($"Couldnt update Listing by ID {id}");
                return NotFound(result);
            }

            return Ok(result);
        }


        // DELETE: api/listing/delete/5
        /// <summary>
        /// Deletes an listing.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/listing/delete/5
        ///
        /// </remarks>
        /// <returns> Ok - result </returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _listingService.SoftDeleteListing(id);

            if (result == false)
            {
                _logger.LogError($"Couldnt delete Listing by ID {id}");
                return NotFound(result);
            }

            return Ok(result);
        }


        // HARD DELETE: api/listing/harddelete/5
        /// <summary>
        /// Deletes an listing.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/listing/harddelete/5
        ///
        /// </remarks>
        /// <returns> Ok - result </returns>
        [HttpDelete]
        [Route("HardDelete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await _listingService.DeleteListing(id);

            if (result == false)
            {
                _logger.LogError($"Couldnt delete Listing by ID {id}");
                return NotFound(result);
            }

            return Ok(result);
        }

        // EXISTS: api/listing/exists/5
        /// <summary>
        /// Returns a boolean - if the listing with the given id exists.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/listing/exists/5
        ///
        /// </remarks>
        /// <returns> exists - boolean </returns>
        [HttpDelete]
        [Route("ListingExists/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult<bool> ListingExists(int id)
        {
            var exists = _listingService.GetListingById(id).Result != null;

            if (!exists)
            {
                _logger.LogError($"Couldnt find Listing by ID {id}");
                return NotFound(exists);
            }

            return Ok(exists);
        }

        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9005/api/listings/gethealth
        //http://localhost:9000/api/listings/gethealth behind gateway
        public string getHealth() => "Listings Microservice up and running";
    }
}