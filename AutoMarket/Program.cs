using AutoMarket.BusinessLogic.Implementations;
using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.DAL;
using AutoMarket.DAL.Interfaces;
using AutoMarket.DAL.Repositories;
using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IBaseRepository<Car>, CarRepository>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//DefaultFilesOptions options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("index.html");
//app.UseDefaultFiles(options);

app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
