using Syncfusion.Maui.ProgressBar;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit
{
    public class OrderTrackingViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The shipped formatted string.
        /// </summary>
        private FormattedString shippedFormattedString;

        /// <summary>
        /// The out of delivery formatted string.
        /// </summary>
        private FormattedString outForDeliveryFormattedString;

        /// <summary>
        /// The delivery formatted string.
        /// </summary>
        private FormattedString deliveryFormattedString;

        /// <summary>
        /// The shiffement collection
        /// </summary>
        private ObservableCollection<StepProgressBarItem> shipmentInfoCollection;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The shiffement collection
        /// </summary>
        public ObservableCollection<StepProgressBarItem> ShipmentInfoCollection
        {
            get { return shipmentInfoCollection; }
            set
            {
                if (shipmentInfoCollection != value)
                {
                    shipmentInfoCollection = value;
                    OnPropertyChanged(nameof(ShipmentInfoCollection));
                }
            }
        }

        /// <summary>
        /// Check the application theme is light or dark.
        /// </summary>
        private bool isLightTheme = Application.Current?.RequestedTheme == AppTheme.Light;

        public OrderTrackingViewModel()
        {
            var currentDate = DateTime.Now.AddDays(-2);
            shippedFormattedString = new FormattedString();
            shippedFormattedString.Spans.Add(new Span { Text = "Dispatched", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#313032") : Color.FromArgb("#A572F7"), FontFamily = "Roboto-Medium" });
            shippedFormattedString.Spans.Add(new Span { Text = "\nMar 21, 2024", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#5F5E60") : Color.FromArgb("#929092"), FontFamily = "Roboto-Regular" });

            outForDeliveryFormattedString = new FormattedString();
            outForDeliveryFormattedString.Spans.Add(new Span { Text = "Out for delivery", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#313032") : Color.FromArgb("#A572F7"), FontFamily = "Roboto-Medium" });
            outForDeliveryFormattedString.Spans.Add(new Span { Text = "\nMar 23, 2024", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#5F5E60") : Color.FromArgb("#929092"), FontFamily = "Roboto-Regular" });

            deliveryFormattedString = new FormattedString();
            deliveryFormattedString.Spans.Add(new Span { Text = "Delivery", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#313032") : Color.FromArgb("#A572F7"), FontFamily = "Roboto-Medium" });
            deliveryFormattedString.Spans.Add(new Span { Text = "\nPending", FontSize = 14, TextColor = isLightTheme ? Color.FromArgb("#5F5E60") : Color.FromArgb("#929092"), FontFamily = "Roboto-Regular" });

            shipmentInfoCollection = new ObservableCollection<StepProgressBarItem>();
            shipmentInfoCollection.Add(new StepProgressBarItem() { PrimaryFormattedText = shippedFormattedString });
            shipmentInfoCollection.Add(new StepProgressBarItem() { PrimaryFormattedText = outForDeliveryFormattedString });
            shipmentInfoCollection.Add(new StepProgressBarItem() { PrimaryFormattedText = deliveryFormattedString });
        }

        private string GetFormattedDateText(DateTime dateTime)
        {
            string formattedDate = dateTime.ToString("ddd, d MMM \\'yy 'at' h:mm tt");
            return formattedDate;
        }

        private string GetDaySuffix(DateTime dateTime)
        {
            // Adding 'st', 'nd', 'rd', or 'th' to the day
            string daySuffix;
            switch (dateTime.Day % 10)
            {
                case 1 when dateTime.Day != 11:
                    daySuffix = "st";
                    break;
                case 2 when dateTime.Day != 12:
                    daySuffix = "nd";
                    break;
                case 3 when dateTime.Day != 13:
                    daySuffix = "rd";
                    break;
                default:
                    daySuffix = "th";
                    break;
            }

            return daySuffix;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
