using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EssentialMAUIUIKit.Models.Notification;
using EssentialMAUIUIKit.ViewModel;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View model bind surface for the e-commerce notifications page.
    /// Data is sourced from <see cref="NotificationMockDataService"/> rather
    /// than inline JSON, which keeps the view models thin and the seed
    /// content in a single, testable location.
    /// </summary>
    public class ECommerceNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ECommerceNotificationsListModel>? ecommerceNotifications;
        private string? statusMessage;
        private ICommand? markAllAsReadCommand;

        public ECommerceNotificationViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<ECommerceNotificationsListModel>? EcommerceNotifications
        {
            get => ecommerceNotifications;
            set
            {
                ecommerceNotifications = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// UI-friendly status message shown when the data load fails or
        /// the collection is empty. Keeping it on the view model lets the
        /// page surface a fallback state instead of silently swallowing errors.
        /// </summary>
        public string? StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }

        public void PopulateData()
        {
            var seed = NotificationMockDataService.GetECommerceNotifications();
            if (seed is null || seed.Count == 0)
            {
                StatusMessage = "No notifications available.";
                EcommerceNotifications = new ObservableCollection<ECommerceNotificationsListModel>();
                return;
            }

            EcommerceNotifications = new ObservableCollection<ECommerceNotificationsListModel>(seed);
            StatusMessage = string.Empty;
        }

        /// <summary>
        /// Command-driven "mark all as read" action. Drives the existing
        /// button via <c>Command="{Binding MarkAllAsReadCommand}"</c> so the
        /// behavior is consistent with the social and task notification pages.
        /// </summary>
        public ICommand? MarkAllAsReadCommand
        {
            get
            {
                return markAllAsReadCommand ??= new Command(() =>
                {
                    if (EcommerceNotifications is null)
                    {
                        return;
                    }

                    foreach (var item in EcommerceNotifications)
                    {
                        item.IsRead = true;
                    }

                    OnPropertyChanged(nameof(EcommerceNotifications));
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
