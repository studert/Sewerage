using System;
using System.ComponentModel.DataAnnotations;

namespace Sewerage.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Video Url")]
        public string VideoUrl { get; set; }

        public virtual int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
