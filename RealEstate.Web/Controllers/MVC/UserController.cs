using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Contracts;
using RealEstate.CQRS.Queries;
using RealEstate.Infrastructure.Data.Identity;

namespace RealEstate.API.Controllers.MVC
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        private readonly IMediator mediator;


        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
            mediator = _mediator;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var propertiesList = await mediator.Send(new GetEstateListQuery());
            // Example call to MediatR

            return View();
        }

    }
}
