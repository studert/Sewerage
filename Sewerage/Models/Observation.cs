
namespace Sewerage.Models
{
    public class Observation
    {
        public int ObservationId { get; set; }
        public string Description { get; set; }
        public double SecondsIntoVideo { get; set; }
        public double Position { get; set; }
        public string Tag { get; set; }
        public virtual int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
