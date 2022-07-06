using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Contracts;
using MediatR;
using RealEstate.CQRS.Queries;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IOrderService service;
        private readonly IMediator mediator;


        public ListingsController(
            IOrderService _service, 
            IMediator _mediator)
        {
            this.service = _service;
            this.mediator = _mediator;
        }

        [HttpGet("property")]
        public async Task<IActionResult> PropertyAsync(int propertyId)
        {
            try
            {
                await mediator.Send(new GetPropertyByIdQuery(propertyId));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
