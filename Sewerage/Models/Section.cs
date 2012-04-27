using System.ComponentModel.DataAnnotations;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class Section
    {
        [Display(Name = "Section", ResourceType = typeof(SectionStrings))]
        public int SectionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"\b\d+\b", ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RegexNumberField")]
        [Display(Name = "Number", ResourceType = typeof(SectionStrings))]
        public int Number { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringMaxLengthField")]
        [Display(Name = "City", ResourceType = typeof(SectionStrings))]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringMaxLengthField")]
        [Display(Name = "Street", ResourceType = typeof(SectionStrings))]
        public string Street { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"((\b[0-9]+)?\.)?[0-9]+\b", ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RegexDecimalField")]
        [Display(Name = "Length", ResourceType = typeof(SectionStrings))]
        public double Length { get; set; }

        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
