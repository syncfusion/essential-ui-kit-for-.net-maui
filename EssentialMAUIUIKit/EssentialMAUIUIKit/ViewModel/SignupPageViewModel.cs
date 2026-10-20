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
            this.PhoneNumber = string.Empty;
            this.Password = string.Empty;
        }

        [Display(Name = "Name")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Password")]
        public string Password { get; set; }
    }
}
