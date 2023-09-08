using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
		List<Company> companies;
		List<Person> people;

		/// <summary>
		/// Конструктор. Имитация выгрузки данных из базы данных
		/// </summary>
		public HomeController()
		{
			companies = new List<Company>
			{
				new Company(0, "Microsoft", "USA"),
				new Company(1, "HP", "USA"),
				new Company(2, "GazProm", "Russia"),
				new Company(3, "Blob", "Comboja")
			};

			people = new List<Person>
			{
				new Person(1, "Tom", 37, companies[1]),
				new Person(2, "Bob", 41, companies[2]),
				new Person(3, "Lut", 28, companies[1]),
				new Person(4, "Opa", 28, companies[3]),
				new Person(5, "Maj", 28, companies[2]),
				new Person(6, "Geg", 28, companies[2])
			};
		}

		
        public IActionResult Index(string companyName = "")
        {
			List<CompanyModel> companyModels = new List<CompanyModel>();
			List<Person> personsList = new List<Person>();

			// формируем список CompanyModels из Companies
			foreach (Company company in companies)
			{
				companyModels.Add(new(Id: company.Id, Name: company.Name));
			}

			// Если параметр поиска пустой - добавляем все компании
			if (string.IsNullOrEmpty(companyName))
			{
				foreach (Person person in people)
				{
					personsList.Add(person);
				}
			}

			// Иначе добавляем по условию
			else
			{
				foreach (Person person in people)
				{
					if (person.Work.Name == companyName)
						personsList.Add(person);
				}
			}			
			
			// Создаём модель и задаём ее свойства
			IndexViewModel model = new IndexViewModel();
			model.People = personsList;
			model.Companies = companyModels;
			
			// передаём модель в представление
			return View(model);
        }
    }
}
