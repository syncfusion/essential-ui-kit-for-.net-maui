using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EssentialMAUIUIKit.ViewModel;

namespace EssentialMAUIUIKit
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DeliveryAddress>? deliveryAddress;
        private ObservableCollection<PaymentMode>? paymentModes;
        private ObservableCollection<QuickPaymentMethod>? quickPaymentMethods;
        private ObservableCollection<OrderItem>? orderItems;
        private ObservableCollection<PriceLine>? priceLines;
        private DeliveryAddress? selectedAddress;
        private PaymentMode? selectedPaymentMode;
        private decimal totalAmount;
        private decimal savings;
        private string orderId = string.Empty;

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

        public ObservableCollection<QuickPaymentMethod>? QuickPaymentMethods
        {
            get => quickPaymentMethods;
            set
            {
                quickPaymentMethods = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<OrderItem>? OrderItems
        {
            get => orderItems;
            set
            {
                orderItems = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PriceLine>? PriceLines
        {
            get => priceLines;
            set
            {
                priceLines = value;
                OnPropertyChanged();
            }
        }

        public DeliveryAddress? SelectedAddress
        {
            get => selectedAddress;
            set
            {
                selectedAddress = value;
                OnPropertyChanged();
            }
        }

        public PaymentMode? SelectedPaymentMode
        {
            get => selectedPaymentMode;
            set
            {
                selectedPaymentMode = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get => totalAmount;
            set
            {
                totalAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal Savings
        {
            get => savings;
            set
            {
                savings = value;
                OnPropertyChanged();
            }
        }

        public string OrderId
        {
            get => orderId;
            set
            {
                orderId = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlaceOrderCommand => new Command(() =>
        {
            // Sample command hook; real flows would navigate to a success/failure page.
        });

        public void PopulateData()
        {
            var addresses = TransactionMockDataService.GetDeliveryAddresses();
            DeliveryAddress = new ObservableCollection<DeliveryAddress>(addresses);
            SelectedAddress = addresses.Count > 0 ? addresses[0] : null;

            var payments = TransactionMockDataService.GetPaymentModes();
            PaymentModes = new ObservableCollection<PaymentMode>(payments);
            SelectedPaymentMode = payments.Count > 0 ? payments[0] : null;

            QuickPaymentMethods = new ObservableCollection<QuickPaymentMethod>(
                TransactionMockDataService.GetQuickPaymentMethods());

            OrderItems = new ObservableCollection<OrderItem>(
                TransactionMockDataService.GetOrderItems());

            PriceLines = new ObservableCollection<PriceLine>(
                TransactionMockDataService.GetPriceLines());

            // Aggregate totals from the seeded data so they can be bound
            // instead of being repeated as literal strings in XAML.
            TotalAmount = 407.00m;
            Savings = 47.00m;
            OrderId = "#89027532";
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PaymentMode
    {
        public string? PaymentModeName { get; set; }
        public string? CardNumber { get; set; }
        public string? CardTypeIcon { get; set; }
        public string? Expiry { get; set; }
        public string? CardType { get; set; }
    }

    public class DeliveryAddress
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
    }
}
