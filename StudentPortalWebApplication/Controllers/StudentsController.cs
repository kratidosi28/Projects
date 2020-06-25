using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentInformationManagementSystem.Context;
using StudentInformationManagementSystem.Model;

namespace StudentInformationManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MasterContext _context;

        public StudentsController(MasterContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            /* if (id != student.EnrollmentNumber)
             {
                 return BadRequest();
             }

             _context.Entry(student).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!StudentExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();*/


            var data = _context.Database.ExecuteSqlCommand("spUpdateStudentDetails  @id,@StudentFirstName,@StudentLastName,@StudentAge,@StudentEmail,@StudentMobileNumber,@StudentAddress,@CourseSpecializationId,@Academicyear",

                 new SqlParameter("@id", id),
                 new SqlParameter("@StudentFirstName", student.StudentFirstName),
                 new SqlParameter("@StudentLastName", student.StudentLastName),
                 new SqlParameter("@StudentAge", student.StudentAge),
                 new SqlParameter("@StudentEmail", student.StudentEmailId),
                 new SqlParameter("@StudentMobileNumber", student.StudentMobileNumber),
                 new SqlParameter("@StudentAddress", student.StudentAddress),
                 new SqlParameter("@CourseSpecializationId", student.CourseSpecializationId),
                 new SqlParameter("@Academicyear", student.AcademicYear));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
           
            var data = _context.Database.ExecuteSqlCommand("spAddStudents @StudentFirstName,@StudentLastName,@StudentAge,@StudentAddress,@StudentEmail,@StudentMobileNumber,@CourseSpecializationId,@Academicyear",

                  new SqlParameter("@StudentFirstName", student.StudentFirstName),
                  new SqlParameter("@StudentLastName", student.StudentLastName),
                  new SqlParameter("@StudentAge", student.StudentAge),
                    new SqlParameter("@StudentAddress", student.StudentAddress),
                  new SqlParameter("@StudentEmail", student.StudentEmailId),
                  new SqlParameter("@StudentMobileNumber", student.StudentMobileNumber),
                
                  new SqlParameter("@CourseSpecializationId", student.CourseSpecializationId),
                  new SqlParameter("@Academicyear", student.AcademicYear));
           // return Ok(data);

             _context.Students.Add(student);
            return Ok(data);
            
             /*return CreatedAtAction("GetStudent", new { id = student.EnrollmentNumber }, student);*/

        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {


            var data = _context.Database.ExecuteSqlCommand("spDeleteStudent @id",

           new SqlParameter("@id", id)
               );
            return Ok(data);
            /* var student = await _context.Students.FindAsync(id);
             if (student == null)
             {
                 return NotFound();
             }

             _context.Students.Remove(student);
             await _context.SaveChangesAsync();

             return student;*/
         }

            private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.EnrollmentNumber == id);
        }
    }
}
