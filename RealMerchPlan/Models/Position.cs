using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealMerchPlan.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        [Required]
        public int FixtureId { get; set; }
        [Required]
        public int UPC { get; set; }
        [Required]
        public double XLocation { get; set; }
        [Required]
        public double YLocation { get; set; }

        public virtual Product Product { get; set; }
        public virtual Fixture Fixture { get; set; }

    }
}