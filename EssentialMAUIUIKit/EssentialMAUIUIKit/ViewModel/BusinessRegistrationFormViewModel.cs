using Syncfusion.Maui.DataForm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    class BusinessRegistrationFormViewModel
    {
        public BusinessRegistrationFormInfo ContactsInfo { get; set; }
        public ICommand SubmitCommand { get; set; }

        #region Constructor
        public BusinessRegistrationFormViewModel()
        {
            this.ContactsInfo = new BusinessRegistrationFormInfo();

            this.SubmitCommand = new Command(this.Submit);
        }
        private void Submit()
        {
            if (this.ContactsInfo == null)
            {
                return;
            }

            this.ContactsInfo.ShowValidation = true;
        }
        #endregion
    }

    public class BusinessRegistrationFormInfo : INotifyPropertyChanged
    {
        private string businessOwnerName = string.Empty;
        private string businessName = string.Empty;
        private string businessType = string.Empty;
        private string businessEmail = string.Empty;
        private string businessAddress = string.Empty;
        private string businessCountry = string.Empty;
        private string businessState = string.Empty;
        private string businessCity = string.Empty;
        private string businessPhoneNumber = string.Empty;
        private bool showValidation;

        public string BusinessOwnerName
        {
            get => businessOwnerName;
            set
            {
                if (businessOwnerName == value)
                    return;

                businessOwnerName = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessName
        {
            get => businessName;
            set
            {
                if (businessName == value)
                    return;

                businessName = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessType
        {
            get => businessType;
            set
            {
                if (businessType == value)
                    return;

                businessType = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessEmail
        {
            get => businessEmail;
            set
            {
                if (businessEmail == value)
                    return;

                businessEmail = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessAddress
        {
            get => businessAddress;
            set
            {
                if (businessAddress == value)
                    return;

                businessAddress = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessCountry
        {
            get => businessCountry;
            set
            {
                if (businessCountry == value)
                    return;

                businessCountry = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessState
        {
            get => businessState;
            set
            {
                if (businessState == value)
                    return;

                businessState = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessCity
        {
            get => businessCity;
            set
            {
                if (businessCity == value)
                    return;

                businessCity = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string BusinessPhoneNumber
        {
            get => businessPhoneNumber;
            set
            {
                if (businessPhoneNumber == value)
                    return;

                businessPhoneNumber = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public bool ShowValidation
        {
            get => showValidation;
            set
            {
                if (showValidation == value)
                    return;

                showValidation = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        #region Error Messages

        public string BusinessOwnerNameError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessOwnerName)
                ? "Enter your full name"
                : string.Empty;

        public string BusinessNameError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessName)
                ? "Enter your business name"
                : string.Empty;

        public string BusinessTypeError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessType)
                ? "Enter your business type"
                : string.Empty;

        public string BusinessAddressError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessAddress)
                ? "Enter your address"
                : string.Empty;

        public string BusinessCountryError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessCountry)
                ? "Enter your country"
                : string.Empty;

        public string BusinessStateError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessState)
                ? "Enter your state"
                : string.Empty;

        public string BusinessCityError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessCity)
                ? "Enter your city"
                : string.Empty;

        public string BusinessPhoneNumberError =>
            ShowValidation && string.IsNullOrWhiteSpace(BusinessPhoneNumber)
                ? "Enter your phone number"
                : string.Empty;

        public string BusinessEmailError
        {
            get
            {
                if (!ShowValidation)
                    return string.Empty;

                if (string.IsNullOrWhiteSpace(BusinessEmail))
                    return "Enter your email";

                var emailValidator = new EmailAddressAttribute();

                if (!emailValidator.IsValid(BusinessEmail))
                    return "Enter valid email";

                return string.Empty;
            }
        }

        #endregion

        #region HasError

        public bool HasBusinessOwnerNameError =>
            !string.IsNullOrEmpty(BusinessOwnerNameError);

        public bool HasBusinessNameError =>
            !string.IsNullOrEmpty(BusinessNameError);

        public bool HasBusinessTypeError =>
            !string.IsNullOrEmpty(BusinessTypeError);

        public bool HasBusinessEmailError =>
            !string.IsNullOrEmpty(BusinessEmailError);

        public bool HasBusinessAddressError =>
            !string.IsNullOrEmpty(BusinessAddressError);

        public bool HasBusinessCountryError =>
            !string.IsNullOrEmpty(BusinessCountryError);

        public bool HasBusinessStateError =>
            !string.IsNullOrEmpty(BusinessStateError);

        public bool HasBusinessCityError =>
            !string.IsNullOrEmpty(BusinessCityError);

        public bool HasBusinessPhoneNumberError =>
            !string.IsNullOrEmpty(BusinessPhoneNumberError);

        public bool ReserveBusinessOwnerNameError =>
            HasBusinessOwnerNameError;

        public bool ReserveBusinessNameError =>
            HasBusinessNameError;

        public bool ReserveBusinessTypeError =>
            HasBusinessTypeError;

        public bool ReserveBusinessEmailError =>
            HasBusinessEmailError;

        public bool ReserveBusinessAddressError =>
            HasBusinessAddressError;

        public bool ReserveBusinessCountryError =>
            HasBusinessCountryError;

        public bool ReserveBusinessStateError =>
            HasBusinessStateError;

        public bool ReserveBusinessCityError =>
            HasBusinessCityError;

        public bool ReserveBusinessPhoneError =>
            HasBusinessPhoneNumberError; 

        #endregion

        private void RefreshValidationProperties()
        {
            OnPropertyChanged(nameof(BusinessOwnerNameError));
            OnPropertyChanged(nameof(BusinessNameError));
            OnPropertyChanged(nameof(BusinessTypeError));
            OnPropertyChanged(nameof(BusinessEmailError));
            OnPropertyChanged(nameof(BusinessAddressError));
            OnPropertyChanged(nameof(BusinessCountryError));
            OnPropertyChanged(nameof(BusinessStateError));
            OnPropertyChanged(nameof(BusinessCityError));
            OnPropertyChanged(nameof(BusinessPhoneNumberError));

            OnPropertyChanged(nameof(HasBusinessOwnerNameError));
            OnPropertyChanged(nameof(HasBusinessNameError));
            OnPropertyChanged(nameof(HasBusinessTypeError));
            OnPropertyChanged(nameof(HasBusinessEmailError));
            OnPropertyChanged(nameof(HasBusinessAddressError));
            OnPropertyChanged(nameof(HasBusinessCountryError));
            OnPropertyChanged(nameof(HasBusinessStateError));
            OnPropertyChanged(nameof(HasBusinessCityError));
            OnPropertyChanged(nameof(HasBusinessPhoneNumberError));

            OnPropertyChanged(nameof(ReserveBusinessOwnerNameError));
            OnPropertyChanged(nameof(ReserveBusinessNameError));
            OnPropertyChanged(nameof(ReserveBusinessTypeError));
            OnPropertyChanged(nameof(ReserveBusinessEmailError));
            OnPropertyChanged(nameof(ReserveBusinessAddressError));
            OnPropertyChanged(nameof(ReserveBusinessCountryError));
            OnPropertyChanged(nameof(ReserveBusinessStateError));
            OnPropertyChanged(nameof(ReserveBusinessCityError));
            OnPropertyChanged(nameof(ReserveBusinessPhoneError));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
