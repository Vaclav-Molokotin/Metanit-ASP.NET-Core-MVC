using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();  // добавл€ем поддержку контроллеров с предствалени€ми
builder.Services.AddTransient<ITimeService, SimpleTimeService>(); // добавл€ем сервис ITimeService

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public interface ITimeService
{
	string Time { get; }
}
public class SimpleTimeService : ITimeService
{
	public string Time => DateTime.Now.ToString("hh:mm:ss");
}