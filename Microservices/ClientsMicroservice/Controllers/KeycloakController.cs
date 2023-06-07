using Keycloak.AuthServices.Sdk.Admin;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.DTOs.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace ClientsMicroservice.Controllers
{
    // IKeycloakClient                      Unified HTTP client - IKeycloakRealmClient, IKeycloakProtectedResourceClient
    // IKeycloakRealmClient                 Keycloak realm API
    // IKeycloakProtectedResourceClient     Protected resource API
    // IKeycloakUserClient                  Keycloak user API
    // IKeycloakProtectionClient            Authorization server API, used by AddKeycloakAuthorization

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class KeycloakController : ControllerBase
    {
        private readonly IKeycloakClient _keycloakClient;

        // private readonly IKeycloakRealmClient _keycloakRealmClient;
        // private readonly IKeycloakProtectedResourceClient _keycloakProtectedResourceClient;
        // private readonly IKeycloakUserClient _keycloakUserClient;
        // private readonly IKeycloakProtectionClient _keycloakProtectionClient;

        private readonly IPublishEndpoint _publishEndpoint;

        private readonly ILogger<KeycloakController> _logger;


        public KeycloakController(
            IKeycloakClient keycloakClient,
            ILogger<KeycloakController> logger,
            IPublishEndpoint publishEndpoint)
        {
            _keycloakClient = keycloakClient ?? throw new ArgumentNullException(nameof(keycloakClient));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        // Add endpoints:
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> CreateUserInRealm(string realm, Keycloak.AuthServices.Sdk.Admin.Models.User user)
        {
            var createUserResult = await _keycloakClient.CreateUser(realm, user);

            if (createUserResult != null)
            {
                return NotFound(createUserResult);
            }
            return Ok(createUserResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> CreateResourceInRealm(string realm, Keycloak.AuthServices.Sdk.Admin.Models.Resource resource)
        {
            var resourceResult = await _keycloakClient.CreateResource(realm, resource);

            if (resourceResult != null)
            {
                return NotFound(resourceResult);
            }
            return Ok(resourceResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetAllUsersForRealm(string realm)
        {
            var allUsers = await _keycloakClient.GetUsers(realm);

            if(!allUsers.Any())
            {
                return NotFound(allUsers);
            }
            return Ok(allUsers);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetUserForRealm(string realm, string userId)
        {
            var user = await _keycloakClient.GetUser(realm, userId);

            if (user != null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetRealm(string realm)
        {
            var realmResult = await _keycloakClient.GetRealm(realm);

            if (realmResult != null)
            {
                return NotFound(realmResult);
            }
            return Ok(realmResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> GetResource(string realm, string resourceId)
        {
            var resourceResult = await _keycloakClient.GetResource(realm, resourceId);

            if (resourceResult != null)
            {
                return NotFound(resourceResult);
            }
            return Ok(resourceResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> SearchResourcesByName(string realm, string name)
        {
            var resourceResult = await _keycloakClient.SearchResourcesByName(realm, name);

            if (resourceResult != null)
            {
                return NotFound(resourceResult);
            }
            return Ok(resourceResult);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<IActionResult> UpdateUser(string realm, string userId, Keycloak.AuthServices.Sdk.Admin.Models.User user)
        {
            try
            {
                await _keycloakClient.UpdateUser(realm, userId, user);
                return Ok(user);
            } 
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(userId);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        //http://localhost:9001/api/
        //http://localhost:9000/api/clients/gethealth behind gateway
        public string getHealth()
        {
            if (_keycloakClient != null)
            {
                return "Keycloak Client up and running";
            }
            return "Keycloak Client not started";
        } 
    }
}
