using Microsoft.AspNetCore.Mvc;

namespace ViewComponentDefinition.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
