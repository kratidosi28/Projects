using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Context;
using OnlineFoodOrder.Model;

namespace OnlineFoodOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SFoodListsController : ControllerBase
    {
        private readonly Mastercontext _context;

        public SFoodListsController(Mastercontext context)
        {
            _context = context;
        }

        // GET: api/SFoodLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodList>>> GetFoodList()
        {
            return await _context.FoodList.ToListAsync();
        }

        // GET: api/SFoodLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodList>> GetFoodList(int id)
        {
            var foodList = await _context.FoodList.FindAsync(id);

            if (foodList == null)
            {
                return NotFound();
            }

            return foodList;
        }

        // PUT: api/SFoodLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodList(int id, FoodList foodList)
        {
            if (id != foodList.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(foodList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodListExists(id))
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

        // POST: api/SFoodLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodList>> PostFoodList(FoodList foodList)
        {
             _context.FoodList.Add(foodList);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetFoodList", new { id = foodList.FoodId }, foodList);
           /* var data = _context.Database.ExecuteSqlCommand("spTotalPrice @Quantity, @FoodId",
            new SqlParameter("@Quantity",foodList.Quantity),
                new SqlParameter("@FoodId", foodList.FoodId)
             );

            return Ok(data);*/
            
        }

        // DELETE: api/SFoodLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodList>> DeleteFoodList(int id)
        {
            var foodList = await _context.FoodList.FindAsync(id);
            if (foodList == null)
            {
                return NotFound();
            }

            _context.FoodList.Remove(foodList);
            await _context.SaveChangesAsync();

            return foodList;
        }

        private bool FoodListExists(int id)
        {
            return _context.FoodList.Any(e => e.FoodId == id);
        }
    }
}
