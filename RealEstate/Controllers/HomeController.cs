using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RealEstate.Core.Constants;
using RealEstate.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace RealEstate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly IDistributedCache cache;

        public HomeController(
            ILogger<HomeController> _logger,
            IDistributedCache _cache)
        {
            this.logger = _logger;
            this.cache = _cache;
        }

        public IActionResult Index()
        {
            ViewData[MessageConstant.SuccessMessage] = "Welcome to the experience!";

            return View();
        }

        public ActionResult Privacy()
        {
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