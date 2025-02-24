using System.Data;
using System.Threading.Tasks.Dataflow;
using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//IoC Controller
var connectionString = "server=(localdb)\\mssqllocaldb;database=BooksAppDB;trusted_connection=true;";
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthorsService, AuthorService>();

builder.Services.AddScoped<IService<Book, BookModel>, BookService>();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
