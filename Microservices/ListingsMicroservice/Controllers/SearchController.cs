#nullable disable
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.Entities.Estates;
using System.Net;

namespace ListingsMicroservice.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<SearchController> _logger;

        public SearchController(
            IMediator mediator,
            ILogger<SearchController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // SEARCH: api/search/
        [HttpGet("/")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Search([FromQuery] string query)
        {
            var result = await _mediator.Send(new CombinedSearchQuery { Query = query });

            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
        }

        // CLIENT: api/search/client
        [HttpGet("client")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Client([FromQuery] string query)
        {
            var result = await _mediator.Send(new ClientsSearchQuery(query) { Query = query });

            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
        }

        // ESTATE: api/search/estate
        [HttpGet("estate")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Estate([FromQuery] string query)
        {
            var result = await _mediator.Send(new EstatesSearchQuery(query) { Query = query });

            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
        }

        // LISTING: api/search/listing
        [HttpGet("listing")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Listing([FromQuery] string query)
        {
            var result =  await _mediator.Send(new ListingsSearchQuery { Query = query });

            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
        }


        // GET: api/search/search?city={city}&minPrice={minPrice}&maxPrice={maxPrice}&id={id}&name={name}&sort={sort}
        [HttpGet("byParameters")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Estate>>> ByParameters(string city, int? minPrice, int? maxPrice, string id, string name, string sort)
        {
            var results = await _mediator.Send(new EstatesSearchQuery() //change to viewmodel?
            {
                City = city,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Id = id,
                Name = name,
                Sort = sort
            });

            if (results == null)
            {
                _logger.LogError($"Search ByParameters returned null.");
                return NotFound();
            }

            return Ok(results);
        }
    }
}
