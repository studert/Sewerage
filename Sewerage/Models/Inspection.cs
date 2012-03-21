using System;
using System.Collections.Generic;

namespace Sewerage.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
    }
}
