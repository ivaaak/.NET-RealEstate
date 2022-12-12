using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.API.Controllers.MVC
{
    public class HomeController : BaseController
    {
        public HomeController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}

        [HttpGet]
        public async Task allProperties(GetEstateListQuery query)
            => await Mediator.Send(query);

        [HttpGet]
        public async Task allPeopleByParameters(GetClientListQuery query)
            => await Mediator.Send(query);

        [HttpGet]
        public async Task<List<ClientViewModel>> allClients()
        {
            var peopleList = await Mediator.Send(new GetClientListQuery());

            return peopleList;
        }
    }
}