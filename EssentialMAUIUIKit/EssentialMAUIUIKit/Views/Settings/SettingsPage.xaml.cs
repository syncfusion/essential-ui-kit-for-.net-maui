namespace EssentialMAUIUIKit.Views.Settings
{
    public partial class SettingsPage : ContentView
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.profileImage.ImageSource = App.ImageServerPath + "ProfileImage1.png";
            this.HelpPage.Content = new HelpPage();
        }
    }
}