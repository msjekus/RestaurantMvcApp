using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Models;

namespace RestaurantMvcApp.Data
{
    public static class RestaurantsSeeder
    {
        public static async Task SeeedData(IServiceProvider provider,
            IWebHostEnvironment environment)
        {
            DbContextOptions<RestaurantContext> options = provider
                .GetRequiredService<DbContextOptions<RestaurantContext>>();
            using (RestaurantContext context = new RestaurantContext(options))
            {
                if (!context.TypeKitchens.Any())
                {
                    TypeKitchen typeKitchen1 = new TypeKitchen
                    {
                        TypeName = "Італійська"
                    };
                    TypeKitchen typeKitchen2 = new TypeKitchen
                    {
                        TypeName = "Грузинська"
                    };
                    TypeKitchen typeKitchen3 = new TypeKitchen
                    {
                        TypeName = "Українська"
                    };
                    TypeKitchen typeKitchen4 = new TypeKitchen
                    {
                        TypeName = "Японська"
                    };
                    await context.TypeKitchens.AddRangeAsync(typeKitchen1, typeKitchen2, typeKitchen3, typeKitchen4);
                    string webRootPath = environment.WebRootPath;
                    string filePath1 =$"{webRootPath}/images/1.jpg";
                    string filePath2 =$"{webRootPath}/images/3.jpg";
                    string filePath3 =$"{webRootPath}/images/kobe.jpg";
                    byte[] image1 = File.ReadAllBytes(filePath1);
                    byte[] image2 = File.ReadAllBytes(filePath2);
                    byte[] image3 = File.ReadAllBytes(filePath3);
                    Restaurant restaurant1 = new Restaurant
                    {
                        Name = "La Famiglia",
                        TypeKitchen = typeKitchen1,
                        Address = "м.Подільськ,пр-кт. Перемоги 12",
                        Telephone = "0994597382",
                        HourOfWork = "10:00-22:00",
                        ImagePath = image1
                    };
                    Restaurant restaurant2 = new Restaurant
                    {
                        Name = "Корчма ДЕДА",
                        TypeKitchen = typeKitchen3,
                        Address = "м.Подільськ,вул. Бочковича 2",
                        Telephone = "0486256505",
                        HourOfWork = "09:30-23:00",
                        ImagePath = image2
                    };
                    Restaurant restaurant3 = new Restaurant
                    {
                        Name = "Кобе",
                        TypeKitchen = typeKitchen4,
                        Address = "м.Одеса,вул.Ланжеронівська, 9",
                        Telephone = "0487269806",
                        HourOfWork = "09:00-22:00",
                        ImagePath = image3
                    };
                    await context.Restaurants.AddRangeAsync(restaurant1, restaurant2, restaurant3);
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
