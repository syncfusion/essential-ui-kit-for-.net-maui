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
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your new Password")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 3)]
        [Required(ErrorMessage = "Enter your confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
