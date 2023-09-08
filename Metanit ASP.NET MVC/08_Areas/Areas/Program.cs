var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ������� ��� ������� login
app.MapAreaControllerRoute(
    name: "login_area",
    areaName: "login",
    pattern: "register/{controller=Home}/{action=Index}/{id?}");

// ��������� ��������� ������������, ������� ������������� � �������
app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// ��������� ��������� ��� ������������, ������� ������������� ��� �������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();