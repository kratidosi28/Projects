using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class VFoodList
    {
        [Key]
        public int FoodItemId { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantDefinition { get; set; }
        [Required]
        public string RestaurantLocation { get; set; }
        [Required]
        [StringLength(50)]
        public string OpenTime { get; set; }
        [Required]
        [StringLength(50)]
        public string FoodCategoryName { get; set; }
        [Required]
        [StringLength(50)]
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        
    }
}
