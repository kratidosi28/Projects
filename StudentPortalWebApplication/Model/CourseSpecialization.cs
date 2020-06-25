using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationManagementSystem.Model
{
    public class CourseSpecialization
    {


        [Key]
        public int CourseSpecializationId { get; set; }

        public string CourseSpecializationName { get; set; }

        public int CourseSpecializationFees { get; set; }

        public int CourseId { get; set; }
    }
}
