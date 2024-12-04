using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class SocialNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SocialNotification>? recentSocialNotifications;
        private ObservableCollection<SocialNotification>? earlierSocialNotifications;

        public SocialNotificationViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<SocialNotification>? RecentSocialNotifications
        {
            get => recentSocialNotifications;
            set
            {
                recentSocialNotifications = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SocialNotification>? EarlierSocialNotifications
        {
            get => earlierSocialNotifications;
            set
            {
                earlierSocialNotifications = value;
                OnPropertyChanged();
            }
        }

        public void PopulateData()
        {
            string jsonData = @"
        {
            ""recentSocialNotificationList"": [
                {
                    ""name"": ""John Doe sent you a friend request."",
                    ""receivedTime"": ""2 mins ago"",
                    ""profileImage"": ""ProfileImage2.png"",
                    ""isRead"": false
                },
                {
                    ""name"": ""You have a new friend suggestion: John Doe"",
                    ""receivedTime"": ""5 mins ago"",
                    ""profileImage"": ""ProfileImage2.png"",
                    ""isRead"": false
                }
            ],
            ""earlierSocialNotificationList"": [
                {
                    ""name"": ""Milton Lane invited you to like Syncfusion."",
                    ""receivedTime"": ""4 hours ago"",
                    ""profileImage"": ""ProfileImage1.png"",
                    ""isRead"": true
                },
                {
                    ""name"": ""Stella Blake commented on your post."",
                    ""receivedTime"": ""8 hours ago"",
                    ""profileImage"": ""ProfileImage5.png"",
                    ""isRead"": false
                },
                {
                    ""name"": ""Rosetta Lane and Luella Green like your photo."",
                    ""receivedTime"": ""9 hours ago"",
                    ""profileImage"": ""ProfileImage7.png"",
                    ""isRead"": true
                },
                {
                    ""name"": ""Darrell Silva likes your photo."",
                    ""receivedTime"": ""9 hours ago"",
                    ""profileImage"": ""ProfileImage6.png"",
                    ""isRead"": true
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SocialNotifications>(jsonData, options);
            if (data?.RecentSocialNotificationList == null || data?.EarlierSocialNotificationList == null)
            {
                return;
            }

            RecentSocialNotifications = new ObservableCollection<SocialNotification>(data.RecentSocialNotificationList);
            EarlierSocialNotifications = new ObservableCollection<SocialNotification>(data.EarlierSocialNotificationList);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SocialNotification
    {
        private string? profileImage;
        public string? Name { get; set; }
        public string? ReceivedTime { get; set; }
        public string? ProfileImage
        {
            get
            {
                return App.ImageServerPath + profileImage;
            }
            set { this.profileImage = value; }
        }

        public bool IsRead { get; set; }
    }

    public class SocialNotifications
    {
        public List<SocialNotification>? RecentSocialNotificationList { get; set; }
        public List<SocialNotification>? EarlierSocialNotificationList { get; set; }
    }
}
