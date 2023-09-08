using BindModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindModel.Controllers
{
	public class HomeController : Controller
	{
		static List<Event> events = new List<Event>();
		public IActionResult Index()
		{
			return View(events);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Event myEvent)
		{
			//myEvent.Id = Guid.NewGuid().ToString();	эта строка больше не нужна, потому что ID генерируется в провайдере модели
			events.Add(myEvent);
			return RedirectToAction("Index");
		}
	}
}
