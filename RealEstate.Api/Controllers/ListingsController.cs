using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Contracts;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IOrderService service;

        public ListingsController(IOrderService _service)
        {
            service = _service;
        }

        [HttpGet("place")]
        public IActionResult PlaceOrder(string propertyId)
        {
            try
            {
                //await service.FindPropertyListing(propertyId);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
