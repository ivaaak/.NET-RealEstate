using EstatesMicroservice.Services.Interfaces;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.QueryObjects;
using System.Net;

namespace EstatesMicroservice.Controllers
{
    /// <summary>
    /// Controller for managing estates.
    /// </summary>
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/estate")]
    public class EstateController : ControllerBase
    {
        private readonly IEstateService _estateService;
        private readonly IEstateQueryService _estateQueryService;
        private readonly IMediator _mediator;
        private readonly ILogger<EstateController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstateController"/> class.
        /// </summary>
        public EstateController(
            IEstateService estateService,
            IEstateQueryService estateQueryService,
            IMediator mediator,
            ILogger<EstateController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _estateService = estateService ?? throw new ArgumentNullException(nameof(estateService));
            _estateQueryService = estateQueryService ?? throw new ArgumentNullException(nameof(estateQueryService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        /// <summary>
        /// Creates an estate in the database if it doesn't already exist.
        /// </summary>
        /// <param name="estate">The estate object to create.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/estate/create
        ///
        /// </remarks>
        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Estate), (int)HttpStatusCode.OK)]
        public ActionResult Create(Estate estate)
        {
            var result = _estateService.Create(estate);

            if (result == null)
            {
                _logger.LogError($"Estate {estate.Estate_Name} not created.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets all estates from the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/estate/getall
        ///
        /// </remarks>
        [HttpGet("getall")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EstateDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EstateDTO>>> GetAll()
        {
            var result = await _estateService.GetEstates();

            if (result == null)
            {
                _logger.LogError($"Estates not found.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets an estate with the specified ID if it exists.
        /// </summary>
        /// <param name="id">The ID of the estate.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/estate/getbyid/5
        ///
        /// </remarks>
        [HttpGet("getbyid/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstateDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EstateDTO>> GetById(int id)
        {
            var result = await _estateService.GetEstateById(id);

            if (result == null)
            {
                _logger.LogError($"Estate with ID: {id} not found.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Updates an estate's values/properties.
        /// </summary>
        /// <param name="id">The ID of the estate to update.</param>
        /// <param name="estateObject">The updated estate object.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/estate/update/5
        ///
        /// </remarks>
        [HttpPut("update/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, EstateDTO estateObject)
        {
            var result = await _estateService.UpdateEstate(id, estateObject);

            if (!result)
            {
                _logger.LogError($"Estate with ID: {id} not updated.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Deletes an estate.
        /// </summary>
        /// <param name="id">The ID of the estate to delete.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/estate/delete/5
        ///
        /// </remarks>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _estateService.SoftDeleteEstate(id);

            if (!result)
            {
                _logger.LogError($"Estate with ID: {id} not deleted.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Deletes an estate permanently.
        /// </summary>
        /// <param name="id">The ID of the estate to hard delete.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/estate/harddelete/5
        ///
        /// </remarks>
        [HttpDelete("harddelete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await _estateService.HardDeleteEstate(id);

            if (!result)
            {
                _logger.LogError($"Estate with ID: {id} not hard deleted.");
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Checks if an estate with the given ID exists.
        /// </summary>
        /// <param name="id">The ID of the estate to check.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/estate/exists/5
        ///
        /// </remarks>
        [HttpGet("exists/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public ActionResult<bool> Exists(int id)
        {
            var exists = _estateService.GetEstateById(id).Result != null;

            if (!exists)
            {
                _logger.LogError($"Estate with ID: {id} not found.");
                return NotFound();
            }

            return Ok(exists);
        }

        /// <summary>
        /// Returns a collection of estates which contain the search keyword.
        /// </summary>
        /// <param name="searchTerm">The search keyword (string).</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/estate/search/2-bedroom
        ///
        /// </remarks>
        [HttpGet("search/{searchTerm}")]
        [ProducesResponseType(typeof(IEnumerable<EstateDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EstateDTO>>> Search(string searchTerm)
        {
            var result = await _estateService.SearchEstates(searchTerm);

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
        ///     POST /api/estate/search
        ///
        /// </remarks>
        [HttpPost("search")]
        [ProducesResponseType(typeof(PagedResult<EstateDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PagedResult<EstateDTO>>> Search([FromBody] SearchCriteriaObject criteria)
        {
            var result = await _estateQueryService.FindByCriteriaAsync(criteria);

            return Ok(result);
        }

        /// <summary>
        /// Returns a health status message for the microservice.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/estate/health
        ///
        /// </remarks>
        /// http://localhost:9003/api/estate
        /// http://localhost:9000/api/estate behind gateway
        [HttpGet("health")]
        [AllowAnonymous]
        public string GetHealth() => "Estates Microservice up and running";
    }
}
