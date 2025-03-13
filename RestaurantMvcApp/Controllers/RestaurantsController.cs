using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMvcApp.Data;
using RestaurantMvcApp.Models;
using RestaurantMvcApp.Models.DTOs;
using RestaurantMvcApp.Models.ViewModels;

namespace RestaurantMvcApp.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantContext _context;

        public RestaurantsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var restaurant = _context.Restaurants.Include(r => r.TypeKitchen)
                .Where(r => r.IsDeleted == false);
            return View(await restaurant.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.TypeKitchen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            ViewData["TypeKitchenId"] = new SelectList(_context.TypeKitchens, "Id", "TypeName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RestaurantDTO restaurant, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                Restaurant createRestaurant = new Restaurant
                {
                    Name = restaurant.Name,
                    TypeKitchenId = restaurant.TypeKitchenId,
                    Address = restaurant.Address,
                    Telephone = restaurant.Telephone,
                    HourOfWork = restaurant.HourOfWork,
                };
                using(MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    createRestaurant.ImagePath = ms.ToArray();
                }
                _context.Add(createRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeKitchenId"] = new SelectList(_context.TypeKitchens, "Id", "Id", restaurant.TypeKitchenId);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            RestaurantDTO restaurantDTO = new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                TypeKitchenId = restaurant.TypeKitchenId,
                Address = restaurant.Address,
                Telephone = restaurant.Telephone,
                HourOfWork = restaurant.HourOfWork,
            };
            EditRestaurantVM restaurantVM = new EditRestaurantVM
            {
                Restaurant = restaurantDTO,
                Image = restaurant.ImagePath,
                TypeKitchens = new SelectList(_context.TypeKitchens, "Id", nameof(TypeKitchen.TypeName), restaurant.TypeKitchenId)
            };
           
            return View(restaurantVM);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,RestaurantDTO restaurant, IFormFile? photo)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Restaurant? editedRestaurant = await _context.Restaurants.FindAsync(id);
                if (editedRestaurant == null)
                    return NotFound();
                editedRestaurant.Name = restaurant.Name;
                editedRestaurant.TypeKitchenId = restaurant.TypeKitchenId;
                editedRestaurant.Address = restaurant.Address;
                editedRestaurant.Telephone = restaurant.Telephone;
                editedRestaurant.HourOfWork = restaurant.HourOfWork;

                if (photo != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        editedRestaurant.ImagePath = ms.ToArray();
                    }
                }

                try
                {
                    _context.Update(editedRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(editedRestaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            EditRestaurantVM editRestaurantVM = new EditRestaurantVM
            {
                Restaurant = restaurant,
                
                TypeKitchens = new SelectList(_context.TypeKitchens, "Id", nameof(TypeKitchen.TypeName), restaurant.TypeKitchenId)
            };
            //ViewData["TypeKitchenId"] = new SelectList(_context.TypeKitchens, "Id", "Id", restaurant.TypeKitchenId);
            return View(editRestaurantVM);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.TypeKitchen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
