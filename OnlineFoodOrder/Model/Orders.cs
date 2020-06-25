using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int RegistrationId { get; set; }
        public int FoodId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(FoodId))]
        [InverseProperty(nameof(FoodList.Orders))]
        public virtual FoodList Food { get; set; }
        [ForeignKey(nameof(RegistrationId))]
        [InverseProperty(nameof(Signup.Orders))]
        public virtual Signup Registration { get; set; }
    }
}
