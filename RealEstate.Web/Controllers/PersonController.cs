using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Handlers.Read;
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
        public async Task Person(string id)
            => await Mediator.Send(new GetClientByIdHandler(id) { Id = id });
        

        [HttpGet]
        public async Task PeopleList()
            => await Mediator.Send(new GetClientListQuery());
    }
}