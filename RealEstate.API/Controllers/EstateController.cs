using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Estates;
using RealEstate.Microservices.Users;
using RealEstate.Models.Entities.Estates;
using RealEstate.Models.ViewModels.Estates;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]  // /api/estate
    public class EstateController : BaseController
    {
        private readonly IEstateService estateService;

        public EstateController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service,
            IEstateService _estateService,
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            estateService = _estateService;
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
        [Route("create")]
        public void Create(Estate estate)
        {
            estateService.Create(estate);
            // check for duplication?
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
        [Route("getall")]
        public async Task<IEnumerable<EstateViewModel>> GetAll()
        {
            return await estateService.GetEstates();
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
        [HttpGet("{id}")]
        [Route("getbyid/{id}")]
        public async Task<ActionResult<Estate>> GetById(int id)
        {
            return await estateService.GetEstateById(id);
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
        [HttpPut("{id}")]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, EstateViewModel estateObject)
        {
            var result = await estateService.UpdateEstate(id, estateObject);

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
        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await estateService.SoftDeleteEstate(id);

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
        [HttpDelete("{id}")]
        [Route("harddelete/{id}")]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await estateService.HardDeleteEstate(id);

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
        [HttpDelete("{id}")]
        [Route("exists/{id}")]
        public bool RealEstateExists(int id)
        {
            var exists = estateService.GetEstateById(id).Result != null;

            return exists;
        }


        // SEARCH: api/estate/search/2-bedroom
        /// <summary>
        /// Returns a collection of estates which contain the search keyword.
        /// </summary>
        /// <param name="searchTerm"> searchTerm - keyword (string) </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/estate/exists/5
        ///
        /// </remarks>
        /// <returns> collection of estate objects </returns>
        [HttpDelete("{id}")]
        [Route("search/{id}")]
        public IEnumerable<EstateViewModel> Search(string searchTerm)
        {
            var result = estateService.SearchEstates(searchTerm).Result;

            return result;
        }
    }
}