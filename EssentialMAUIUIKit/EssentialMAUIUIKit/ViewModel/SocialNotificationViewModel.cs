using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EssentialMAUIUIKit.ViewModel;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View model bind surface for the social notifications page.
    /// All seed data lives in <see cref="NotificationMockDataService"/>.
    /// </summary>
    public class SocialNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SocialNotificationItem>? recentSocialNotifications;
        private ObservableCollection<SocialNotificationItem>? earlierSocialNotifications;
        private string? statusMessage;
        private ICommand? markAllAsReadCommand;

        public SocialNotificationViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<SocialNotificationItem>? RecentSocialNotifications
        {
            get => recentSocialNotifications;
            set
            {
                recentSocialNotifications = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SocialNotificationItem>? EarlierSocialNotifications
        {
            get => earlierSocialNotifications;
            set
            {
                earlierSocialNotifications = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Optional status message shown when the data load fails.
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
            var recent = NotificationMockDataService.GetRecentSocialNotifications();
            var earlier = NotificationMockDataService.GetEarlierSocialNotifications();

            if (recent is null || earlier is null)
            {
                StatusMessage = "Unable to load notifications.";
                RecentSocialNotifications = new ObservableCollection<SocialNotificationItem>();
                EarlierSocialNotifications = new ObservableCollection<SocialNotificationItem>();
                return;
            }

            RecentSocialNotifications = new ObservableCollection<SocialNotificationItem>(recent);
            EarlierSocialNotifications = new ObservableCollection<SocialNotificationItem>(earlier);
            StatusMessage = string.Empty;
        }

        /// <summary>
        /// Command-driven "mark all as read" action. Drives the page's
        /// "Mark all as read" affordance via <c>Command="{Binding MarkAllAsReadCommand}"</c>
        /// and normalizes the read state across both lists.
        /// </summary>
        public ICommand? MarkAllAsReadCommand
        {
            get
            {
                return markAllAsReadCommand ??= new Command(() =>
                {
                    MarkRead(RecentSocialNotifications);
                    MarkRead(EarlierSocialNotifications);
                    OnPropertyChanged(nameof(RecentSocialNotifications));
                    OnPropertyChanged(nameof(EarlierSocialNotifications));
                });
            }
        }

        private static void MarkRead(ObservableCollection<SocialNotificationItem>? items)
        {
            if (items is null)
            {
                return;
            }

            foreach (var item in items)
            {
                item.IsRead = true;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Lightweight social notification payload. The image path is exposed
    /// as a fully-qualified URL via <see cref="ProfileImage"/> so bindings
    /// never need to concatenate the image server path on the page side.
    /// </summary>
    public class SocialNotificationItem : INotifyPropertyChanged
    {
        private string? profileImage;
        private bool isRead;
        private string? semanticDescription;

        public string? Name { get; set; }
        public string? ReceivedTime { get; set; }

        public string? ProfileImage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(profileImage))
                {
                    return null;
                }

                if (profileImage.StartsWith("http://", System.StringComparison.OrdinalIgnoreCase) ||
                    profileImage.StartsWith("https://", System.StringComparison.OrdinalIgnoreCase))
                {
                    return profileImage;
                }

                return App.ImageServerPath + profileImage;
            }
            set
            {
                if (profileImage == value)
                {
                    return;
                }

                profileImage = value;
                semanticDescription = null;
                OnPropertyChanged();
            }
        }

        public bool IsRead
        {
            get => isRead;
            set
            {
                if (isRead == value)
                {
                    return;
                }

                isRead = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SemanticDescription));
            }
        }

        /// <summary>
        /// Screen reader friendly description combining the notification
        /// text, time, and read state.
        /// </summary>
        public string SemanticDescription
        {
            get => semanticDescription ??= string.IsNullOrWhiteSpace(ReceivedTime)
                ? $"{Name}, {(isRead ? "read" : "unread")}"
                : $"{Name}, {ReceivedTime}, {(isRead ? "read" : "unread")}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName is nameof(Name) or nameof(ReceivedTime) or nameof(IsRead))
            {
                semanticDescription = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SemanticDescription)));
            }
        }
    }
}
