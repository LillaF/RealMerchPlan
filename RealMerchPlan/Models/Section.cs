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
        [Required, StringLength(50)]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display(Name = "Merch Group")]
        public string MerchGroup { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Depth { get; set; }
        [Required]        
        [Display(Name = "Num of Bays")]
        public int NumOfBays { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        public virtual ICollection<Bay> Bays { get; set; }

    }
}