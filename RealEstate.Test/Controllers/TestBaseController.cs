using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.API.Authentication;
using RealEstate.API.Controllers;
using RealEstate.Models.Entities.Identity;

namespace RealEstate.Test.Controllers
{
    public class TestBaseController : BaseController
    {
        // currently unused as I added getters to the base controller implementation
        public TestBaseController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserService service,
            IMediator mediator,
            IMapper mapper)
            : base(roleManager, userManager, service, mediator, mapper)
        {
        }

        public RoleManager<IdentityRole> RoleManager => RoleManager;
        public UserManager<ApplicationUser> UserManager => UserManager;
        public IUserService Service => Service;
        public IMediator Mediator => Mediator;
        public IMapper Mapper => Mapper;
    }

}
