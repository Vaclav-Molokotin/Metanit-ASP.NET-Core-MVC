using Microsoft.AspNetCore.Mvc;

namespace MasterLayout.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public ActionResult Hello()
        {
            return PartialView();
        }
    }
}
