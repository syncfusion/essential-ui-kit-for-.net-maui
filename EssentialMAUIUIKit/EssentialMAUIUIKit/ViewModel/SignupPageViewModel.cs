using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    public class SignupPageViewModel
    {
        public SignUpInfo ContactsInfo { get; set; }

        #region Constructor
        public SignupPageViewModel()
        {
            this.ContactsInfo = new SignUpInfo();
        }

        #endregion
    }

    public class SignUpInfo
    {
        public SignUpInfo()
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

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter the phone number")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string Password { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string ConfirmPassword { get; set; }
    }
}
