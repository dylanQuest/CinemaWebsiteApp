using System.ComponentModel.DataAnnotations;

namespace RP1_L00164316.Pages.PageViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
