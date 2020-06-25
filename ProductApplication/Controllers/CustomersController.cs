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
    public class CustomersController : ControllerBase
    {
        private readonly MasterContext _context;

        public CustomersController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(int id)
        {
            var customers = await _context.customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            /*_context.customers.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);*/

            var data = _context.Database.ExecuteSqlCommand("spCustomer @FirstName,@LastName,@Email,@Password,@ConfirmPassword,@MobileNo,@Gender,@Address,@DOB ",
           new SqlParameter("@FirstName", customers.FirstName),
               new SqlParameter("@LastName", customers.LastName),
               new SqlParameter("@Email", customers.Email),
               new SqlParameter("@Password", customers.Password),
               new SqlParameter("@ConfirmPassword", customers.ConfirmPassword),
               new SqlParameter("@MobileNo", customers.MobileNumber),
               new SqlParameter("@Gender", customers.Gender),
               new SqlParameter("@Address", customers.Address),
               new SqlParameter("@DOB", customers.Dob)

           );

      return Ok(data);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(int id)
        {
            /* var customers = await _context.customers.FindAsync(id);
             if (customers == null)
             {
                 return NotFound();
             }

             _context.customers.Remove(customers);
             await _context.SaveChangesAsync();

             return customers;*/

            var data = _context.Database.ExecuteSqlCommand("spCustomerDelete @CustomerId ",
        new SqlParameter("@CustomerId", id));
            return Ok(data);
        }

        private bool CustomersExists(int id)
        {
            return _context.customers.Any(e => e.CustomerId == id);
        }
    }
}
