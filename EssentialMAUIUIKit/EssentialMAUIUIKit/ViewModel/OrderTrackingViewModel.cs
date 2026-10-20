using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Syncfusion.Maui.ProgressBar;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View model that powers the order tracking screen. It exposes the
    /// order detail fields, the shipment step list, and a few derived
    /// properties that the XAML binds to declaratively.
    /// </summary>
    public class OrderTrackingViewModel : INotifyPropertyChanged, IDisposable
    {
        // ---- Demo data (replace with a data service in production) ----
        private const string DefaultCustomerName = "John Chris";
        private const string DefaultOrderId = "890976578";
        private const string DefaultTotalPrice = "$450";
        private const string DefaultTotalAmount = "$407";
        private const string DefaultProductName = "Women\u2019s skirt plain long skirt in cotton";
        private const string DefaultDeliveryDateText = "Delivery expected on Mar 23, 2024";
        private const string DefaultArrivingOnText = "Arriving on March 23, 2024";
        private const string DefaultAddressText = "10, Britto street, california, 10, Britto street, california";
        private const string DefaultDiscountText = "-$43";
        private const string DefaultDeliveryChargeText = "$4";
        private const string DefaultProductImageFileName = "Image1.png";

        // ---- Theme palette tokens (mirrored from XAML where needed) ----
        private static readonly Color LightTitle = Color.FromArgb("#313032");
        private static readonly Color DarkTitle = Colors.White;
        private static readonly Color LightSubtitle = Color.FromArgb("#66636A");
        private static readonly Color DarkSubtitle = Color.FromArgb("#B8B8B8");
        private static readonly Color LightIcon = Color.FromArgb("#474648");
        private static readonly Color DarkIcon = Color.FromArgb("#C9C6C8");

        // ---- Step progress defaults (driven the XAML previously hard-coded) ----
        private const int DefaultActiveStepIndex = 1;
        private const double DefaultActiveStepProgressValue = 90;

        private string customerName = string.Empty;
        private string orderId = string.Empty;
        private string totalPrice = string.Empty;
        private string totalAmount = string.Empty;
        private string productName = string.Empty;
        private string deliveryDateText = string.Empty;
        private string arrivingOnText = string.Empty;
        private string addressText = string.Empty;
        private string discountText = string.Empty;
        private string deliveryChargeText = string.Empty;
        private string productImage = string.Empty;
        private int activeStepIndex = DefaultActiveStepIndex;
        private double activeStepProgressValue = DefaultActiveStepProgressValue;
        private ObservableCollection<StepProgressBarItem> shipmentInfoCollection = new();

        private bool isDisposed;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Steps rendered by the shipment progress bar. The setter replaces
        /// the entire collection with a new instance so the
        /// <c>SfStepProgressBar</c> re-renders every step (including its
        /// themed label colors) when the system theme changes. Mutating
        /// the existing collection with <c>Clear()</c> + <c>Add()</c> does
        /// NOT reliably refresh the rendered labels.
        /// </summary>
        public ObservableCollection<StepProgressBarItem> ShipmentInfoCollection
        {
            get => shipmentInfoCollection;
            private set => SetField(ref shipmentInfoCollection, value);
        }

        /// <summary>Customer name on the delivery address.</summary>
        public string CustomerName
        {
            get => customerName;
            set => SetField(ref customerName, value);
        }

        /// <summary>Order identifier shown in the product card.</summary>
        public string OrderId
        {
            get => orderId;
            set => SetField(ref orderId, value);
        }

        /// <summary>Subtotal (price) of the order.</summary>
        public string TotalPrice
        {
            get => totalPrice;
            set => SetField(ref totalPrice, value);
        }

        /// <summary>Final amount after discounts and delivery charges.</summary>
        public string TotalAmount
        {
            get => totalAmount;
            set => SetField(ref totalAmount, value);
        }

        /// <summary>Product name displayed in the order card.</summary>
        public string ProductName
        {
            get => productName;
            set => SetField(ref productName, value);
        }

        /// <summary>Delivery date description (e.g. "Delivery expected on Mar 23, 2024").</summary>
        public string DeliveryDateText
        {
            get => deliveryDateText;
            set => SetField(ref deliveryDateText, value);
        }

        /// <summary>Short "arriving on" line shown on the mobile layout.</summary>
        public string ArrivingOnText
        {
            get => arrivingOnText;
            set => SetField(ref arrivingOnText, value);
        }

        /// <summary>Formatted delivery address.</summary>
        public string AddressText
        {
            get => addressText;
            set => SetField(ref addressText, value);
        }

        /// <summary>Discount amount (e.g. "-$43").</summary>
        public string DiscountText
        {
            get => discountText;
            set => SetField(ref discountText, value);
        }

        /// <summary>Delivery charge text (e.g. "$4").</summary>
        public string DeliveryChargeText
        {
            get => deliveryChargeText;
            set => SetField(ref deliveryChargeText, value);
        }

        /// <summary>Absolute URL of the product image.</summary>
        public string ProductImage
        {
            get => productImage;
            set => SetField(ref productImage, value);
        }

        /// <summary>
        /// Active step index in the progress bar. Two-way bindable so the
        /// view can drive the state from XAML.
        /// </summary>
        public int ActiveStepIndex
        {
            get => activeStepIndex;
            set => SetField(ref activeStepIndex, value);
        }

        /// <summary>
        /// Progress (0-100) of the active step's trailing fill.
        /// </summary>
        public double ActiveStepProgressValue
        {
            get => activeStepProgressValue;
            set => SetField(ref activeStepProgressValue, value);
        }

        /// <summary>
        /// Raised when the user taps the "Coupons Applied" button. The host
        /// page can subscribe to this to navigate to the coupons view.
        /// </summary>
        public event EventHandler? ViewCouponsRequested;

        /// <summary>
        /// Command that surfaces the "view applied coupons" intent. The
        /// handler simply raises <see cref="ViewCouponsRequested"/>; the
        /// surrounding page decides how to respond.
        /// </summary>
        public ICommand ViewCouponsCommand { get; }

        public OrderTrackingViewModel()
        {
            ViewCouponsCommand = new Command(OnViewCouponsRequested);

            CustomerName = DefaultCustomerName;
            OrderId = DefaultOrderId;
            TotalPrice = DefaultTotalPrice;
            TotalAmount = DefaultTotalAmount;
            ProductName = DefaultProductName;
            DeliveryDateText = DefaultDeliveryDateText;
            ArrivingOnText = DefaultArrivingOnText;
            AddressText = DefaultAddressText;
            DiscountText = DefaultDiscountText;
            DeliveryChargeText = DefaultDeliveryChargeText;
            ProductImage = App.ImageServerPath + DefaultProductImageFileName;

            BuildShipmentCollection();

            if (Application.Current is not null)
            {
                Application.Current.RequestedThemeChanged += OnThemeChanged;
            }
        }

        private void OnViewCouponsRequested()
        {
            ViewCouponsRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            BuildShipmentCollection();
        }

        private void BuildShipmentCollection()
        {
            bool isLight = Application.Current?.RequestedTheme == AppTheme.Light;

            Color titleColor = isLight ? LightTitle : DarkTitle;
            Color subtitleColor = isLight ? LightSubtitle : DarkSubtitle;
            Color iconColor = isLight ? LightIcon : DarkIcon;

            // Build a brand-new collection so the SfStepProgressBar re-binds
            // and re-renders every step with the new themed colors. Mutating
            // the existing collection with Clear() + Add() is not picked up
            // reliably by the Syncfusion rotator control.
            ShipmentInfoCollection = new ObservableCollection<StepProgressBarItem>
            {
                new StepProgressBarItem
                {
                    PrimaryFormattedText = BuildStepText("Dispatched", "Mon, 19th May", titleColor, subtitleColor),
                    ProgressTrackSize = 10
                },
                new StepProgressBarItem
                {
                    PrimaryFormattedText = BuildStepText("Out for delivery", "Mar 23, 2024", titleColor, subtitleColor),
                    ProgressTrackSize = 10,
                    ImageSource = new FontImageSource
                    {
                        Glyph = "\ue716",
                        Size = 26,
                        FontFamily = "UIKitIcons",
                        Color = Colors.White
                    }
                },
                new StepProgressBarItem
                {
                    PrimaryFormattedText = BuildStepText("Delivery", "Pending", titleColor, subtitleColor),
                    ImageSource = new FontImageSource
                    {
                        Glyph = "\ue7a3",
                        Size = 32,
                        FontFamily = "MaterialAssets",
                        Color = iconColor
                    }
                }
            };
        }

        /// <summary>
        /// Builds a two-line <see cref="FormattedString"/> for a progress step
        /// (title on top, sub-line underneath) using the supplied theme colors.
        /// </summary>
        private static FormattedString BuildStepText(
            string title,
            string subtitle,
            Color titleColor,
            Color subtitleColor)
        {
            return new FormattedString
            {
                Spans =
                {
                    new Span
                    {
                        Text = title,
                        FontSize = 14,
                        TextColor = titleColor,
                        FontFamily = "Roboto-Medium"
                    },
                    new Span { Text = "\n" },
                    new Span
                    {
                        Text = subtitle,
                        FontSize = 14,
                        TextColor = subtitleColor,
                        FontFamily = "Roboto-Regular"
                    }
                }
            };
        }

        /// <summary>
        /// Releases the theme-change subscription. Safe to call multiple times.
        /// In normal usage the view subscribes/unsubscribes on Loaded/Unloaded,
        /// so this method is only needed when the view model is shared across
        /// multiple views or hosted as a long-lived service.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases resources. Disposes managed resources only when
        /// <paramref name="disposing"/> is <c>true</c>.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing && Application.Current is not null)
            {
                Application.Current.RequestedThemeChanged -= OnThemeChanged;
            }

            isDisposed = true;
        }

        /// <summary>
        /// Sets the backing field and raises <see cref="PropertyChanged"/>
        /// when the value actually changes.
        /// </summary>
        private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}