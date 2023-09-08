﻿using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
            // добавляем начальные данные при их отсутствии
            if (!_context.Companies.Any())
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
                User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
                User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
                User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
                User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

                _context.Companies.AddRange(oracle, microsoft, google, apple);
                _context.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                _context.SaveChanges();
            }
        }

        public IActionResult Index(int? company, string? name)
        {
            IQueryable<User> users = _context.Users.Include(p => p.Company);
            if(company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if(!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name!.Contains(name));
            }

            List<Company> companies = _context.Companies.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Company { Name = "Все", Id = 0 });

            UserListViewModel viewModel = new UserListViewModel
            {
                Users = users.ToList(),
                Companies = new SelectList(companies, "Id", "Name", company),
                Name = name,
            };

            return View(viewModel);
        }
    }
}
