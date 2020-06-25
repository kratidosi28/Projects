using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationManagementSystem.Model
{
    public class Subjects
    {


        [Key]

        public int SubjectId{ get; set; }

        public string SubjectName { get; set; }

        public int CourseSpecializationId { get; set; }

       
       

        public int CourseId { get; set; }
    }
}
