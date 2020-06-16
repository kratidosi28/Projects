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
    public class LoginController : ControllerBase
    {
        private readonly Mastercontext _context;

        public LoginController(Mastercontext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Signup>>> Getsignups()
        {
            return await _context.signups.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Signup>> GetSignup(int id)
        {
            var signup = await _context.signups.FindAsync(id);

            if (signup == null)
            {
                return NotFound();
            }

            return signup;
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignup(int id, Signup signup)
        {
            if (id != signup.RegistrationId)
            {
                return BadRequest();
            }

            _context.Entry(signup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignupExists(id))
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

        // POST: api/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Signup>> PostSignup(Signup signups)
        {
            var check = await _context.signups.SingleOrDefaultAsync(t => t.Email == signups.Email);

            if (check == null)
            {

                return NotFound();
            }

            return check;
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Signup>> DeleteSignup(int id)
        {
            var signup = await _context.signups.FindAsync(id);
            if (signup == null)
            {
                return NotFound();
            }

            _context.signups.Remove(signup);
            await _context.SaveChangesAsync();

            return signup;
        }

        private bool SignupExists(int id)
        {
            return _context.signups.Any(e => e.RegistrationId == id);
        }
    }
}
