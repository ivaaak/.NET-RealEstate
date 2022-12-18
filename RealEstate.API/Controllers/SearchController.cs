using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : BaseController
    {
        public SearchController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}

        // SEARCH: api/search/
        [HttpGet("/")]
        //[HttpGet("combined?")]
        public async Task Search([FromQuery] string query)
            => await Mediator.Send(new CombinedSearchQuery { Query = query });

        // CLIENT: api/search/client
        [HttpGet("client")]
        public async Task Client([FromQuery] string query)
            => await Mediator.Send(new ClientsSearchQuery(query) { Query = query });

        // ESTATE: api/search/estate
        [HttpGet("estate")]
        public async Task Estate([FromQuery] string query)
            => await Mediator.Send(new EstatesSearchQuery(query) { Query = query });

        // LISTING: api/search/listing
        [HttpGet("listing")]
        public async Task Listing([FromQuery] string query)
            => await Mediator.Send(new ListingsSearchQuery { Query = query });


        // GET: api/search/search?city={city}&minPrice={minPrice}&maxPrice={maxPrice}&id={id}&name={name}&sort={sort}
        [HttpGet("byParameters")]
        public async Task<ActionResult<IEnumerable<Estate>>> ByParameters(string? city, int? minPrice, int? maxPrice, string? id, string? name, string sort)
        {
            var results = await Mediator.Send(new EstatesSearchQuery() //change to viewmodel?
            {
                City = city,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Id = id,
                Name = name,
                Sort = sort
            });

            return Ok(results);
        }
    }
}
