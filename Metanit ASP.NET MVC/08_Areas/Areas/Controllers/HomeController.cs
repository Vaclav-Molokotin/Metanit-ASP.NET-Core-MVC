using Microsoft.AspNetCore.Mvc;

namespace Areas.Controllers
{
    public class HomeController : Controller
    {
        public string Index() => "HomeController вне области";
    }
}
