using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Microservices.Listings;
using RealEstate.Microservices.Users;
using RealEstate.Models.Entities.Identity;
using RealEstate.Models.Entities.Listings;
using RealEstate.Models.ViewModels.Listings;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]  // /api/listing
    public class ListingController : BaseController
    {
        private readonly IListingService listingService;
        public ListingController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IListingService _listingService,
            IMediator _mediator,
            IMapper _mapper)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            listingService = _listingService;
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
        [Route("create")]
        public void Create(Listing listing)
        {
            listingService.Create(listing);
            // check for duplication?
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
        [Route("getall")]
        public async Task<IEnumerable<ListingViewModel>> GetAll()
        {
            return await listingService.GetListings();
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
        [HttpGet("{id}")]
        [Route("getbyid/{id}")]
        public async Task<ActionResult<Listing>> GetById(int id)
        {
            return await listingService.GetListingById(id);
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
        [HttpPut("{id}")]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, ListingViewModel listingObject)
        {
            var result = await listingService.UpdateListing(listingObject);

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
        [HttpDelete("{id}")]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await listingService.SoftDeleteListing(id);

            return Ok(result);
        }


        // HARD DELETE: api/listing/darddelete/5
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
        [HttpDelete("{id}")]
        [Route("harddelete/{id}")]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await listingService.DeleteListing(id);

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
        [HttpDelete("{id}")]
        [Route("exists/{id}")]
        public bool ListingExists(int id)
        {
            var exists = listingService.GetListingById(id).Result != null;

            return exists;
        }


        // SEARCH: api/listing/search/2-bedroom
        /// <summary>
        /// Returns a collection of listings which contain the search keyword.
        /// </summary>
        /// <param name="searchTerm"> searchTerm - keyword (string) </param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/listing/exists/5
        ///
        /// </remarks>
        /// <returns> collection of listing objects </returns>
        [HttpDelete("{id}")]
        [Route("search/{id}")]
        public IEnumerable<ListingViewModel> Search(string searchTerm)
        {
            var result = listingService.SearchListings(searchTerm).Result;

            return result;
        }
    }
}