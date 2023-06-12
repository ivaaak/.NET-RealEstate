using EstatesMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Core.Exceptions;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace EstatesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]  // /api/estate
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoritesService _favoritesService;

        private readonly ILogger<EstateController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public FavoriteController(
            IFavoritesService favoritesService,
            ILogger<EstateController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _favoritesService = favoritesService ?? throw new ArgumentNullException(nameof(favoritesService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        // POST api/favorites/AddEstateToClient
        [HttpPost("AddEstateToClient/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddEstateToClient(string clientId, [FromBody] Estate estate)
        {
            try
            {
                await _favoritesService.AddEstateToClient(clientId, estate);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/favorites/AddExistingEstateToClient
        [HttpPost("AddExistingEstateToClient/{estateId}/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddExistingEstateToClient(string estateId, string clientId)
        {
            try
            {
                await _favoritesService.AddExistingEstateToClientUsingId(estateId, clientId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/favorites/RemoveEstateFromClient/{estateId}/{clientId}
        [HttpDelete("RemoveEstateFromClient/{estateId}/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveEstateFromClient(string estateId, string clientId)
        {
            try
            {
                await _favoritesService.RemoveEstateFromClientUsingId(estateId, clientId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/favorites/ClientHasEstate/{estateId}/{clientId}
        [HttpGet("ClientHasEstate/{estateId}/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> ClientHasEstate(string estateId, string clientId)
        {
            try
            {
                var clientHasEstate = await _favoritesService.ClientHasEstateUsingId(estateId, clientId);
                return Ok(clientHasEstate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/favorites/listing
        [HttpPost("AddListingToClient/{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddListingToClient(string clientId, [FromBody] Listing listing)
        {
            try
            {
                await _favoritesService.AddListingToClient(clientId, listing);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/favorites/listing/{clientId}/{listingId}
        [HttpDelete("listing/{clientId}/{listingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveListingFromClient(string clientId, string listingId)
        {
            try
            {
                var listingRemoved = await _favoritesService.RemoveListingFromClient(clientId, listingId);
                if (listingRemoved)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/favorites/ClientHasListing/{clientId}/{listingId}
        [HttpGet("ClientHasListing/{clientId}/{listingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> ClientHasListing(string clientId, string listingId)
        {
            try
            {
                var clientHasListing = await _favoritesService.ClientHasListing(clientId, listingId);
                if (clientHasListing)
                {
                    return Ok(clientHasListing);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}