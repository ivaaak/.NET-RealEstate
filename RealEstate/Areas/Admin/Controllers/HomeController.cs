using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
