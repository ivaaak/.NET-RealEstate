using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Controllers;
using RealEstate.CQRS.Queries;

namespace RealEstate.API.Controllers.MVC
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> AllProperties(GetPropertyListQuery query)
            => View(await Mediator.Send(query));


        public async Task<IActionResult> AllPeople(GetPersonListQuery query)
            => View(await Mediator.Send(query));


        public async Task<IActionResult> Privacy()
        {
            var peopleList = await Mediator.Send(new GetPersonListQuery());

            return View(peopleList);
        }
    }
}