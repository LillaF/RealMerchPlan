using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealMerchPlan.Models
{
    public enum FixtureType
    {
        Shelf, Bar
    }
    public class Fixture
    {
        [Key]
        public int FixtureID { get; set; }
        [Required]
        public int BayID { get; set; }
        [Required]
        public FixtureType? FixtureType { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Depth { get; set; }
        [Required]
        public double XLocation { get; set; }
        [Required]
        public double YLocation { get; set; }

        public virtual Bay Bay { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

    }
}