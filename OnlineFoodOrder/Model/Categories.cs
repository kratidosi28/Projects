using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Categories
    {
        public Categories()
        {
            FoodList = new HashSet<FoodList>();
        }

        [Key]
        public int FoodCategoryId { get; set; }
      
        [StringLength(50)]
        public string FoodCategoryName { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("FoodCategory")]
        public virtual ICollection<FoodList> FoodList { get; set; }
    }
}
