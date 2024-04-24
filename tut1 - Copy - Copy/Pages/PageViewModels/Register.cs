using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace tut1.Pages.PageViewModels
{
    [BindProperties]
    public class Register
    {
        [Required]
        public string Passcode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
