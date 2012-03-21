using System.Collections.Generic;

namespace Sewerage.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public int Number { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
