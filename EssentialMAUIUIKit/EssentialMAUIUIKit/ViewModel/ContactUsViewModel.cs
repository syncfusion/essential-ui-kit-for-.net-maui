using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EssentialMAUIUIKit.ViewModel
{
    public class ContactUsViewModel : BaseViewModel
    {
        #region Fields

        private string? mapMarkerLatitude;

        private string? mapMarkerLongitude;

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
        /// Initializes a new instance of the <see cref="ContactUsViewModel" /> class.
        /// </summary>
        public ContactUsViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.MapMarkerImage = "Pin.png";
            this.MapMarkerLatitude = "40.133808";
            this.MapMarkerLongitude = "-75.516279";
            this.MapMarkerHeader = "Sipes Inc";
            this.MapMarkerAddress = "7654 Cleveland street, Phoenixville, PA 19460";
            this.MapMarkerEmailId = "dopuyi@hostguru.info";
            this.MapMarkerPhoneNumber = "+1-202-555-0101";
            this.MapMarkerCloseImage = "Close.png";
            this.ContactUsInfo = new ContactUsInfo();
            this.GetPinLocation();
        }

        #endregion   

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        //public ICommand SendCommand { get; set; }

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

        #endregion
    }

    public class ContactUsInfo
    {
        public ContactUsInfo()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Message = string.Empty;
            this.Company = string.Empty;
            this.PhoneNumber = string.Empty;
        }

        [Display(Name = "Name")]
        [EmailAddress(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Display(Name = "Company")]
        [EmailAddress(ErrorMessage = "Enter company name")]
        public string Company { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
