using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealMerchPlan.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string UPC { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public string Size { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Depth { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
        public virtual UPCScan UPCScan { get; set; }
    }
}