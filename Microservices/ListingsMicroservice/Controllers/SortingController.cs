using ListingsMicroservice.Services.Sorting;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Estates;
using System.Net;

namespace ListingsMicroservice.Controllers
{
    [Authorize]
    //[AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/auth/
    public class SortingController : ControllerBase
    {
        private readonly IEstateSortingService _estateSortingService;

        private readonly IMediator? _mediator;

        private readonly ILogger<SortingController> _logger;

        public SortingController(
            IMediator mediator,
            ILogger<SortingController> logger,
            IEstateSortingService estateSortingService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _estateSortingService = estateSortingService ?? throw new ArgumentNullException(nameof(estateSortingService));
        }

        /// <summary>
        /// Sorts a collection of Estates
        /// </summary>
        /// <param name="request">Object - From, To, Subject, HtmlContent</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/sorting/listings
        ///
        /// </remarks>
        [HttpPost]
        [Route("send")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult Listings([FromQuery] List<Estate> query)
        {
            var result = _estateSortingService.SortByMultiple(query);

            if (result == null)
            {
                _logger.LogError($"Search with the query: {query}, null.");
                return NotFound();
            }

            return Ok(result);
        }
    }
}