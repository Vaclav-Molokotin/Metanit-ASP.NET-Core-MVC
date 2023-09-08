using BindManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindManagement.Controllers
{
	public class HomeController : Controller
	{
		public string AddUser(User user)
		{
			if (ModelState.IsValid)
			{
				return $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
			}
			string errors = $"Количество ошибок: {ModelState.ErrorCount}. Ошибки в свойствах: ";
			foreach (var prop in ModelState.Keys)
			{
				errors = $"{errors}{prop}; ";
			}
			return errors;
		}
	}
}
