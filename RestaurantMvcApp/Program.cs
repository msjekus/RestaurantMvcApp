using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Data;
using RestaurantMvcApp.Pifiles;

var builder = WebApplication.CreateBuilder(args);
string connStr= builder.Configuration.GetConnectionString("SomeeRestaurant") ??
//string connStr= builder.Configuration.GetConnectionString("MSSqlRestaurant")??
    throw new InvalidOperationException("You should specify conn string!" );
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(connStr));
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(RestourantProfile), typeof(TypeKitchenProfile));
var app = builder.Build();
using (var scope =app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;
    await RestaurantsSeeder.SeeedData(serviceProvider, app.Environment);
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
