using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands.Create;
using RealEstate.CQRS.Commands.Delete;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;
using RealEstate.Models.Entities.Estates;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstateController : BaseController
    {
        public EstateController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}


        [HttpPost]
        public async Task<IActionResult> CreateEstate(Estate estate)
        {
            await Mediator.Send(new CreateEstateCommand(estate));

            //redirect to the wanted page
            return RedirectToAction(nameof(Estate));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEstate(int estateId)
        {
            await Mediator.Send(new DeletePropertyByIdCommand(estateId));

            //redirect to the wanted page
            return RedirectToAction(nameof(Estate));
        }
    }
}