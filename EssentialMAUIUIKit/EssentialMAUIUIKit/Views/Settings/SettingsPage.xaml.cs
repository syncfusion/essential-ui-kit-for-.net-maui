namespace EssentialMAUIUIKit.Views.Settings
{
    public partial class SettingsPage : ContentView
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.profileImage.Source = App.ImageServerPath + "ProfileImage1.png";
        }
    }
}