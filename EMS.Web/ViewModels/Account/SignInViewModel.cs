using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Web.ViewModels.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required ]
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
