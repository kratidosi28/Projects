using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class VCategories
    {
        public int RestaurantId { get; set; }
        public int FoodCategoryId { get; set; }
       
        [StringLength(50)]
        public string FoodCategoryName { get; set; }

        [Key]
        public int FoodItemId { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
    }
}
