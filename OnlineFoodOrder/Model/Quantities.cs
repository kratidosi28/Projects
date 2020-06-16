using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Quantities
    {
        [Key]
        public int QuantityId { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
    }
}
