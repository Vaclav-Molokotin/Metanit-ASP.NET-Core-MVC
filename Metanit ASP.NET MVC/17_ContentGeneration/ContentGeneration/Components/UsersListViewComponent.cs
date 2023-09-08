using Microsoft.AspNetCore.Mvc;

namespace ContentGeneration.Components
{
    public class UsersListViewComponent : ViewComponent
    {
        List<string> users = new List<string>
        {
            "Tom", "Tim", "Bob", "Sam"
        };

        public IViewComponentResult Invoke()
        {
            return View(users);
        }
    }
}
