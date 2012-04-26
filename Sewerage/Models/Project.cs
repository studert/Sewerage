using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Project
    {
        [Display(Name = "Project", ResourceType = typeof(ProjectStrings))]
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(ProjectStrings))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(ProjectStrings))]
        public string Description { get; set; }
    }
}
