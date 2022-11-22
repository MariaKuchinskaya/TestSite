using Microsoft.EntityFrameworkCore;
using EfWebTutorial.Models;    // пространство имен класса ApplicationContext
using EfWebTutorial.Repositories;
using EfWebTutorial.Interfaces;
using EfWebTutorial.Services;
using EfWebTutorial.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<StudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<GroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<FacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IFacultyService, FacultyService>();

var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
 