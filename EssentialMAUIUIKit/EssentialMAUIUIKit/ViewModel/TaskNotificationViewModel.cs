using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class TaskNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskNotification>? taskNotifications;

        public TaskNotificationViewModel()
        {
            this.PopulateData();
        }

        public ObservableCollection<TaskNotification>? TaskNotifications
        {
            get => taskNotifications;
            set
            {
                taskNotifications = value;
                OnPropertyChanged();
            }
        }

        public void PopulateData()
        {
            string jsonData = @"
        {
            ""taskNotificationPageList"": [
                {
                    ""userName"": ""AB"",
                    ""backgroundColor"": ""#837bff"",
                    ""description"": ""Provide banner image for new control"",
                    ""detail"": ""Please review this image and send me your feedback."",
                    ""taskID"": ""GRAP-13578"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": false
                },
                {
                    ""userName"": ""BR"",
                    ""backgroundColor"": ""#678cc8"",
                    ""description"": ""Provide banner image for new control"",
                    ""detail"": ""Sarah Pyke attached new image"",
                    ""taskID"": ""GRAP-13578"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": false
                },
                {
                    ""userName"": ""DM"",
                    ""backgroundColor"": ""#29aaa0"",
                    ""description"": ""Need .gif image for attached document"",
                    ""detail"": ""Larry Burton updated images in task"",
                    ""taskID"": ""GRAP-13934"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": true
                },
                {
                    ""userName"": ""ER"",
                    ""backgroundColor"": ""#db7faa"",
                    ""description"": ""Provide banner image for new control"",
                    ""detail"": ""Please review this image and send me your feedback."",
                    ""taskID"": ""GRAP-13578"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": false
                },
                {
                    ""userName"": ""EN"",
                    ""backgroundColor"": ""#dc9737"",
                    ""description"": ""Provide banner image for new control"",
                    ""detail"": ""Larry Burton updated images in task"",
                    ""taskID"": ""GRAP-13578"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": true
                },
                {
                    ""userName"": ""DM"",
                    ""backgroundColor"": ""#a8d35f"",
                    ""description"": ""Need .gif image for attached document"",
                    ""detail"": ""Larry Burton updated images in task"",
                    ""taskID"": ""GRAP-13934"",
                    ""time"": ""2 mins ago"",
                    ""isRead"": true
                }
            ]
        }";

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var notificationsList = JsonSerializer.Deserialize<TaskNotificationsList>(jsonData, options);
                if (notificationsList != null && notificationsList.TaskNotificationPageList != null)
                {
                    TaskNotifications = new ObservableCollection<TaskNotification>(notificationsList.TaskNotificationPageList);
                }
            }
            catch (Exception ex)
            {
                // Handle JSON parsing exceptions
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TaskNotification
    {
        public string? UserName { get; set; }
        public string? BackgroundColor { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? TaskID { get; set; }
        public string? Time { get; set; }
        public bool IsRead { get; set; }
    }

    public class TaskNotificationsList
    {
        public List<TaskNotification>? TaskNotificationPageList { get; set; }
    }

}
