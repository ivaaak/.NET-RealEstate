using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.CQRS.Commands;
using RealEstate.Infrastructure.Entities.Estates;

namespace RealEstate.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstateController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateEstate(Estate estate)
        {
            await Mediator.Send(new CreateEstateCommand(estate));

            //redirect to the wanted page
            return RedirectToAction(nameof(Estate));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEstate(int estateId)
        {
            await Mediator.Send(new DeletePropertyByIdCommand(estateId));

            //redirect to the wanted page
            return RedirectToAction(nameof(Estate));
        }
    }
}