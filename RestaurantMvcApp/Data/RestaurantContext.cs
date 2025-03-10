using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Models;

namespace RestaurantMvcApp.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : 
            base(options){
            //Database.EnsureCreated();
        }

        public DbSet<TypeKitchen> TypeKitchens { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
