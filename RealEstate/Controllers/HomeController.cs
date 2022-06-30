using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RealEstate.Core.Constants;
using RealEstate.Models;
using Microsoft.Extensions.Caching.Distributed;
using MediatR;
using RealEstate.CQRS.Queries;

namespace RealEstate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly IDistributedCache cache;

        private readonly IMediator mediator;

        public HomeController(
            ILogger<HomeController> _logger,
            IDistributedCache _cache,
            IMediator _mediator)
        {
            this.logger = _logger;
            this.cache = _cache;
            this.mediator = _mediator;
        }

        public IActionResult Index()
        {
            ViewData[MessageConstant.SuccessMessage] = "Welcome to the experience!";

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var peopleList = await mediator.Send(new GetPersonListQuery());

            return View();
        }

        public IActionResult Listings()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}