using EssentialMAUIUIKit.Models.Notification;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ECommerceNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ECommerceNotificationsListModel>? ecommerceNotifications;

        public ObservableCollection<ECommerceNotificationsListModel>? EcommerceNotifications
        {
            get => ecommerceNotifications;
            set
            {
                ecommerceNotifications = value;
                OnPropertyChanged();
            }
        }

        public ECommerceNotificationViewModel()
        {
            PopulateData();
        }

        public void PopulateData()
        {
            string jsonData = @"
        {
            ""ecommerceNotificationPageList"": [
                {
                    ""notificationIcon"": ""Delivered"",
                    ""description"": ""Delivered: Your package of boAt BassHeads 100 Stereo In-Ear Earphones (Black)"",
                    ""backgroundColor"": ""#f29f40"",
                    ""time"": ""5 Mins ago"",
                    ""isRead"": false
                },
                {
                    ""notificationIcon"": ""Offer"",
                    ""description"": ""Get 20% OFF on Home Products. Offer Valid for 24 hours."",
                    ""backgroundColor"": ""#6c88ff"",
                    ""time"": ""4 hours ago"",
                    ""isRead"": true
                },
                {
                    ""notificationIcon"": ""FlashSale"",
                    ""description"": ""Flash Sale starting tomorrow. Don't forget to check it out."",
                    ""backgroundColor"": ""#a8d35f"",
                    ""time"": ""9 hours ago"",
                    ""isRead"": true
                },
                {
                    ""notificationIcon"": ""Arrived"",
                    ""description"": ""Package order #246734 has arrived."",
                    ""backgroundColor"": ""#cf62e2"",
                    ""time"": ""9 hours ago"",
                    ""isRead"": true
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<EcommerceNotificationsList>(jsonData, options);
            if (data?.EcommerceNotificationPageList == null)
            {
                return;
            }

            EcommerceNotifications = new ObservableCollection<ECommerceNotificationsListModel>(data.EcommerceNotificationPageList);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EcommerceNotificationsList
    {
        public ObservableCollection<ECommerceNotificationsListModel>? EcommerceNotificationPageList { get; set; }
    }
}
