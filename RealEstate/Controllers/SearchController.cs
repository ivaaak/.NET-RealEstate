using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.Web.Controllers
{
    public class SearchController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string query)
            => View(await Mediator.Send(new SearchQuery { Query = query }));
    }
}
