using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Contracts;
using MediatR;
using RealEstate.CQRS.Queries;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("getEstate")]
        public async Task<IActionResult> GetEstateAsync(int estateId)
        {
            try
            {
                await mediator.Send(new GetEstateByIdQuery(estateId));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
