using AutoMarket.BusinessLogic.Implementations;
using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.DAL;
using AutoMarket.DAL.Interfaces;
using AutoMarket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Select}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
