using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealMerchPlan.Models
{
    public class Section
    {
        [Key]
        public int SectionID { get; set; }
        //[Key]
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string MerchGroup { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Depth { get; set; }
        public int NumOfBays { get; set; }

        public virtual ICollection<Bay> Bays { get; set; }

    }
}