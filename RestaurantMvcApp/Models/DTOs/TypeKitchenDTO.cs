using System.ComponentModel.DataAnnotations;

namespace RestaurantMvcApp.Models.DTOs
{
    public class TypeKitchenDTO
    {
        public int Id { get; set; }
        [Display(Name = "Тип кухні")]
        public string TypeName { get; set; } = default!;

        public ICollection<RestaurantDTO>? Restaurants { get; set; }
    }
}
