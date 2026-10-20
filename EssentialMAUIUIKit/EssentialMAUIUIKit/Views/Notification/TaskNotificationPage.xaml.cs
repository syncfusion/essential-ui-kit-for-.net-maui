using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Notification
{
    /// <summary>
    /// Hosts the task notifications screen as a self-contained
    /// MAUI <see cref="ContentView"/>. All actions such as
    /// "Mark all as read" are wired through the view model's command.
    /// </summary>
    public partial class TaskNotificationPage : ContentView
    {
        public TaskNotificationPage()
        {
            InitializeComponent();
        }
    }
}
