using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EssentialMAUIUIKit.ViewModel;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View model bind surface for the task notifications page.
    /// All seed data lives in <see cref="NotificationMockDataService"/>.
    /// </summary>
    public class TaskNotificationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskNotificationItem>? todayTaskNotifications;
        private ObservableCollection<TaskNotificationItem>? yesterdayTaskNotifications;
        private string? statusMessage;
        private ICommand? markAllAsReadCommand;

        public TaskNotificationViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<TaskNotificationItem>? TodayTaskNotifications
        {
            get => todayTaskNotifications;
            set
            {
                todayTaskNotifications = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TaskNotificationItem>? YesterdayTaskNotifications
        {
            get => yesterdayTaskNotifications;
            set
            {
                yesterdayTaskNotifications = value;
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

        /// <summary>
        /// Command-driven "mark all as read" action. Drives the existing
        /// button via <c>Command="{Binding MarkAllAsReadCommand}"</c> instead
        /// of leaving it as a static UI affordance.
        /// </summary>
        public ICommand? MarkAllAsReadCommand
        {
            get
            {
                return markAllAsReadCommand ??= new Command(() =>
                {
                    if (TodayTaskNotifications is null && YesterdayTaskNotifications is null)
                    {
                        return;
                    }

                    MarkAllRead(TodayTaskNotifications);
                    MarkAllRead(YesterdayTaskNotifications);
                    OnPropertyChanged(nameof(TodayTaskNotifications));
                    OnPropertyChanged(nameof(YesterdayTaskNotifications));
                });
            }
        }

        public void PopulateData()
        {
            var notifications = NotificationMockDataService.GetTaskNotifications();

            if (notifications is null || notifications.Count == 0)
            {
                StatusMessage = "No task notifications.";
                TodayTaskNotifications = new ObservableCollection<TaskNotificationItem>();
                YesterdayTaskNotifications = new ObservableCollection<TaskNotificationItem>();
                return;
            }

            // Split the seed content between today/yesterday buckets. The
            // split mirrors the visual layout so the page bindings stay
            // distinct and easy to reason about.
            int todayCount = Math.Min(4, notifications.Count);
            var today = notifications.Take(todayCount).ToList();
            var yesterday = notifications.Skip(todayCount).ToList();

            TodayTaskNotifications = new ObservableCollection<TaskNotificationItem>(today);
            YesterdayTaskNotifications = new ObservableCollection<TaskNotificationItem>(yesterday);
            StatusMessage = string.Empty;
        }

        private static void MarkAllRead(ObservableCollection<TaskNotificationItem>? items)
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
    /// Single task notification payload bound to the task list item template.
    /// Implements <see cref="INotifyPropertyChanged"/> so the
    /// <see cref="IsRead"/> state propagates to the UI when the
    /// "Mark all as read" command runs.
    /// </summary>
    public class TaskNotificationItem : INotifyPropertyChanged
    {
        private bool isRead;
        private string? semanticDescription;

        public string? UserName { get; set; }
        public string? BackgroundColor { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? TaskID { get; set; }
        public string? Time { get; set; }

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
        /// Screen reader friendly description combining the description,
        /// detail, ticket id, and read state.
        /// </summary>
        public string SemanticDescription
        {
            get => semanticDescription ??= string.IsNullOrWhiteSpace(TaskID)
                ? $"{Description}. {Detail}, {(isRead ? "read" : "unread")}"
                : $"{Description}. {Detail} {TaskID}, {(isRead ? "read" : "unread")}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName is nameof(Description) or nameof(Detail) or nameof(TaskID) or nameof(IsRead))
            {
                semanticDescription = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SemanticDescription)));
            }
        }
    }
}
