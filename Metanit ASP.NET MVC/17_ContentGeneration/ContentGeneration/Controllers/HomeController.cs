using Microsoft.AspNetCore.Mvc;

namespace ContentGeneration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
