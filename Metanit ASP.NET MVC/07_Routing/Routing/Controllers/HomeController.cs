using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    [Route("main")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("homepage")]
        public string Index() => "ASP.NET Core MVC on METANIT.COM";

        public IActionResult About() => Content("About us");
    }
}
