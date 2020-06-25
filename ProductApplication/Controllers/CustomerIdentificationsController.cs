using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductApplication.Context;
using ProductApplication.Models;

namespace ProductApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentificationsController : ControllerBase
    {
        private readonly MasterContext _context;

        public CustomerIdentificationsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/CustomerIdentifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerIdentification>>> GetcustomerIdentifications()
        {
            return await _context.customerIdentifications.ToListAsync();
        }

        // GET: api/CustomerIdentifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerIdentification>> GetCustomerIdentification(int id)
        {
            var customerIdentification = await _context.customerIdentifications.FindAsync(id);

            if (customerIdentification == null)
            {
                return NotFound();
            }

            return customerIdentification;
        }

        // PUT: api/CustomerIdentifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerIdentification(int id, CustomerIdentification customerIdentification)
        {
            if (id != customerIdentification.CustomerUniqueId)
            {
                return BadRequest();
            }

            _context.Entry(customerIdentification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerIdentificationExists(id))
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

        // POST: api/CustomerIdentifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerIdentification>> PostCustomerIdentification(CustomerIdentification customerIdentification)
        {
            _context.customerIdentifications.Add(customerIdentification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerIdentification", new { id = customerIdentification.CustomerUniqueId }, customerIdentification);
        }

        // DELETE: api/CustomerIdentifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerIdentification>> DeleteCustomerIdentification(int id)
        {
            /* var customerIdentification = await _context.customerIdentifications.FindAsync(id);
             if (customerIdentification == null)
             {
                 return NotFound();
             }

             _context.customerIdentifications.Remove(customerIdentification);
             await _context.SaveChangesAsync();

             return customerIdentification;*/

            var data = _context.Database.ExecuteSqlCommand("spCustomerDelete @CustomerUniqueId ",
            new SqlParameter("@CustomerUniqueId", id));
            return Ok(data);
        }

        private bool CustomerIdentificationExists(int id)
        {
            return _context.customerIdentifications.Any(e => e.CustomerUniqueId == id);
        }
    }
}
