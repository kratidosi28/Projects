using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public partial class CustomerIdentification
    {   
        [Key]
        public int CustomerUniqueId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
