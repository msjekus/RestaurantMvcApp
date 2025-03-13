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
        [HttpPost]
        //[IgnoreAntiforgeryToken]
        
        public async Task<IActionResult> Create(TypeKitchen typeKitchen) 
        {
            if (!ModelState.IsValid)
                return View(typeKitchen);
            context.TypeKitchens.Add(typeKitchen);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
                return NotFound();
                TypeKitchen? typeKitchen=await context.TypeKitchens.FindAsync(id.Value);
            if (typeKitchen == null)
                return NotFound();
            return View(typeKitchen);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(TypeKitchen typeKitchen)
        {
            if (!ModelState.IsValid)
                return View(typeKitchen);
            TypeKitchen? typeKitchen1=await context.TypeKitchens.FindAsync(typeKitchen.Id);
            if(typeKitchen1 == null)
                return NotFound();
            typeKitchen1.TypeName = typeKitchen.TypeName;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            TypeKitchen? typeKitchen = await context.TypeKitchens.FindAsync(id.Value);
            if (typeKitchen == null)
                return NotFound();
            return View(typeKitchen);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id == null)
                return NotFound();
            TypeKitchen? typeKitchen = await context.TypeKitchens.FindAsync(id.Value);
            if (typeKitchen == null)
                return NotFound();
            context.TypeKitchens.Remove(typeKitchen);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            TypeKitchen? typeKitchen = await context.TypeKitchens.FindAsync(id.Value);
            if (typeKitchen == null)
                return NotFound();
            return View(typeKitchen);
        }
    }
}
