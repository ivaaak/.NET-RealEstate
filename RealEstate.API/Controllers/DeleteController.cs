using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Filters;
using RealEstate.CQRS.Commands.Delete;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [AjaxFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : BaseController
    {
        /// <summary>
        /// Delete estate by Id
        /// </summary>
        /// <param name="estateId"></param>
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