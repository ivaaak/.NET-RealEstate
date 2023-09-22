using ListingsMicroservice.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Listings;
using RealEstate.Shared.Models.QueryObjects;
using System.Net;

namespace ListingsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")] // api/auth/
    public class ListingsQueryController : ControllerBase
    {
        private readonly IListingQueryService _listingQueryService;

        private readonly IListingService _listingService;

        private readonly IMediator? _mediator;

        private readonly ILogger<ListingsQueryController> _logger;

        public ListingsQueryController(
            IMediator mediator,
            ILogger<ListingsQueryController> logger,
            IListingQueryService listingQueryService,
            IListingService listingService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _listingQueryService = listingQueryService ?? throw new ArgumentNullException(nameof(listingQueryService));
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService)); ;
        }




        /// <summary>
        /// Returns a collection of listings which contain the search keyword.
        /// </summary>
        /// <param name="searchTerm">The search keyword (string).</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/listing/search/2-bedroom
        ///
        /// </remarks>
        [HttpGet("search/{searchTerm}")]
        [ProducesResponseType(typeof(IEnumerable<ListingDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ListingDTO>>> Search(string searchTerm)
        {
            var result = await _listingService.SearchListings(searchTerm);

            if (!result.Any())
            {
                _logger.LogWarning($"No estates found for search term: {searchTerm}");
            }

            return Ok(result);
        }


        /// <summary>
        /// Returns a collection of estates which are filtered, sorted and paginated
        /// </summary>
        /// <param name="searchTerm">The search keyword (string).</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/listing/search
        ///
        /// </remarks>
        [HttpPost("search")]
        [ProducesResponseType(typeof(PagedResult<ListingDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResult<ListingDTO>>> Search([FromBody] SearchCriteriaObject criteria)
        {
            var result = await _listingQueryService.FindByCriteriaAsync(criteria);

            return Ok(result);
        }
    }
}