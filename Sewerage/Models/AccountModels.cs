using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "OldPassword", ResourceType = typeof(AccountStrings))]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringMinLengthField", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(AccountStrings))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "CompareField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(AccountStrings))]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UserName", ResourceType = typeof(AccountStrings))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(AccountStrings))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(AccountStrings))]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "UserName", ResourceType = typeof(AccountStrings))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(AccountStrings))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(100, ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "StringMinLengthField", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(AccountStrings))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "CompareField")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(AccountStrings))]
        public string ConfirmPassword { get; set; }
    }
}