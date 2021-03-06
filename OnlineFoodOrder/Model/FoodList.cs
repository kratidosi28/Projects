﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class FoodList
    {
        public FoodList()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int FoodId { get; set; }
       
        [StringLength(50)]
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int FoodCategoryId { get; set; }

        [ForeignKey(nameof(FoodCategoryId))]
        [InverseProperty(nameof(Categories.FoodList))]
        public virtual Categories FoodCategory { get; set; }
        [InverseProperty("Food")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
