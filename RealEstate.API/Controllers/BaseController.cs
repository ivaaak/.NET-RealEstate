using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Authentication;
using RealEstate.Models.Entities.Identity;

namespace RealEstate.API.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        //register services?
        private readonly IMapper? mapper;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        private IMediator mediator;
        
        // Getters
        public RoleManager<IdentityRole> GetRoleManager() => roleManager;
        public UserManager<ApplicationUser> GetUserManager() => userManager;
        public IUserService GetUserService() => service;
        public IMediator GetMediator() => mediator;
        public IMapper GetMapper() => mapper;


        public BaseController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator, 
            IMapper _mapper)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
            mediator = _mediator;
            mapper = _mapper;
        }

        protected IMediator Mediator
            => mediator
            ?? (mediator ?? HttpContext
                            .RequestServices
                            .GetService<IMediator>());
    }
}
