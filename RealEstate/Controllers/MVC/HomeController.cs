using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.Controllers.MVC
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> AllProperties(GetPropertyListQuery query)
            => this.View(await this.Mediator.Send(query));


        public async Task<IActionResult> AllPeople(GetPersonListQuery query)
            => this.View(await this.Mediator.Send(query));


        public async Task<IActionResult> Privacy()
        {
            var peopleList = await this.Mediator.Send(new GetPersonListQuery());

            return View(peopleList);
        }
    }
}