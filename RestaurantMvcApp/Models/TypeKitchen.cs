using System.ComponentModel.DataAnnotations;

namespace RestaurantMvcApp.Models
{
    public class TypeKitchen
    {
        public int Id { get; set; }
       
        public string TypeName { get; set; } = default!;

        public ICollection<Restaurant> Restaurants { get; set; } = default!;
    }
}
