using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DeliveryAddress>? deliveryAddress;
        private ObservableCollection<PaymentMode>? paymentModes;

        public CheckoutViewModel()
        {
            PopulateData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<DeliveryAddress>? DeliveryAddress
        {
            get => deliveryAddress;
            set
            {
                deliveryAddress = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PaymentMode>? PaymentModes
        {
            get => paymentModes;
            set
            {
                paymentModes = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PopulateData()
        {
            string jsonData = @"
        {
            ""deliveryAddress"": [
                {
                    ""customerId"": 1,
                    ""customerName"": ""John Doe"",
                    ""addressType"": ""Home"",
                    ""address"": ""410 Terry Ave N, USA"",
                    ""mobileNumber"": ""+1-202-555-0101""
                },
                {
                    ""customerId"": 1,
                    ""customerName"": ""John Doe"",
                    ""addressType"": ""Office"",
                    ""address"": ""388 Fort Worth, Texas, United States"",
                    ""mobileNumber"": ""+1-356-636-8572""
                }
            ],
            ""paymentModes"": [
                {
                    ""paymentModeName"": ""Goldman Sachs Bank Credit Card"",
                    ""cardNumber"": ""48** **** **** 9876""
                },
                {
                    ""paymentModeName"": ""Wells Fargo Bank Credit Card"",
                    ""cardNumber"": ""52** **** **** 4021""
                }                
            ]
        }";
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<Data>(jsonData, options);

            if (data?.DeliveryAddress != null)
            {
                DeliveryAddress = new ObservableCollection<DeliveryAddress>(data.DeliveryAddress);
            }

            if (data?.PaymentModes != null)
            {
                PaymentModes = new ObservableCollection<PaymentMode>(data.PaymentModes);
            }
        }
    }

    public class PaymentMode
    {
        public string? PaymentModeName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardTypeIcon { get; set; }
    }

    public class DeliveryAddress
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
    }

    public class Data
    {
        public List<DeliveryAddress>? DeliveryAddress { get; set; }
        public List<PaymentMode>? PaymentModes { get; set; }
    }
}
