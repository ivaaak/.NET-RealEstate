using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;

namespace RealEstate.API.Controllers.MVC
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        private readonly IMediator mediator;

        private readonly IMapper mapper;

        public UserController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
        }

        public async Task<IActionResult> IndexAsync()
        {
            var propertiesList = await mediator.Send(new GetEstateListQuery());
            // Example call to MediatR

            return View();
        }

    }
}
