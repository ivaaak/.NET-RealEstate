using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Web.Controllers
{
    [Authorize]
    public class PropertyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProperty(Property property)
        {
            await Mediator.Send(new CreatePropertyCommand(property));

            //redirect to the wanted page
            return RedirectToAction(nameof(Property));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            await Mediator.Send(new DeletePropertyByIdCommand(propertyId));

            //redirect to the wanted page
            return RedirectToAction(nameof(Property));
        }
    }
}