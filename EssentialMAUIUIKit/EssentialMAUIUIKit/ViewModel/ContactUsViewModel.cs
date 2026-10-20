using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EssentialMAUIUIKit.ViewModel
{
    public class ContactUsViewModel : BaseViewModel
    {
        #region Fields

        private string? mapMarkerLatitude;

        private string? mapMarkerLongitude;

        private string? mapMarkerLatitude2;

        private string? mapMarkerLongitude2;

        private string? mapMarkerImage;

        private string? mapMarkerCloseImage;

        private string? mapMarkerHeader;

        private string? mapMarkerAddress;

        private string? mapMarkerPhoneNumber;

        private string? mapMarkerEmailId;

        private Point geoCoordinate;

        private ContactUsInfo? contactUsInfo;

        #endregion

        #region Constructor

        /// <summary> 
        /// </summary>
        public ContactUsViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.MapMarkerImage = "pin.png";
            this.MapMarkerLatitude = "40.133808";
            this.MapMarkerLongitude = "-75.516279";
            this.MapMarkerHeader = "Sipes Inc";
            this.MapMarkerAddress = "7654 Cleveland street, Phoenixville, PA 19460";
            this.MapMarkerEmailId = "dopuyi@hostguru.info";
            this.MapMarkerPhoneNumber = "+1-202-555-0101";
            this.MapMarkerCloseImage = "Close.png";
            this.ContactUsInfo = new ContactUsInfo();
            this.GetPinLocation();
            this.MapMarkerLatitude = "-37.81161";    
            this.MapMarkerLongitude = "144.96306"; 
            this.MapMarkerLatitude2 = "-37.85761"; 
            this.MapMarkerLongitude2 = "144.888";
            this.SubmitCommand = new Command(this.Submit);
        }

        #endregion   

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        public ICommand SubmitCommand { get; set; }

        #endregion

        #region Properties

        public ContactUsInfo? ContactUsInfo
        {
            get
            {
                return this.contactUsInfo;
            }

            set
            {
                this.SetProperty(ref this.contactUsInfo, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker latitude.
        /// </summary>
        public string? MapMarkerLatitude
        {
            get
            {
                return this.mapMarkerLatitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLatitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker longitude.
        /// </summary>
        public string? MapMarkerLongitude
        {
            get
            {
                return this.mapMarkerLongitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLongitude, value);
            }
        }
        /// <summary>
        /// Gets or sets a value of map marker latitude.
        /// </summary>
        public string? MapMarkerLatitude2
        {
            get
            {
                return this.mapMarkerLatitude2;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLatitude2, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker longitude.
        /// </summary>
        public string? MapMarkerLongitude2
        {
            get
            {
                return this.mapMarkerLongitude2;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLongitude2, value);
            }
        }
        /// <summary>
        /// Gets or sets a value for map marker template image.
        /// </summary>
        public string? MapMarkerImage
        {
            get
            {
                return this.mapMarkerImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerImage, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker address.
        /// </summary>
        public string? MapMarkerAddress
        {
            get
            {
                return this.mapMarkerAddress;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerAddress, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker phone number.
        /// </summary>
        public string? MapMarkerPhoneNumber
        {
            get
            {
                return this.mapMarkerPhoneNumber;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerPhoneNumber, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker header.
        /// </summary>
        public string? MapMarkerHeader
        {
            get
            {
                return this.mapMarkerHeader;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerHeader, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker email id.
        /// </summary>
        public string? MapMarkerEmailId
        {
            get
            {
                return this.mapMarkerEmailId;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerEmailId, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker close image.
        /// </summary>
        public string? MapMarkerCloseImage
        {
            get
            {
                return this.mapMarkerCloseImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerCloseImage, value);
            }
        }

        /// <summary>
        /// Gets or sets the geo coordinate.
        /// </summary>
        public Point GeoCoordinate
        {
            get
            {
                return this.geoCoordinate;
            }

            set
            {
                this.SetProperty(ref this.geoCoordinate, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is for getting the pin location detail.
        /// </summary>
        private void GetPinLocation()
        {
            this.GeoCoordinate = new Point(Convert.ToDouble(this.MapMarkerLatitude, CultureInfo.CurrentCulture), Convert.ToDouble(this.MapMarkerLongitude, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
        }

        /// <summary>
        /// Validation rule for password
        /// </summary>
        private void AddValidationRules()
        {
        }

        /// <summary>
        /// Validates the form and displays error messages only when the Submit button is clicked.
        /// </summary>
        private void Submit()
        {
            if (this.ContactUsInfo == null)
            {
                return;
            }

            // Trigger the computed error properties on the model so the error
            // labels below each input render. This mirrors the CardPaymentPage
            // approach where validation only shows up after the button click.
            this.ContactUsInfo.ShowValidation = true;
        }

        #endregion
    }

    public class ContactUsInfo : INotifyPropertyChanged
    {
        #region Fields

        private string name = string.Empty;
        private string email = string.Empty;
        private string message = string.Empty;
        private string company = string.Empty;
        private string phoneNumber = string.Empty;
        private bool showValidation;

        #endregion

        #region Constructor

        public ContactUsInfo()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Message = string.Empty;
            this.Company = string.Empty;
            this.PhoneNumber = string.Empty;
        }

        #endregion

        #region Properties

        [Display(Name = "Name")]
        public string Name
        {
            get => this.name;
            set
            {
                if (this.name == value)
                    return;

                this.name = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        [Display(Name = "Company")]
        public string Company
        {
            get => this.company;
            set
            {
                if (this.company == value)
                    return;

                this.company = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get => this.email;
            set
            {
                if (this.email == value)
                    return;

                this.email = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        [Display(Name = "Phone")]
        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                if (this.phoneNumber == value)
                    return;

                this.phoneNumber = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message
        {
            get => this.message;
            set
            {
                if (this.message == value)
                    return;

                this.message = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public bool ShowValidation
        {
            get => this.showValidation;
            set
            {
                if (this.showValidation == value)
                    return;

                this.showValidation = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        #endregion

        #region Error Messages

        public string NameError =>
            ShowValidation && string.IsNullOrWhiteSpace(Name)
                ? "Enter your name"
                : string.Empty;

        public string CompanyError =>
            ShowValidation && string.IsNullOrWhiteSpace(Company)
                ? "Enter company name"
                : string.Empty;

        public string EmailError
        {
            get
            {
                if (!ShowValidation)
                    return string.Empty;

                if (string.IsNullOrWhiteSpace(Email))
                    return "Enter valid email";

                var emailValidator = new EmailAddressAttribute();

                return !emailValidator.IsValid(Email)
                    ? "Enter valid email"
                    : string.Empty;
            }
        }

        public string PhoneError =>
            ShowValidation && string.IsNullOrWhiteSpace(PhoneNumber)
                ? "Enter valid phone number"
                : string.Empty;

        public string MessageError =>
            ShowValidation && string.IsNullOrWhiteSpace(Message)
                ? "Enter your message"
                : string.Empty;

        #endregion

        #region HasError

        public bool HasNameError =>
            !string.IsNullOrEmpty(NameError);

        public bool HasCompanyError =>
            !string.IsNullOrEmpty(CompanyError);

        public bool HasEmailError =>
            !string.IsNullOrEmpty(EmailError);

        public bool HasPhoneError =>
            !string.IsNullOrEmpty(PhoneError);

        public bool HasMessageError =>
            !string.IsNullOrEmpty(MessageError);

        public bool ReserveNameError =>
            HasNameError;

        public bool ReserveCompanyNameError =>
            HasCompanyError;

        public bool ReserveEmailError =>
            HasEmailError;

        public bool ReservePhoneError =>
            HasPhoneError;

        #endregion

        #region Methods

        private void RefreshValidationProperties()
        {
            OnPropertyChanged(nameof(NameError));
            OnPropertyChanged(nameof(CompanyError));
            OnPropertyChanged(nameof(EmailError));
            OnPropertyChanged(nameof(PhoneError));
            OnPropertyChanged(nameof(MessageError));

            OnPropertyChanged(nameof(HasNameError));
            OnPropertyChanged(nameof(HasCompanyError));
            OnPropertyChanged(nameof(HasEmailError));
            OnPropertyChanged(nameof(HasPhoneError));
            OnPropertyChanged(nameof(HasMessageError));

            OnPropertyChanged(nameof(ReserveNameError));
            OnPropertyChanged(nameof(ReserveCompanyNameError));
            OnPropertyChanged(nameof(ReserveEmailError));
            OnPropertyChanged(nameof(ReservePhoneError));
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
