using Microsoft.AspNetCore.Mvc;

namespace fair.api.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
