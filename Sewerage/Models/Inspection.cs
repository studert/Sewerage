using System;
using System.ComponentModel.DataAnnotations;

namespace Sewerage.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public virtual int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
