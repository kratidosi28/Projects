using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationManagementSystem.Context;
using StudentInformationManagementSystem.Model;

namespace StudentInformationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDetailsController : ControllerBase
    {
        private readonly MasterContext _context;

        public AdminDetailsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/AdminDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDetails>>> Getadmin()
        {
            return await _context.admin.ToListAsync();
        }

        // GET: api/AdminDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDetails>> GetAdminDetails(int id)
        {
            var adminDetails = await _context.admin.FindAsync(id);

            if (adminDetails == null)
            {
                return NotFound();
            }

            return adminDetails;
        }

        // PUT: api/AdminDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminDetails(int id, AdminDetails adminDetails)
        {
            if (id != adminDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminDetailsExists(id))
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

        // POST: api/AdminDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdminDetails>> PostAdminDetails(AdminDetails adminDetails)
        {
            _context.admin.Add(adminDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminDetails", new { id = adminDetails.Id }, adminDetails);
        }

        // DELETE: api/AdminDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminDetails>> DeleteAdminDetails(int id)
        {
            var adminDetails = await _context.admin.FindAsync(id);
            if (adminDetails == null)
            {
                return NotFound();
            }

            _context.admin.Remove(adminDetails);
            await _context.SaveChangesAsync();

            return adminDetails;
        }

        private bool AdminDetailsExists(int id)
        {
            return _context.admin.Any(e => e.Id == id);
        }
    }
}
