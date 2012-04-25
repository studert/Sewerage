using System.ComponentModel.DataAnnotations;

namespace Sewerage.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        [Required]
        [RegularExpression(@"\b\d+\b", ErrorMessage = "The Number field must be numeric.")]
        public int Number { get; set; }

        [Required] 
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Section Length")]
        [RegularExpression(@"((\b[0-9]+)?\.)?[0-9]+\b", ErrorMessage = "The {0} field must be a decimal.")]
        public double Length { get; set; }

        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
