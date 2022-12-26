using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data.Identity;
using RealEstate.Infrastructure.Filters;
using RealEstate.Microservices.Auth0;
using RealEstate.Microservices.Users;
using RealEstate.Models.Entities.AuthUser;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/auth/
    public class AuthController : BaseController
    {
        private readonly IAuth0AuthenticationService authService;

        public AuthController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service,
            IMediator _mediator,
            IMapper _mapper,
            IAuth0AuthenticationService _authService)
            : base(_roleManager, _userManager, _service, _mediator, _mapper)
        {
            authService = _authService;
        }


        // GET USER INFO
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <param name="accessToken">The access token obtained during the authentication process.</param>
        /// <returns>An <see cref="Auth0User"/> object containing information about the authenticated user.</returns> 
        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUserInfo(string accessToken)
        {
            var result = await authService.GetUserInfo(accessToken);

            return Ok(result);
        }


        // GET ACCESS TOKEN
        /// <summary>
        /// Gets an access token using an authorization code.
        /// </summary>
        /// <param name="code">The authorization code obtained during the authentication process.</param>
        /// <param name="redirectUri">The redirect URI used during the authentication process.</param>
        /// <returns>A string containing the access token.</returns>
        [HttpGet]
        [Route("gettoken")]
        public async Task<IActionResult> GetAccessToken(string code, string redirectUri)
        {
            var result = await authService.GetAccessToken(code, redirectUri);

            return Ok(result);
        }


        // GET AUTH URL
        /// <summary>
        /// Gets the URL for the Auth0 authorization page.
        /// </summary>
        /// <param name="redirectUri">The redirect URI to use after the authentication process is completed.</param>
        /// <param name="state">An optional state parameter to include in the authorization URL.</param>
        /// <returns>A string containing the authorization URL.</returns>
        [HttpGet]
        [Route("getauthurl")]
        public IActionResult GetAuthorizationUrl(string redirectUri, string state)
        {
            var result = authService.GetAuthorizationUrl(redirectUri, state);

            return Ok(result);
        }


        // REVOKE TOKEN
        /// <summary>
        /// Revokes an access token.
        /// </summary>
        /// <param name="accessToken">The access token to revoke.</param>
        [HttpPost]
        [Route("revoketoken")]
        public IActionResult RevokeAccessToken(string accessToken)
        {
            var result = authService.RevokeAccessToken(accessToken);

            return Ok(result);
        }


        // RENEW TOKEN
        /// <summary>
        /// Renews an access token using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token used to renew the access token.</param>
        /// <returns>A string containing the renewed access token.</returns>
        [HttpPost]
        [Route("renewtoken")]
        public IActionResult RenewAccessToken(string refreshToken)
        {
            var result = authService.RevokeAccessToken(refreshToken);

            return Ok(result);
        }
    }
}