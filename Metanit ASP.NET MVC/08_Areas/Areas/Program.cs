var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// маршрут для области login
app.MapAreaControllerRoute(
    name: "login_area",
    areaName: "login",
    pattern: "register/{controller=Home}/{action=Index}/{id?}");

// добавляем поддержку контроллеров, которые располагаются в области
app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// добавляем поддержку для контроллеров, которые располагаются вне области
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();