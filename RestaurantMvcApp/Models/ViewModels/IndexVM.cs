using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMvcApp.Models.DTOs;

namespace RestaurantMvcApp.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<RestaurantDTO> Restaurants { get; set; } = default!;
        public SelectList TypeKitchens { get; set; } = default!;

        public string? Search { get; set; }= default!;
        public int TypeKitchenId { get; set; }
    }
}
