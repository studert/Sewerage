using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Section
    {
        [Display(Name = "Section", ResourceType = typeof(SectionStrings))]
        public int SectionId { get; set; }

        [Required]
        [RegularExpression(@"\b\d+\b")]
        [Display(Name = "Number", ResourceType = typeof(SectionStrings))]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City", ResourceType = typeof(SectionStrings))]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Street", ResourceType = typeof(SectionStrings))]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"((\b[0-9]+)?\.)?[0-9]+\b", ErrorMessage = "The {0} field must be a decimal.")]
        [Display(Name = "Length", ResourceType = typeof(SectionStrings))]
        public double Length { get; set; }

        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
