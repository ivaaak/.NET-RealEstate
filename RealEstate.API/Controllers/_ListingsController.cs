using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Queries;
using RealEstate.Data.Identity;
using RealEstate.Microservices.Contracts;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class _ListingsController : BaseController
    {
        public _ListingsController(
            RoleManager<IdentityRole> _roleManager, 
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {}

        [HttpGet("getEstate")]
        public async Task<IActionResult> GetEstateAsync(int estateId)
        {
            try
            {
                await Mediator.Send(new GetEstateByIdQuery(estateId));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
