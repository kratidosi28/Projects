

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            FoodItems = new HashSet<FoodItems>();
        }

        [Key]
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

        [InverseProperty("Restaurant")]
        public virtual ICollection<FoodItems> FoodItems { get; set; }
    }
}
