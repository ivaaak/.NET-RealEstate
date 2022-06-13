using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
