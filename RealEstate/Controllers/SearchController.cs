using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;

namespace RealEstate.Controllers
{
    public class SearchController : BaseController
    {
        public async Task<IActionResult> Index([FromQuery] string query)
            => this.View(await this.Mediator.Send(new SearchQuery { Query = query }));
    }
}
