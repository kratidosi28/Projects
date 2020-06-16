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
    public class VCategoriesController : ControllerBase
    {
        private readonly Mastercontext _context;

        public VCategoriesController(Mastercontext context)
        {
            _context = context;
        }

        // GET: api/VCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VCategories>>> GetVCategories()
        {
            return await _context.VCategories.ToListAsync();
        }
    
        // GET: api/VCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VCategories>> GetVCategories(int id, VCategories vCategories)
        {
            var getCode =  await _context.VCategories.Where(p => p.RestaurantId == vCategories.RestaurantId).ToListAsync();
            return Ok(getCode);

           
        }
        //var vCategories = await _context.VCategories.FindAsync(id);
        // PUT: api/VCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVCategories(int id, VCategories vCategories)
        {
            if (id != vCategories.FoodItemId)
            {
                return BadRequest();
            }

            _context.Entry(vCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VCategoriesExists(id))
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

        // POST: api/VCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VCategories>> PostVCategories(VCategories vCategories)
        {
            /* _context.VCategories.Add(vCategories);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetVCategories", new { id = vCategories.FoodItemId }, vCategories);*/
            var getCode = await _context.VCategories.Where(p => p.RestaurantId == vCategories.RestaurantId).ToListAsync();
            return Ok(getCode);

        }

        // DELETE: api/VCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VCategories>> DeleteVCategories(int id)
        {
            var vCategories = await _context.VCategories.FindAsync(id);
            if (vCategories == null)
            {
                return NotFound();
            }

            _context.VCategories.Remove(vCategories);
            await _context.SaveChangesAsync();

            return vCategories;
        }

        private bool VCategoriesExists(int id)
        {
            return _context.VCategories.Any(e => e.FoodItemId == id);
        }
    }
}
