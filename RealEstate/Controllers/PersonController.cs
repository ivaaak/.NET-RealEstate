using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.Controllers
{
    [Authorize]
    public class PersonController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Person(Guid id)
            => this.View(await this.Mediator.Send(new GetPersonByIdQuery(id) { Id = id }));


        [HttpGet]
        public async Task<IActionResult> PeopleList()
            => this.View(await this.Mediator.Send(new GetPersonListQuery()));
    }
}