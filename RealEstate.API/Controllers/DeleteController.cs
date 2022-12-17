using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands.Delete;
using RealEstate.Data.Identity;
using RealEstate.Infrastructure.Filters;
using RealEstate.Microservices.Contracts;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : BaseController
    {
        public NotificationsController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}

        /// <summary>
        /// Delete estate by Id
        /// </summary>
        /// <param name="estateId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteEstateByIdCommand command)
        {
            var deleteRequest = await Mediator.Send(command);

            if (deleteRequest.Errors is null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}