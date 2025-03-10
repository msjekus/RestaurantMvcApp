using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Data;
using RestaurantMvcApp.Models;

namespace RestaurantMvcApp.Controllers
{
    public class TypeKitchensController : Controller
    {
        private readonly RestaurantContext context;

        public TypeKitchensController(RestaurantContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<TypeKitchen> typeKitchens = context.TypeKitchens;
            List<TypeKitchen> typeKitchens1 = await typeKitchens.ToListAsync();
            return View(typeKitchens1);
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(TypeKitchen typeKitchen) 
        {
            if (!ModelState.IsValid)
                return View(typeKitchen);
            context.TypeKitchens.Add(typeKitchen);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
    }
}
