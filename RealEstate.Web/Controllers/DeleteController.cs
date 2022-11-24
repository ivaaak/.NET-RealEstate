using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands;
using RealEstate.API.Filters;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : BaseController
    {
        /// <summary>
        /// Delete property by Id
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePropertyByIdCommand command)
        {
            var deleteRequest = await Mediator.Send(command);

            if (deleteRequest.Errors is null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}