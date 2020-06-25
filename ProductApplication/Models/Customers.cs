using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerIdentification = new HashSet<CustomerIdentification>();
        }

        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

      
        public string LastName { get; set; }

        public string Email { get; set; }

     
        public string Password { get; set; }

      
        public string ConfirmPassword { get; set; }

      
        public string MobileNumber { get; set; }

      
        public string Gender { get; set; }

        public string Address { get; set; }

        public DateTime? Dob { get; set; }

        public virtual ICollection<CustomerIdentification> CustomerIdentification { get; set; }
    }
}
