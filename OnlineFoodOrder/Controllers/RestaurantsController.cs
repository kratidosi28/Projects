using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Context;
using OnlineFoodOrder.Model;

namespace OnlineFoodOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly Mastercontext _context;

        public RestaurantsController(Mastercontext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurants>>> Getrestaurants()
        {
            return await _context.restaurants.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurants>> GetRestaurants(int id)
        {
            var restaurants = await _context.restaurants.FindAsync(id);

            if (restaurants == null)
            {
                return NotFound();
            }

            return restaurants;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurants(int id, Restaurants restaurants)
        {
            if (id != restaurants.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(restaurants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restaurants>> PostRestaurants(Restaurants restaurants)
        {
            _context.restaurants.Add(restaurants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurants", new { id = restaurants.RestaurantId }, restaurants);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurants>> DeleteRestaurants(int id)
        {
            var restaurants = await _context.restaurants.FindAsync(id);
            if (restaurants == null)
            {
                return NotFound();
            }

            _context.restaurants.Remove(restaurants);
            await _context.SaveChangesAsync();

            return restaurants;
        }

        private bool RestaurantsExists(int id)
        {
            return _context.restaurants.Any(e => e.RestaurantId == id);
        }
    }
}
