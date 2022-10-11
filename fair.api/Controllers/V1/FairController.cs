using Microsoft.AspNetCore.Mvc;

namespace fair.api.Controllers.V1
{
    public class FairController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
