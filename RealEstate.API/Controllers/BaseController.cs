using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.API.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        //register services?

        private IMediator? mediator;

        protected IMediator Mediator
            => mediator
            ?? (mediator = HttpContext
                            .RequestServices
                            .GetService<IMediator>());
    }
}
