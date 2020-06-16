using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class FoodItems
    {
        [Key]
        public int FoodItemId { get; set; }
        public int RestaurantId { get; set; }
        public int FoodCategoryId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        [InverseProperty(nameof(Restaurants.FoodItems))]
        public virtual Restaurants Restaurant { get; set; }
    }
}
