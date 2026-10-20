using System.Collections.Generic;
using EssentialMAUIUIKit.Models.Notification;

namespace EssentialMAUIUIKit.ViewModel
{
    /// <summary>
    /// Centralized, static mock data source for the notification demo pages.
    /// Keeping the seed content in one place allows all notification view models
    /// to share a single source of truth rather than each view model carrying
    /// its own embedded JSON payload.
    /// </summary>
    internal static class NotificationMockDataService
    {
        /// <summary>
        /// Returns a shared list of e-commerce notifications. A new list instance
        /// is returned on every call so callers can wrap it in an observable
        /// collection without sharing mutation state.
        /// </summary>
        public static List<ECommerceNotificationsListModel> GetECommerceNotifications() => new()
        {
            new ECommerceNotificationsListModel
            {
                NotificationIcon = "Delivered",
                Description = "Delivered: Your package of boAt BassHeads 100 Stereo In-Ear Earphones (Black)",
                BackgroundColor = "#f29f40",
                Time = "5 Mins ago",
                IsRead = false
            },
            new ECommerceNotificationsListModel
            {
                NotificationIcon = "Offer",
                Description = "Get 20% OFF on Home Products. Offer Valid for 24 hours.",
                BackgroundColor = "#6c88ff",
                Time = "4 hours ago",
                IsRead = true
            },
            new ECommerceNotificationsListModel
            {
                NotificationIcon = "FlashSale",
                Description = "Flash Sale starting tomorrow. Don't forget to check it out.",
                BackgroundColor = "#a8d35f",
                Time = "9 hours ago",
                IsRead = true
            },
            new ECommerceNotificationsListModel
            {
                NotificationIcon = "Arrived",
                Description = "Package order #246734 has arrived.",
                BackgroundColor = "#cf62e2",
                Time = "9 hours ago",
                IsRead = true
            }
        };

        /// <summary>
        /// Returns the recent social notifications seed payload.
        /// </summary>
        public static List<SocialNotificationItem> GetRecentSocialNotifications() => new()
        {
            new SocialNotificationItem
            {
                Name = "John Doe sent you a friend request.",
                ReceivedTime = "1 hr ago",
                ProfileImage = "ProfileImage2.png",
                IsRead = false
            },
            new SocialNotificationItem
            {
                Name = "You have a new friend suggestion: John Doe",
                ReceivedTime = "2 hrs ago",
                ProfileImage = "ProfileImage2.png",
                IsRead = false
            }
        };

        /// <summary>
        /// Returns the earlier (last 7 days) social notifications seed payload.
        /// </summary>
        public static List<SocialNotificationItem> GetEarlierSocialNotifications() => new()
        {
            new SocialNotificationItem
            {
                Name = "Milton Lane invited you to like Syncfusion.",
                ReceivedTime = "6 hrs ago",
                ProfileImage = "ProfileImage1.png",
                IsRead = true
            },
            new SocialNotificationItem
            {
                Name = "Stella Blake commented on your post.",
                ReceivedTime = "2d ago",
                ProfileImage = "ProfileImage5.png",
                IsRead = false
            },
            new SocialNotificationItem
            {
                Name = "Rosetta Lane and Luella Green like your photo.",
                ReceivedTime = "3d ago",
                ProfileImage = "ProfileImage7.png",
                IsRead = true
            },
            new SocialNotificationItem
            {
                Name = "Darrell Silva likes your photo.",
                ReceivedTime = "4d ago",
                ProfileImage = "ProfileImage6.png",
                IsRead = true
            }
        };

        /// <summary>
        /// Returns the seed payload for task notifications.
        /// </summary>
        public static List<TaskNotificationItem> GetTaskNotifications() => new()
        {
            new TaskNotificationItem
            {
                UserName = "AB",
                BackgroundColor = "#837bff",
                Description = "Provide banner image for new control",
                Detail = "Please review this image and send me your feedback.",
                TaskID = "Ticket- #13578",
                Time = "12:03",
                IsRead = false
            },
            new TaskNotificationItem
            {
                UserName = "BR",
                BackgroundColor = "#678cc8",
                Description = "Provide banner image for new control",
                Detail = "Sarah Pyke attached new image",
                TaskID = "Ticket- #13578",
                Time = "11:30",
                IsRead = false
            },
            new TaskNotificationItem
            {
                UserName = "DM",
                BackgroundColor = "#29aaa0",
                Description = "Need .gif image for attached document",
                Detail = "Larry Burton updated images in task",
                TaskID = "Ticket- #13934",
                Time = "07:30",
                IsRead = true
            },
            new TaskNotificationItem
            {
                UserName = "ER",
                BackgroundColor = "#db7faa",
                Description = "Provide banner image for new control",
                Detail = "Please review this image and send me your feedback.",
                TaskID = "Ticket- #13578",
                Time = "06:12",
                IsRead = false
            },
            new TaskNotificationItem
            {
                UserName = "EN",
                BackgroundColor = "#dc9737",
                Description = "Provide banner image for new control",
                Detail = "Larry Burton updated images in task",
                TaskID = "Ticket- #13578",
                Time = "12:03",
                IsRead = true
            },
            new TaskNotificationItem
            {
                UserName = "DM",
                BackgroundColor = "#a8d35f",
                Description = "Need .gif image for attached document",
                Detail = "Larry Burton updated images in task",
                TaskID = "Ticket- #13934",
                Time = "11:30",
                IsRead = true
            }
        };
    }
}
