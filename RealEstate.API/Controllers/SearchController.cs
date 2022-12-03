using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : BaseController
    {
        [HttpGet]
        public async Task Search([FromQuery] string query)
            => await Mediator.Send(new CombinedSearchQuery { Query = query });

        [HttpGet]
        public async Task ClientSearch([FromQuery] string query)
            => await Mediator.Send(new ClientsSearchQuery { Query = query });

        [HttpGet]
        public async Task EstateSearch([FromQuery] string query)
            => await Mediator.Send(new EstatesSearchQuery { Query = query });

        [HttpGet]
        public async Task ListingSearch([FromQuery] string query)
            => await Mediator.Send(new ListingsSearchQuery { Query = query });
    }
}
