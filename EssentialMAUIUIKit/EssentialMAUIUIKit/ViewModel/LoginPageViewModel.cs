using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    public class LoginPageViewModel
    {

        public ContactsInfo ContactsInfo { get; set; }

        #region Constructor
        public LoginPageViewModel()
        {
            this.ContactsInfo = new ContactsInfo();
        }

        #endregion
    }

    public class ContactsInfo
    {
        public ContactsInfo()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Password")]
        public string Password { get; set; }
    }
}
