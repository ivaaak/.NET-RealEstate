using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands;
using RealEstate.Web.Filters;

namespace RealEstate.Web.Controllers
{
    [Authorize]
    [AjaxFilter]
    public class NotificationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePropertyByIdCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}