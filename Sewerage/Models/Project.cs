using System.ComponentModel.DataAnnotations;

namespace Sewerage.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
