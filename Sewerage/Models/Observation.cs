
using System.ComponentModel.DataAnnotations;

namespace Sewerage.Models
{
    public class Observation
    {
        public int ObservationId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double SecondsIntoVideo { get; set; }

        [Required]
        public double Position { get; set; }

        [Required]
        public string Tag { get; set; }

        public virtual int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
