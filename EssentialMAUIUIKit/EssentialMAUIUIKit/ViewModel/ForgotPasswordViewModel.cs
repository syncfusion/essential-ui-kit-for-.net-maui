using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class ForgotPasswordViewModel
    {
        public ForgotPasswordInfo ContactsInfo { get; set; }

        #region Constructor
        public ForgotPasswordViewModel()
        {
            this.ContactsInfo = new ForgotPasswordInfo();
        }

        #endregion
    }

    public class ForgotPasswordInfo
    {
        public ForgotPasswordInfo()
        {
            this.Email = string.Empty;
        }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your Password")]
        public string Email { get; set; }
    }
}
