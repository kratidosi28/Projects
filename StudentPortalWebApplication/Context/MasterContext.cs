using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentInformationManagementSystem.Model;

namespace StudentInformationManagementSystem.Context
{
    public class MasterContext:DbContext
    {

      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VF2DC0P;initial catalog=ConsoleApplication2Db;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }*/

          public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseSpecialization> Specializations { get; set; }


        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Fees> fees { get; set; }


        public DbSet<AdminDetails> admin { get; set; }
    }
}
