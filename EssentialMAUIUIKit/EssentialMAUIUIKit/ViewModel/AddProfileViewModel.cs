using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class AddProfileViewModel
    {
        public AddProfileInfo ContactsInfo { get; set; }

        #region Constructor
        public AddProfileViewModel()
        {
            this.ContactsInfo = new AddProfileInfo();
        }

        #endregion
    }

    public class AddProfileInfo
    {
        public AddProfileInfo()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Groups = string.Empty;
            this.Company = string.Empty;
            this.State = string.Empty;
            this.City = string.Empty;
        }

        [Display(Name = "First Name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your first name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }

        [Display(Name = "Groups")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string Groups { get; set; }

        [Display(Name = "Company")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string Company { get; set; }

        [Display(Name = "State")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        public string State { get; set; }

        [Display(Name = "City")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        public string City { get; set; }
    }
}
