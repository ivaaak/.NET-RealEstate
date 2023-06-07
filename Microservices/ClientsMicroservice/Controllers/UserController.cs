using ClientsMicroservice.Data;
using ClientsMicroservice.Services.Interfaces;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Users;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ClientsMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userService;

        private readonly IPublishEndpoint _publishEndpoint;


        public UserController(
            IMediator mediator, 
            IUserService userService, 
            IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetCurrentlyLoggedInUser()
        {
            var userId = User.GetLoggedInUserId();

            //var response = await _mediator.GetQueryNotNull<UserDto>(new GetUserByIdQuery() { Id = userId });
            var response = await _userService.GetUserById(userId);

            return Ok(response);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("This method can only be used by the administrator.")]
        public async Task<IActionResult> GetUserById([Required] Guid userId)
        {
            //var response = await _mediator.GetQueryNotNull<UserDto>(new GetUserByIdQuery() { Id = userId });
            var response = await _userService.GetUserById(userId);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttributeListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetCurrentAttributes()
        {
            var userId = User.GetLoggedInUserId();

            var response = await _userService.GetUserAttributesById(userId);

            return Ok(response);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttributeListDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("This method can only be used by the administrator.")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAttributesNyId([Required] Guid userId)
        {
            var response = await _userService.GetUserById(userId);

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9001/api/user
        //http://localhost:9000/api/user behind gateway
        public string getHealth() => "Clients Microservice up and running";
    }
}
