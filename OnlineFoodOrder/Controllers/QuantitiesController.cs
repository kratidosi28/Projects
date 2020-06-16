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
    public class QuantitiesController : ControllerBase
    {
        private readonly Mastercontext _context;

        public QuantitiesController(Mastercontext context)
        {
            _context = context;
        }

        // GET: api/Quantities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quantities>>> Getquantities()
        {
            return await _context.quantities.ToListAsync();
        }

        // GET: api/Quantities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quantities>> GetQuantities(int id)
        {
            var quantities = await _context.quantities.FindAsync(id);

            if (quantities == null)
            {
                return NotFound();
            }

            return quantities;
        }

        // PUT: api/Quantities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantities(int id, Quantities quantities)
        {
            if (id != quantities.QuantityId)
            {
                return BadRequest();
            }

            _context.Entry(quantities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantitiesExists(id))
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

        // POST: api/Quantities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Quantities>> PostQuantities(Quantities quantities)
        {
            _context.quantities.Add(quantities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantities", new { id = quantities.QuantityId }, quantities);
        }

        // DELETE: api/Quantities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quantities>> DeleteQuantities(int id)
        {
            var quantities = await _context.quantities.FindAsync(id);
            if (quantities == null)
            {
                return NotFound();
            }

            _context.quantities.Remove(quantities);
            await _context.SaveChangesAsync();

            return quantities;
        }

        private bool QuantitiesExists(int id)
        {
            return _context.quantities.Any(e => e.QuantityId == id);
        }
    }
}
