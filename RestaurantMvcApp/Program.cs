using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Data;

var builder = WebApplication.CreateBuilder(args);
string connStr= builder.Configuration.GetConnectionString("MSSqlRestaurant")??
    throw new InvalidOperationException("You should specify conn string!" );
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(connStr));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TypeKitchens}/{action=Index}/{id?}");

app.Run();
