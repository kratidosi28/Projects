using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrder.Model
{
    public partial class Payment
    {
        [Key]
        [Column("PMId")]
        public int Pmid { get; set; }
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
        [Column("CVV")]
        [StringLength(4)]
        public string Cvv { get; set; }
    }
}
