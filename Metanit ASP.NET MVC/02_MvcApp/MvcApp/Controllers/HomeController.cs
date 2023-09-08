using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ITimeService _timeService;

        public HomeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        /// <summary>
        /// Подключение сервиса в метод
        /// </summary>
        /// <param name="timeService"></param>
        /// <returns></returns>
        public string GetTime([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }


        /// <summary>
        /// Начальная страница (прописано в файле program.cs)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Title = "Metanit";
            ViewData["Message"] = "Hello";
            ViewData["Person"] = new Person("Tom", 34);

            List<string> nums = new List<string>
            {
                "Раз",
                "Два",
                "Три",
                "Четыре"
            };
            return View(nums);
        }

        #region dependencyInjection

        #endregion

        #region Files Отправка файлов с сервера
        /// <summary>
        /// Возвращает файл по физическому пути
        /// </summary>
        /// <returns></returns>
        public IActionResult GetFile()
        {
            // путь к файлу
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/Files/hello.txt");

            // тип файла
            string fileType = "text/plain";

            // имя файла (необязательно)
            string fileName = "hello.txt";

            return PhysicalFile(filePath, fileType, fileName);
        }

        /// <summary>
        /// Возвращает файл по виртуальному пути.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetVirtualFile()
        {
            return File("Files/Hello.txt", "text/plain", "hello4.txt");
        }

        #endregion

        #region forms Работа с формой

        /// <summary>
        /// Возвращает данные объекта человека
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FillPersonInfo(string name = "", int age = 0)
        {
            if (string.IsNullOrEmpty(name) || age == 0)
                return Json(new Person("Tom", 83));
            return Json(new Person(name, age));
        }

        /// <summary>
        /// Выводит форму для заполнения информации о человеке
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task FillPersonInfo()
        {
            string html =
                "<form method='post'>" +
                "<label>Имя:</label>" +
                "<input name='name'/>" +
                "<label>Возраст:</label>" +
                "<input name='age'/>" +
                "<input type='submit'/>" +
                "</form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(html);
        }

        #endregion

        #region redirect
        public IActionResult About()
        {
            return Redirect("~/Home/Contact");
        }

        public IActionResult Contact()
        {
            return Content("Hello!");
        }
        #endregion
    }
    public record class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        { 
            Name = name;
            Age = age;
        }
    }
}
