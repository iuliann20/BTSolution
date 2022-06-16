using BTSolution.BL.Classes;
using BTSolution.BL.Interfaces;
using BTSolution.DAL;
using BTSolution.DAL.Repository.Classes;
using BTSolution.DAL.Repository.Interfaces;
using BTSolution.Helpers.Classes;
using BTSolution.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:44404");
                      });
});
// Add services to the container.

builder.Services.AddControllersWithViews();
string connectionString = "Server=localhost; Database=BTSolution; Trusted_Connection=True; MultipleActiveResultSets=true";
builder.Services.AddDbContext<BTSolutionDbContext>(options => options.UseSqlServer(connectionString));

//repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAccessTokenRepository, AccessTokenRepository>();
//logic
builder.Services.AddTransient<ITokenLogic, TokenLogic>();
builder.Services.AddTransient<IUserLogic, UserLogic>();
//helper
builder.Services.AddTransient<IUserControllerHelper, UserControllerHelper>();
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
app.UseCors(MyAllowSpecificOrigins);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
