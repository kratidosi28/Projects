using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Locations
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
