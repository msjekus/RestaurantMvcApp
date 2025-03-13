using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMvcApp.Models.DTOs;

namespace RestaurantMvcApp.Models.ViewModels
{
    public class EditRestaurantVM
    {
        public RestaurantDTO Restaurant { get; set; }=default!;

        public SelectList TypeKitchens { get; set; } = default!; 
        public byte[]? Image { get; set; }
    }
}
