var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITimeService, SimpleTimeService>();

var app = builder.Build();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();

public interface ITimeService
{
    public string GetCurrentTime { get; }
}

public class SimpleTimeService : ITimeService
{
    public string GetCurrentTime => $"Текущее время: {DateTime.Now}";
}