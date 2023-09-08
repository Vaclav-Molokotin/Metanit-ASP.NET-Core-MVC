using Microsoft.AspNetCore.Mvc;

namespace StronglyTypedHelpers.Controllers
{
    public class HomeController : Controller 
    {
        public IActionResult Index() { return View(); }
    }
}
