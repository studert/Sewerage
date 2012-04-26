using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Sewerage.Resources.Models;

namespace Sewerage.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "OldPassword", ResourceType = typeof(AccountStrings))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(AccountStrings))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(AccountStrings))]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(AccountStrings))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(AccountStrings))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(AccountStrings))]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(AccountStrings))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(AccountStrings))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(AccountStrings))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(AccountStrings))]
        public string ConfirmPassword { get; set; }
    }
}