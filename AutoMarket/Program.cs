using AutoMarket.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
