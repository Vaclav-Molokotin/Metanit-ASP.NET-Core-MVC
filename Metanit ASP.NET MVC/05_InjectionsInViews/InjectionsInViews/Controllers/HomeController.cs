using Microsoft.AspNetCore.Mvc;

namespace InjectionsInViews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        { return View(); }
    }
}
