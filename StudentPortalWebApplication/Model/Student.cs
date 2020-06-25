using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationManagementSystem.Model
{
    public class Student
    {
        [Key]
       
        public int EnrollmentNumber { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public int StudentAge { get; set; }

        public string StudentAddress { get; set; }

        public string StudentEmailId { get; set; }
        

        public string StudentMobileNumber { get; set; }

        public int CourseSpecializationId { get; set; }

        public int AcademicYear { get; set; }

    }
}
