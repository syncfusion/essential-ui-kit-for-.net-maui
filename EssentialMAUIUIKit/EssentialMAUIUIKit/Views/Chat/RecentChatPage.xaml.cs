using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Chat
{
    /// <summary>
    /// Code-behind for the Recent Chat list page. The view-model is supplied
    /// in code-behind so XAML stays free of view-model declarations; the
    /// header profile image is bound declaratively through the
    /// ActiveChatImage property on the view-model.
    /// </summary>
    public partial class RecentChatPage : ContentView
    {
        public RecentChatPage()
        {
            InitializeComponent();

            // View-model is wired here, in code-behind, per project convention.
            this.BindingContext = new RecentChatViewModel();
        }
    }
}