using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Handlers.Query;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        public PersonController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}

        [AllowAnonymous]
        [HttpGet]
        public async Task Person(string id)
            => await Mediator.Send(new GetClientByIdHandler(id) { Id = id });
        

        [HttpGet]
        public async Task PeopleList()
            => await Mediator.Send(new GetClientListQuery());
    }
}