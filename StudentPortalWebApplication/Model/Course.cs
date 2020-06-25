﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationManagementSystem.Model
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

    }
}
