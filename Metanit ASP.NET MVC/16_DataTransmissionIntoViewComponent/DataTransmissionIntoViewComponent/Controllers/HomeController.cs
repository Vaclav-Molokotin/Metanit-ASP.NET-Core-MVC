using DataTransmissionIntoViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTransmissionIntoViewComponent.Controllers
{
    public class HomeController : Controller
    {
        List<Person> list;

        public IActionResult Index()
        {
            fillListOfPersons();
            return View(list);
        }

        private void fillListOfPersons()
        {
            list = new List<Person>
            {
                new Person { Id = 1, Name = "John", BirthDate = DateTime.Parse("01.02.2001")},
                new Person { Id = 2, Name = "Smith", BirthDate = DateTime.Parse("28.01.2010")},
                new Person { Id = 3, Name = "Jimm", BirthDate = DateTime.Parse("5.06.1998")},
                new Person { Id = 4, Name = "Skot", BirthDate = DateTime.Parse("2.12.1002")},
                new Person { Id = 5, Name = "Skyler", BirthDate = DateTime.Parse("10.12.2001")},
                new Person { Id = 6, Name = "Loaf", BirthDate = DateTime.Parse("30.11.2004")},
                new Person { Id = 7, Name = "Pablo", BirthDate = DateTime.Parse("20.07.2008")}
            };
        }
    }
}
