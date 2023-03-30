using Azure.Core;
using ClientsMicroservice.Authentication.Contracts;
using Elasticsearch.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Identity;
using System.Net;

namespace ClientsMicroservice.Controllers
{
    [Authorize]
    //[AjaxFilter]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")] // api/auth/
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMediator? _mediator;

        private readonly ILogger<AuthController> _logger;

        private readonly IAuth0Service _authService;

        public AuthController(
            IUserService service,
            IAuth0Service authService,
            IMediator mediator,
            ILogger<AuthController> logger)
        {
            _userService = service ?? throw new ArgumentNullException(nameof(service));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        }


        // GET USER INFO
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <param name="accessToken">The access token obtained during the authentication process.</param>
        /// <returns>An <see cref="ApplicationUser"/> object containing information about the authenticated user.</returns> 
        [HttpGet]
        [Route("getuser")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetUserInfo(string accessToken)
        {
            var result = await _authService.GetUserInfo(accessToken);

            if (result == null)
            {
                _logger.LogError($"User with the token: {accessToken}, not found.");
                return NotFound();
            }

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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAccessToken(string code, string redirectUri)
        {
            var result = await _authService.GetAccessToken(code, redirectUri);

            if (result == null)
            {
                _logger.LogError($"Couldnt get the access token from code: {code} and redirectUri: {redirectUri}.");
                return NotFound();
            }

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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public IActionResult GetAuthorizationUrl(string redirectUri, string state)
        {
            var result = _authService.GetAuthorizationUrl(redirectUri, state);

            if (result == null)
            {
                _logger.LogError($"Couldnt get the AuthorizationUrl from redirectUri: {redirectUri} and state: {state}.");
                return NotFound();
            }

            return Ok(result);
        }


        // REVOKE TOKEN
        /// <summary>
        /// Revokes an access token.
        /// </summary>
        /// <param name="accessToken">The access token to revoke.</param>
        [HttpPost]
        [Route("revoketoken")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public IActionResult RevokeAccessToken(string accessToken)
        {
            var result = _authService.RevokeAccessToken(accessToken);

            if (result == null)
            {
                _logger.LogError($"Couldnt Revoke Access Token {accessToken}.");
                return NotFound();
            }

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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
        public IActionResult RenewAccessToken(string refreshToken)
        {
            var result = _authService.RenewAccessToken(refreshToken);


            if (result == null)
            {
                _logger.LogError($"Couldnt Renew Access Token {refreshToken}.");
                return NotFound();
            }

            return Ok(result);
        }
    }
}