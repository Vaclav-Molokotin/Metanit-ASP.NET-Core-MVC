var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "def",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
