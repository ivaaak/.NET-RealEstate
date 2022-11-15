using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private IMediator? mediator;

        protected IMediator Mediator
            => mediator
            ?? (mediator = HttpContext
                           .RequestServices
                           .GetService<IMediator>());
    }
}
