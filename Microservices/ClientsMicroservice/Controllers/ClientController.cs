using ClientsMicroservice.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Shared.Models.Entities.Clients;
using Swashbuckle.AspNetCore.Annotations;

namespace ClientsMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        private readonly IPublishEndpoint _publishEndpoint;

        private readonly ILogger<ClientController> _logger;


        public ClientController(
            IClientService clientService, 
            IPublishEndpoint publishEndpoint,
            ILogger<ClientController> logger)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        // GET all clients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Client>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public ActionResult<List<Client>> GetAllClients()
        {
            var clients = _clientService.GetAllClients();

            if (clients.Count == 0)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // GET a client
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public ActionResult<Client> GetClientById(string clientId)
        {
            var client = _clientService.GetClientById(clientId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST add client
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Client))]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<ActionResult<Client>> AddClient([FromBody] Client client)
        {
            var addedClient = await _clientService.AddClient(client);

            return CreatedAtAction(nameof(GetClientById), new { clientId = addedClient.Id }, addedClient);
        }

        // PUT update client
        [HttpPut("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<ActionResult<Client>> UpdateClient(string clientId, [FromBody] Client client)
        {
            if (!await _clientService.ClientExists(clientId))
            {
                return NotFound();
            }

            var updatedClient = _clientService.UpdateClient(client);

            return Ok(updatedClient);
        }

        // DELETE delete client
        [HttpDelete("{clientId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [SwaggerOperation("This method can be used by an authorized user.")]
        public async Task<ActionResult> DeleteClient(string clientId)
        {
            if (!await _clientService.ClientExists(clientId))
            {
                return NotFound();
            }

            await _clientService.SoftDeleteClient(clientId);

            return NoContent();
        }
    }
}
