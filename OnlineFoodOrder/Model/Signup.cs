using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    [Table("signup")]
    public partial class Signup
    {
        public Signup()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int RegistrationId { get; set; }
      
        [StringLength(50)]
        public string FullName { get; set; }
      
        [StringLength(50)]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string MobileNumber { get; set; }

        [InverseProperty("Registration")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
