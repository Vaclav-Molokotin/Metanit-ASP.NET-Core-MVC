using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationOnServer_2.Models;

namespace ModelValidationOnServer_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(Person person)
        {
            if(person.Name != null)
            {
                person.Name = person.Name.Trim();
            }

            if (person.Age < 18 || person.Age > 100)
                ModelState.AddModelError("person.Age", "Возраст должен находится в диапазоне от 18 до 100");

            if (string.IsNullOrEmpty(person.Name))
                ModelState.AddModelError("person.Name", "Поле Имя должно быть заполнено");
            else if (person.Name?.Length < 3)
                ModelState.AddModelError("person.Name", "Недопустимая длина строки. Имя должно быть не менее 3 символов");

            if (ModelState.IsValid)
                return $"{person.Name} - {person.Age}";

            string errorMessages = "";

            // проходим по всем элементам в ModelState
            foreach (var item in ModelState)
            {
                // Если элемент не прошел валидацию - проходим по всем его ошибкам
                if(item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages += $"\nОшибки свойства {item.Key}\n";
                    // проходим по всем ошибкам
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages += $"{error.ErrorMessage}\n";
                    }
                }
            }

            return errorMessages;
        }
    }
}
