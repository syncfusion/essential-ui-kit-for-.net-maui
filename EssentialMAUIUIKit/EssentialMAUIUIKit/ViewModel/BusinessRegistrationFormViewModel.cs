using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class BusinessRegistrationFormViewModel
    {
        public BusinessRegistrationFormInfo ContactsInfo { get; set; }

        #region Constructor
        public BusinessRegistrationFormViewModel()
        {
            this.ContactsInfo = new BusinessRegistrationFormInfo();
        }

        #endregion
    }

    public class BusinessRegistrationFormInfo
    {
        public BusinessRegistrationFormInfo()
        {
            this.BusinessOwnerName = string.Empty;
            this.BusinessName = string.Empty;
            this.BusinessType = string.Empty;
            this.BusinessEmail = string.Empty;
            this.BusinessAddress = string.Empty;
            this.BusinessCountry = string.Empty;
            this.BusinessState = string.Empty;
            this.BusinessCity = string.Empty;
            this.BusinessPhoneNumber = string.Empty;
        }

        [Display(Name = "Full Name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your full name")]
        public string BusinessOwnerName { get; set; }

        [Display(Name = "Business Name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your business name")]
        public string BusinessName { get; set; }

        [Display(Name = "Type of Business")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your business type")]
        public string BusinessType { get; set; }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your email")]
        public string BusinessEmail { get; set; }

        [Display(Name = "Address")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your address")]
        public string BusinessAddress { get; set; }

        [Display(Name = "Country")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your country")]
        public string BusinessCountry { get; set; }

        [Display(Name = "State")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        [Required(ErrorMessage = "Enter your state")]
        public string BusinessState { get; set; }

        [Display(Name = "City")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        [Required(ErrorMessage = "Enter your city")]
        public string BusinessCity { get; set; }

        [Display(Name = "Phone Number")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your phone number")]
        public string BusinessPhoneNumber { get; set; }
    }
}
