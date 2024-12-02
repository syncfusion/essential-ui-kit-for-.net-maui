using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class AddContactViewModel
    {
        public ContactForm ContactsInfo { get; set; }

        #region Constructor
        public AddContactViewModel()
        {
            this.ContactsInfo = new ContactForm();
        }

        #endregion
    }

    public class ContactForm
    {
        public ContactForm()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now.Date;
            this.Gender = Gender.Male;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.Country = string.Empty;
            this.State = State.Alabama;
            this.City = string.Empty;
            this.PhoneNumber = string.Empty;
        }

        [Display(GroupName = "General Information")]
        public string FirstName { get; set; }

        [Display(GroupName = "General Information")]
        public string LastName { get; set; }

        [Display(GroupName = "General Information")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(GroupName = "General Information")]
        public Gender Gender { get; set; }

        [Display(GroupName = "Contact Information", Order = 0)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(GroupName = "Contact Information", Order = 1)]
        public string Address { get; set; }

        [Display(GroupName = "Contact Information", Order = 2)]
        public string Country { get; set; }

        [Display(GroupName = "Contact Information", Order = 3)]
        public State State { get; set; }

        [Display(GroupName = "Contact Information", Order = 3)]
        public string City { get; set; }

        [Display(GroupName = "Contact Information", Order = 4)]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum State
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia
    }
}
