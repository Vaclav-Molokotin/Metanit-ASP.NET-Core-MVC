using Microsoft.AspNetCore.Mvc;

namespace ViewComponentContext.Components
{
    public class UsersListViewComponent : ViewComponent
    {
        List<string> users = new()
        {
            "Tom", "Tim", "Bob", "Sam", "Alice", "Kate"
        };

        public IViewComponentResult Invoke()
        {
            int number = users.Count;
            // если передан параметр number
            if(Request.Query.ContainsKey("number"))
            {
                int.TryParse(Request.Query["number"], out number);
            }

            if(number > users.Count)
            {
                number = users.Count;
            }

            ViewBag.Users = users.Take(number);
            ViewData["Header"] = $"Количество пользователей: {number}.";
            return View();
        }
    }
}
