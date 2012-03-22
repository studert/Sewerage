
namespace Sewerage.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public int Number { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
