using Microsoft.AspNetCore.Mvc;
using ViewEngineCreation.Utils;

var builder = WebApplication.CreateBuilder(args);

// добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();

// устанавливаем движок представлений
builder.Services.Configure<MvcViewOptions>(options => {
    options.ViewEngines.Clear();
    options.ViewEngines.Insert(0, new CustomViewEngine());
});

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();