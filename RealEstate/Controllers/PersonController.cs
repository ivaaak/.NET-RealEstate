using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.Controllers
{
    [Authorize]
    public class PersonController : BaseController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Person(Guid id)
            => this.View(await this.Mediator.Send(new GetPersonByIdQuery(id) { Id = id }));


        public async Task<IActionResult> PeopleList()
            => this.View(await this.Mediator.Send(new GetPersonListQuery()));


        /*
        [HttpPost]
        public async Task<IActionResult> DeclineInvite(DeclineInviteCommand command)
        {
            await this.Mediator.Send(command);
            return this.RedirectToAction(nameof(Invites));
        }


        public async Task<IActionResult> Privacy()
        {
            var peopleList = await mediator.Send(new GetPersonListQuery());

            return View();
        }
        */
    }
}