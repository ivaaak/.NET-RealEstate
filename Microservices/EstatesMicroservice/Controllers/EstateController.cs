using EstatesMicroservice.Services;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Estates;
using RealEstate.Shared.Models.Entities.Estates;
using System.Net;

namespace EstatesMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]  // /api/estate
    public class EstateController : ControllerBase
    {
        private readonly IEstateService _estateService;

        private readonly IMediator? _mediator;

        private readonly ILogger<EstateController> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public EstateController(
            IEstateService estateService,
            IMediator mediator,
            ILogger<EstateController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _estateService = estateService ?? throw new ArgumentNullException(nameof(estateService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }
        

        // CREATE: api/estate/create  //object
        /// <summary>
        /// Creates an estate in the database if it doesnt already exist.
        /// </summary>
        /// <param name="estate"> Estate Object </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/estate/create 
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public ActionResult Create(Estate estate)
        {
            var result = _estateService.Create(estate);

            if (result == null)
            {
                _logger.LogError($"Estate {estate} not created.");
                return NotFound();
            }

            return Ok(result);
        }


        // GET: api/estate/getall
        /// <summary>
        /// Gets all estates from the database.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/estate/getall
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult<IEnumerable<EstateDTO>>), (int)HttpStatusCode.OK)]
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


        // GET: api/estate/getbyid/5
        /// <summary>
        /// Gets an estate with the id if it exists.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /api/estate/getbyid/5
        ///
        /// </remarks>
        /// <returns> Estate Object </returns>
        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult<EstateDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EstateDTO>> GetById(int id)
        {
            var result = await _estateService.GetEstateById(id);

            //automapper for the result?

            if (result == null)
            {
                _logger.LogError($"Estate with id: {id} not found.");
                return NotFound();
            }

            return Ok(result);
        }


        // PUT: api/estate/update/5
        /// <summary>
        /// Updates an estate's values/properties.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <param name="estateObject"> estate - object </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/update/5
        ///
        /// </remarks>
        /// <returns> Ok </returns>
        [HttpPut]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, EstateDTO estateObject)
        {
            var result = await _estateService.UpdateEstate(id, estateObject);

            if (result == false)
            {
                _logger.LogError($"Estate with id: {id} not updated.");
                return NotFound();
            }

            return Ok(result);
        }


        // DELETE: api/estate/delete/5
        /// <summary>
        /// Deletes an estate.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/delete/5
        ///
        /// </remarks>
        /// <returns> Ok - result </returns>
        [HttpDelete]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _estateService.SoftDeleteEstate(id);

            if (result == false)
            {
                _logger.LogError($"Estate with id: {id} not deleted.");
                return NotFound();
            }

            return Ok(result);
        }


        // HARD DELETE: api/estate/darddelete/5
        /// <summary>
        /// Deletes an estate.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/harddelete/5
        ///
        /// </remarks>
        /// <returns> Ok - result </returns>
        [HttpDelete]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await _estateService.HardDeleteEstate(id);

            if (result == false)
            {
                _logger.LogError($"Estate with id: {id} not hard deleted.");
                return NotFound();
            }

            return Ok(result);
        }

        // EXISTS: api/estate/exists/5
        /// <summary>
        /// Returns a boolean - if the estate with the given id exists.
        /// </summary>
        /// <param name="id"> id - int </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/exists/5
        ///
        /// </remarks>
        /// <returns> exists - boolean </returns>
        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult<bool>), (int)HttpStatusCode.OK)]
        public ActionResult<bool> Exists(int id)
        {
            var exists = _estateService.GetEstateById(id).Result != null;

            if (exists == false)
            {
                _logger.LogError($"Estate with id: {id} not found.");
                return NotFound();
            }

            return Ok(exists);
        }


        // SEARCH: api/estate/search/2-bedroom
        /// <summary>
        /// Returns a collection of estates which contain the search keyword.
        /// </summary>
        /// <param name="searchTerm"> searchTerm - keyword (string) </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/search/{searchTerm}
        ///
        /// </remarks>
        /// <returns> collection of estate objects </returns>
        [HttpGet]
        [Route("/{searchTerm}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EstateDTO>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<EstateDTO>> Search(string searchTerm)
        {
            var result = _estateService.SearchEstates(searchTerm).Result;

            if (result == null)
            {
                _logger.LogError($"Estate with searchTerm: {searchTerm} not found.");
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9003/api/estate
        //http://localhost:9000/api/estate behind gateway
        public string getHealth() => " Estates Microservice up and running";
    }
}