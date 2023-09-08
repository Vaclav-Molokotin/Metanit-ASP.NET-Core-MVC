using AttributesOfValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AttributesOfValidation.Controllers
{
    public class Home : Controller
    {
        public IActionResult CheckEmail(string email)
        {
            if (email == "admin@mail.ru" || email == "aaa@gmail.com")
                return Json(false);
            return Json(true);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (person.Name == "admin")
                ModelState.AddModelError("Name", "admin - запрещенное имя.");

            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Age}");
            return View(person);
        }
    }
}
