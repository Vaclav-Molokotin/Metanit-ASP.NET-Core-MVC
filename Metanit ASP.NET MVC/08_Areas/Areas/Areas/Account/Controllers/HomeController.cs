using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Account.Controllers
{
    [Area("Account")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
