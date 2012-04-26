
using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Observation
    {
        [Display(Name = "Observation", ResourceType = typeof(ObservationStrings))]
        public int ObservationId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ObservationStrings))]
        public string Description { get; set; }

        [Required]
        [Display(Name = "SecondsIntoVideo", ResourceType = typeof(ObservationStrings))]
        public double SecondsIntoVideo { get; set; }

        [Required]
        [Display(Name = "Position", ResourceType = typeof(ObservationStrings))]
        public double Position { get; set; }

        [Required]
        [Display(Name = "Tag", ResourceType = typeof(ObservationStrings))]
        public string Tag { get; set; }

        public virtual int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
