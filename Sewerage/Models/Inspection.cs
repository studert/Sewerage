using System;

namespace Sewerage.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
