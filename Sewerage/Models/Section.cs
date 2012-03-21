using System.Collections.Generic;

namespace Sewerage.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public int Number { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
