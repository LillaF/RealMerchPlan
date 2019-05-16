using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealMerchPlan.Models
{
    public class Bay
    {
        [Key]
        public int BayID { get; set; }
        [Required]
        public int SectionID { get; set; }
        [Required]
        public int BayName { get; set; }
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
        //[Required]
        public int NumOfFix { get; set; }
        
        public virtual Section Section { get; set; }
        public virtual ICollection<Fixture> Fixtures { get; set; }
    }
}