using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands;
using RealEstate.Filters;

namespace RealEstate.Controllers
{
    [Authorize]
    [AjaxFilter]
    public class NotificationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePropertyByIdCommand command)
        {
            await this.Mediator.Send(command);
            return this.Ok();
        }
    }
}