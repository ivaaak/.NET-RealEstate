using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Handlers.Query;
using RealEstate.CQRS.Queries;
using RealEstate.Microservices.Users;
using RealEstate.Models.Entities.Identity;
using RealEstate.Models.ViewModels.Clients;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager, 
            IUserService _service, 
            IMediator _mediator, 
            IMapper _mapper) 
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            userService = _service;
        }


        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="ApplicationUser"/> object containing information about the user.</returns>
        [HttpGet]
        [Route("/getuser/{id}")]
        public async Task<ApplicationUser> GetUserById(string id)
        {
            var result = await userService.GetUserById(id);

            return result;
        }


        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>A list of <see cref="ClientViewModel"/> objects containing information about the users.</returns>
        [HttpGet]
        [Route("/getusers")]
        public async Task<IEnumerable<ClientViewModel>> GetUsers()
        {
            var result = await userService.GetUsers();

            return result;
        }


        /// <summary>
        /// Gets a user for edit by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="ClientEditViewModel"/> object containing information about the user.</returns>
        [HttpGet]
        [Route("/edit/{id}")]
        public async Task<ClientEditViewModel> GetUserForEdit(string id)
        {
            var result = await userService.GetUserForEdit(id);

            return result;
        }


        /// <summary>
        /// Updates a user's information.
        /// </summary>
        /// <param name="model">A <see cref="ClientEditViewModel"/> object containing the updated user information.</param>
        /// <returns>A boolean indicating whether the update was successful.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<bool> UpdateUser(ClientEditViewModel model)
        {
            var result = await userService.UpdateUser(model);

            return result;
        }


        /// <summary>
        /// Hard-deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        [HttpDelete]
        [Route("/harddelete/{id}")]
        public async Task<bool> HardDeleteUser(string id)
        {
            var result = await userService.HardDeleteUser(id);

            return result;
        }


        /// <summary>
        /// Soft-deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A boolean indicating whether the delete was successful.</returns>
        [HttpDelete]
        [Route("/softdelete/{id}")]
        public async Task<bool> SoftDeleteUser(string id)
        {
            var result = await userService.SoftDeleteUser(id);

            return result;
        }


        /// <summary>
        /// Changes a user's password.
        /// </summary>
        /// <param name="id">The ID of the user whose password is being changed.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>A boolean indicating whether the password change was successful.</returns>
        [HttpPut]
        [Route("/changepassword/{id}")]
        public async Task<bool> ChangePassword(string id, string newPassword)
        {
            var result = await userService.ChangePassword(id, newPassword);

            return result;
        }


        /// <summary>
        /// Searches for users matching a given search term.
        /// </summary>
        /// <param name="searchTerm">The search term to use for the search.</param>
        /// <returns>An enumerable list of <see cref="ClientViewModel"/> objects containing information about the matching users.</returns>
        [HttpGet("search")]
        public async Task<IEnumerable<ClientViewModel>> SearchUsers(string searchTerm)
        {
            var result = await userService.SearchUsers(searchTerm);

            return result;
        }


        /// <summary>
        /// Gets the role of a user.
        /// </summary>
        /// <param name="id">The ID of the user whose role is being retrieved.</param>
        /// <returns>A string containing the user's role.</returns>
        [HttpGet]
        [Route("/role/{id}")]
        public async Task<string> GetUserRole(string id)
        {
            var result = await userService.GetUserRole(id);

            return result;
        }


        /// <summary>
        /// Determines if a user has a given role.
        /// </summary>
        /// <param name="id">The ID of the user being checked.</param>
        /// <param name="role">The role to check for.</param>
        /// <returns>A boolean indicating whether the user has the given role.</returns>
        [HttpGet]
        [Route("/hasrole/{id}")]
        public async Task<bool> UserHasRole(string id, string role)
        {
            var result = await userService.UserHasRole(id, role);

            return result;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task Person(string id)
            => await Mediator.Send(new GetClientByIdHandler(id) { Id = id });
        

        [HttpGet]
        public async Task PeopleList()
            => await Mediator.Send(new GetClientListQuery());
    }
}