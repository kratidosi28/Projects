using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationManagementSystem.Model
{
    public class Fees
    {
        [Key]
        public int FeesId { get; set; }

        public int FeesAmount { get; set; }

        public string FeesStatus { get; set; }




        public int EnrollmentNumber { get; set; }
    }
}
