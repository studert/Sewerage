using System.Collections.Generic;

namespace Sewerage.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
