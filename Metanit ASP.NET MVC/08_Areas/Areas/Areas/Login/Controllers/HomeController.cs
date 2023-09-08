using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Login.Controllers
{
    [Area("Login")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Area = "Login";
            return View();
        }
    }
}
