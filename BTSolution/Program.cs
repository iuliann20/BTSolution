using BTSolution.DAL;
using BTSolution.DAL.Repository.Classes;
using BTSolution.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
string connectionString = "Server=localhost; Database=BTSolution; Trusted_Connection=True; MultipleActiveResultSets=true";
builder.Services.AddDbContext<BTSolutionDbContext>(options => options.UseSqlServer(connectionString));

//repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAccessTokenRepository, AccessTokenRepository>();
//logic

//helper
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
