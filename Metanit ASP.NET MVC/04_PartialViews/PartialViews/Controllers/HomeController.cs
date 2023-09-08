using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace PartialViews.Controllers
{
    public class HomeController :Controller
    {
        public IActionResult Index()
        {
            StringBuilder content = new StringBuilder("Hel lo");
            return View(content);
        }

        public IActionResult Hello()
        {
            Random rand = new Random();
            return PartialView(rand.Next(0, 10));
        }
    }
}
