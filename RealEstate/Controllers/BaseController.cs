using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
