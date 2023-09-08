using HtmlHelpersToForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HtmlHelpersToForm.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public string Create(string name, int age) => $"{name} - {age}";

        public IActionResult Add()
        {
            var Users = new List<User>
            {
                new User(1, "Tom", 37),
                new User(2, "Alice", 33),
                new User(3, "Sam", 28),
                new User(4, "Bob", 41),
            };
            ViewBag.Users = new SelectList(Users, "Id", "Name");
            return View();
        }

        public IActionResult ChooseTimeOfDay() => View();
    }
}
