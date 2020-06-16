using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrder.Model
{

    //[Table("Payment")]
    public partial class Payment
    {
        [Key]
        public int PMId { get; set; }
        [Required]
        [StringLength(50)]
        public string CardOwnerName { get; set; }
        [Required]
        [StringLength(50)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpirationDate { get; set; }

        [Required]
        [StringLength(4)]
        public string CVV { get; set; }
    }
}
