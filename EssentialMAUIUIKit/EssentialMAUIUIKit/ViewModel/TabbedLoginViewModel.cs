using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    public class TabbedLoginViewModel
    {
        public LoginInfo LoginInfo { get; set; }
        public SignUpFormInfo SignUpInfo { get; set; }

        public TabbedLoginViewModel()
        {
            this.LoginInfo = new LoginInfo();
            this.SignUpInfo = new SignUpFormInfo();
        }
    }

    public class LoginInfo
    {
        public LoginInfo()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [EmailAddress(ErrorMessage = "Enter your email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string Password { get; set; }
    }

    public class SignUpFormInfo
    {
        public SignUpFormInfo()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.ConfirmPassword = string.Empty;
        }

        [Display(Name = "Name")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [EmailAddress(ErrorMessage = "Enter your email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string ConfirmPassword { get; set; }
    }
}
