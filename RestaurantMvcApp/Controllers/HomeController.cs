using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Data;
using RestaurantMvcApp.Models;
using RestaurantMvcApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMvcApp.Models.DTOs;
namespace RestaurantMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext context;
        private readonly IMapper mapper;

        public HomeController(RestaurantContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task <IActionResult> Index( string? search, int typeKitchenId = 0)
        {
            var typeKitchens = await context.TypeKitchens.ToArrayAsync();
            IQueryable<Restaurant> restaurans = context.Restaurants.Where(t => t.IsDeleted == false);
            if (typeKitchenId!= 0)
                restaurans = restaurans.Where(r => r.TypeKitchenId == typeKitchenId);
            if (search != null)
            {
                restaurans = restaurans.Where(r => r.Name.Contains(search));
            }
            var restaurantsList = restaurans.ToList();

            IndexVM indexVM = new IndexVM()
            {
                Restaurants = mapper.Map<IEnumerable<RestaurantDTO>>(restaurantsList),
                TypeKitchenId = typeKitchenId,
                Search = search,
                TypeKitchens = new SelectList(typeKitchens, "Id", "TypeName",typeKitchenId)
            };
            return View(indexVM);
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
