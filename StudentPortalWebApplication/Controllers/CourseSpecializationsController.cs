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
    public class CourseSpecializationsController : ControllerBase
    {
        private readonly MasterContext _context;

        public CourseSpecializationsController(MasterContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseSpecialization>>> GetSpecializations()
        {
            return await _context.Specializations.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseSpecialization>> GetCourseSpecialization(int id)
        {
            var courseSpecialization = await _context.Specializations.FindAsync(id);

            if (courseSpecialization == null)
            {
                return NotFound();
            }

            return courseSpecialization;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseSpecialization(int id, CourseSpecialization courseSpecialization)
        {
            if (id != courseSpecialization.CourseSpecializationId)
            {
                return BadRequest();
            }

            _context.Entry(courseSpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseSpecializationExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<CourseSpecialization>> PostCourseSpecialization(CourseSpecialization courseSpecialization)
        {
            _context.Specializations.Add(courseSpecialization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseSpecialization", new { id = courseSpecialization.CourseSpecializationId }, courseSpecialization);
        }

      
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseSpecialization>> DeleteCourseSpecialization(int id)
        {
            var courseSpecialization = await _context.Specializations.FindAsync(id);
            if (courseSpecialization == null)
            {
                return NotFound();
            }

            _context.Specializations.Remove(courseSpecialization);
            await _context.SaveChangesAsync();

            return courseSpecialization;
        }

        private bool CourseSpecializationExists(int id)
        {
            return _context.Specializations.Any(e => e.CourseSpecializationId == id);
        }
    }
}
