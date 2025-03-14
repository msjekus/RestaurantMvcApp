using System.ComponentModel.DataAnnotations;

namespace RestaurantMvcApp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = default!;

        public int TypeKitchenId { get; set; }

        public TypeKitchen TypeKitchen { get; set; } = default!;
       
        public string Address { get; set; } = default!;
        
        public string Telephone { get; set; } = default!;
        
        public string HourOfWork { get; set; } = default!;

        public bool IsDeleted { get; set; }
        
        public byte[] ImagePath { get; set; } = default!;
    }
}
