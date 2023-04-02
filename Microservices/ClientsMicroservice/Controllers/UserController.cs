using ClientsMicroservice.Authentication.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.MediatR.Handlers.Query;
using RealEstate.Shared.MediatR.Queries;
using RealEstate.Shared.Models.DTOs.Clients;
using RealEstate.Shared.Models.Entities.Identity;
using System.Net;

namespace ClientsMicroservice.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMediator? _mediator;

        private readonly ILogger<UserController> _logger;


        public UserController(
            IUserService service,
            IMediator mediator,
            ILogger<UserController> logger)
        {
            _userService = service ?? throw new ArgumentNullException(nameof(service));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="ApplicationUser"/> object containing information about the user.</returns>
        [HttpGet]
        [Route("/getuser/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApplicationUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);

            if (result == null)
            {
                _logger.LogError($"Result with id: {id}, not found.");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>A list of <see cref="ClientDTO"/> objects containing information about the users.</returns>
        [HttpGet]
        [Route("/getusers")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ClientDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetUsers()
        {
            var result = await _userService.GetUsers();

            if (result == null)
            {
                _logger.LogError($"Result not found.");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Gets a user for edit by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="ClientEditDTO"/> object containing information about the user.</returns>
        [HttpGet]
        [Route("/edit/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ClientEditDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClientEditDTO>> GetUserForEdit(string id)
        {
            var result = await _userService.GetUserForEdit(id);

            if (result == null)
            {
                _logger.LogError($"User not found.");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Updates a user's information.
        /// </summary>
        /// <param name="model">A <see cref="ClientEditDTO"/> object containing the updated user information.</param>
        /// <returns>A boolean indicating whether the update was successful.</returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ClientEditDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateUser(ClientEditDTO model)
        {
            var result = await _userService.UpdateUser(model);

            return result;
        }


        /// <summary>
        /// Hard-deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        [HttpDelete]
        [Route("/harddelete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> HardDeleteUser(string id)
        {
            var result = await _userService.HardDeleteUser(id);

            if (result == false)
            {
                _logger.LogError($"Couldnt delete user with id {id}");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Soft-deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        [HttpDelete]
        [Route("/softdelete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> SoftDeleteUser(string id)
        {
            var result = await _userService.SoftDeleteUser(id);

            if (result == false)
            {
                _logger.LogError($"Couldnt soft delete user with id {id}");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Changes a user's password.
        /// </summary>
        /// <param name="id">The ID of the user whose password is being changed.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>A boolean indicating whether the password change was successful.</returns>
        [HttpPut]
        [Route("/changepassword/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> ChangePassword(string id, string newPassword)
        {
            var result = await _userService.ChangePassword(id, newPassword);

            if (result == false)
            {
                _logger.LogError($"Couldnt change password for user with id {id}");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Searches for users matching a given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use for the search.</param>
        /// <returns>An enumerable list of <see cref="ClientDTO"/> objects containing information about the matching users.</returns>
        [HttpGet("search")]
        [Route("/searchusers/{searchterm}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ClientDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> SearchUsers(string searchTerm)
        {
            var result = await _userService.SearchUsers(searchTerm);

            if (result == null)
            {
                _logger.LogError($"Couldnt find user with the term {searchTerm}");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Gets the role of a user.
        /// </summary>
        /// <param name="id">The ID of the user whose role is being retrieved.</param>
        /// <returns>A string containing the user's role.</returns>
        [HttpGet]
        [Route("/role/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> GetUserRole(string id)
        {
            var result = await _userService.GetUserRole(id);

            if (result == null)
            {
                _logger.LogError($"Couldnt find user's roles with the id {id}");
                return NotFound();
            }

            return Ok(result);
        }


        /// <summary>
        /// Determines if a user has a given role.
        /// </summary>
        /// <param name="id">The ID of the user being checked.</param>
        /// <param name="role">The role to check for.</param>
        /// <returns>A boolean indicating whether the user has the given role.</returns>
        [HttpGet]
        [Route("/hasrole/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UserHasRole(string id, string role)
        {
            var result = await _userService.UserHasRole(id, role);

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("mediator/person/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Person(string id)
        {
            var result = await _mediator.Send(new GetClientByIdHandler(id) { Id = id });

            if (result == null)
            {
                _logger.LogError($"Couldnt find user with the id {id}");
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("mediator/personlist/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> PersonList()
        {
            var result = await _mediator.Send(new GetClientListQuery());

            if (result == null)
            {
                _logger.LogError($"Couldnt find any users");
                return NotFound();
            }

            return Ok(result);
        }
    }
}