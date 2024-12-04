using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class ResetPasswordViewModel
    {
        public ResetPasswordInfo ContactsInfo { get; set; }

        #region Constructor
        public ResetPasswordViewModel()
        {
            this.ContactsInfo = new ResetPasswordInfo();
        }

        #endregion
    }

    public class ResetPasswordInfo
    {
        public ResetPasswordInfo()
        {
            this.NewPassword = string.Empty;
            this.ConfirmPassword = string.Empty;
        }

        [Display(Name = "New Password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [EmailAddress(ErrorMessage = "Enter your new password")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the password")]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        public string ConfirmPassword { get; set; }
    }
}
