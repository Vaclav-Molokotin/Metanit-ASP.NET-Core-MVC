using Microsoft.AspNetCore.Mvc;

namespace TagHelperCreation.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
