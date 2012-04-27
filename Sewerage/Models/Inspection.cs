using System;
using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Inspection
    {
        [Display(Name = "Inspection", ResourceType = typeof(InspectionStrings))]
        public int InspectionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "StartDate", ResourceType = typeof(InspectionStrings))]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "EndDate", ResourceType = typeof(InspectionStrings))]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "VideoUrl", ResourceType = typeof(InspectionStrings))]
        public string VideoUrl { get; set; }

        public virtual int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
