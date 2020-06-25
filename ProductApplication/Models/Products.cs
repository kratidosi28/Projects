using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApplication.Model
{
    public partial class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductDescription { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductBrand { get; set; }
        public int ProductPrice { get; set; }
    }
}
