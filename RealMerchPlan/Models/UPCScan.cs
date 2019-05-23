using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealMerchPlan.Models
{
    public class UPCScan
    {
        [Key]
        public string UPC { get; set; }

        public virtual ICollection<UPCScan> UPCScans { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual Product Product { get; set; }
    }
}