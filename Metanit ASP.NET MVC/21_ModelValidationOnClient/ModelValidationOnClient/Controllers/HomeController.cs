using Microsoft.AspNetCore.Mvc;
using ModelValidationOnClient.Models;

namespace ModelValidationOnClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { return View(); }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Age}");
            return View(person);
        }
    }
}
