using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Project
    {
        [Display(Name = "Project", ResourceType = typeof(ProjectStrings))]
        public int ProjectId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Name", ResourceType = typeof(ProjectStrings))]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringMaxLengthField")]
        [Display(Name = "Description", ResourceType = typeof(ProjectStrings))]
        public string Description { get; set; }
    }
}
