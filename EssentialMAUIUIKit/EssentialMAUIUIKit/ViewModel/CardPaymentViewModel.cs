using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class CardPaymentViewModel
    {
        public CardPaymentInfo ContactsInfo { get; set; }

        public List<CardPaymentInfo> CardDetails { get; set; }

        public ICommand MakePaymentCommand { get; }

        public CardPaymentViewModel()
        {
            ContactsInfo = new CardPaymentInfo();

            CardDetails = new List<CardPaymentInfo>()
            {
                new CardPaymentInfo()
                {
                    CardNumber = "XXXX XXXX XXXX 3456",
                    ExpiryDate = "08/2031",
                    CVV = "123",
                    CardHolderName = "John Doe"
                },
                new CardPaymentInfo()
                {
                    CardNumber = "XXXX XXXX XXXX 4567",
                    ExpiryDate = "06/2029",
                    CVV = "456",
                    CardHolderName = "John Doe"
                }
            };

            MakePaymentCommand = new Command(OnMakePayment);
        }

        private void OnMakePayment()
        {
            ContactsInfo.ShowValidation = true;
        }
    }

    public class CardPaymentInfo : INotifyPropertyChanged
    {
        private string cardNumber = string.Empty;
        private string cvv = string.Empty;
        private string cardHolderName = string.Empty;
        private string expiryDate = string.Empty;
        private bool showValidation;

        public string CardNumber
        {
            get => cardNumber;
            set
            {
                if (cardNumber == value)
                    return;

                cardNumber = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string ExpiryDate
        {
            get => expiryDate;
            set
            {
                string formattedValue = FormatExpiryDate(value);

                if (expiryDate == formattedValue)
                    return;

                expiryDate = formattedValue;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string CVV
        {
            get => cvv;
            set
            {
                if (cvv == value)
                    return;

                cvv = value;

                OnPropertyChanged();
                RefreshValidationProperties();
            }
        }

        public string CardHolderName
        {
            get => cardHolderName;
            set
            {
                if (cardHolderName == value)
                    return;

                cardHolderName = value;

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

        public string CardNumberError =>
            ShowValidation && string.IsNullOrWhiteSpace(CardNumber)
                ? "Card number is required"
                : string.Empty;

        public string CVVError =>
            ShowValidation && string.IsNullOrWhiteSpace(CVV)
                ? "CVV is required"
                : string.Empty;

        public string CardHolderNameError =>
            ShowValidation && string.IsNullOrWhiteSpace(CardHolderName)
                ? "Card holder name is required"
                : string.Empty;

        public string ExpiryDateError
        {
            get
            {
                if (!ShowValidation)
                    return string.Empty;

                if (string.IsNullOrWhiteSpace(ExpiryDate))
                    return "Expiry date is required";

                if (!IsValidExpiryDate())
                    return "Enter a valid expiry date";

                return string.Empty;
            }
        }

        #endregion

        #region HasError

        public bool HasCardNumberError =>
            !string.IsNullOrEmpty(CardNumberError);

        public bool HasCVVError =>
            !string.IsNullOrEmpty(CVVError);

        public bool HasCardHolderNameError =>
            !string.IsNullOrEmpty(CardHolderNameError);

        public bool HasExpiryDateError =>
            !string.IsNullOrEmpty(ExpiryDateError);

        public bool ReserveCardNumberSpace =>
            HasCardNumberError;

        public bool ReserveExpiryDateSpace =>
            HasExpiryDateError;

        public bool ReserveCVVSpace =>
            HasCVVError;

        public bool ReserveCardHolderNameSpace =>
            HasCardHolderNameError;

        #endregion

        private void RefreshValidationProperties()
        {
            OnPropertyChanged(nameof(CardNumberError));
            OnPropertyChanged(nameof(CVVError));
            OnPropertyChanged(nameof(CardHolderNameError));
            OnPropertyChanged(nameof(ExpiryDateError));

            OnPropertyChanged(nameof(HasCardNumberError));
            OnPropertyChanged(nameof(HasCVVError));
            OnPropertyChanged(nameof(HasCardHolderNameError));
            OnPropertyChanged(nameof(HasExpiryDateError));

            OnPropertyChanged(nameof(ReserveCardNumberSpace));
            OnPropertyChanged(nameof(ReserveExpiryDateSpace));
            OnPropertyChanged(nameof(ReserveCVVSpace));
            OnPropertyChanged(nameof(ReserveCardHolderNameSpace));
        }

        private string FormatExpiryDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string digits = new string(value.Where(char.IsDigit).ToArray());

            if (digits.Length > 6)
                digits = digits[..6];

            if (digits.Length <= 2)
                return digits;

            return digits.Insert(2, "/");
        }

        private bool IsValidExpiryDate()
        {
            if (string.IsNullOrWhiteSpace(ExpiryDate))
                return false;

            string[] parts = ExpiryDate.Split('/');

            if (parts.Length != 2)
                return false;

            if (!int.TryParse(parts[0], out int month))
                return false;

            if (!int.TryParse(parts[1], out int year))
                return false;

            if (month < 1 || month > 12)
                return false;

            if (year < DateTime.Now.Year)
                return false;

            if (year == DateTime.Now.Year &&
                month < DateTime.Now.Month)
                return false;

            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}