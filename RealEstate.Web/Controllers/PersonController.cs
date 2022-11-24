using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Person(Guid id)
            => View(await Mediator.Send(new GetPersonByIdQuery(id) { Id = id }));


        [HttpGet]
        public async Task<IActionResult> PeopleList()
            => View(await Mediator.Send(new GetPersonListQuery()));
    }
}