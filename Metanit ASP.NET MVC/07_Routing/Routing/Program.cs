var builder = WebApplication.CreateBuilder(args);

// добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id}");
app.MapControllerRoute(name: "name_age", pattern: "{controller}/{action}/{name}/{age}");
app.Run();