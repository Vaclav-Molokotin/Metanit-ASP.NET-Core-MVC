﻿using Microsoft.AspNetCore.Mvc;

namespace ViewComponentContext.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index() { return View(); }
    }
}
