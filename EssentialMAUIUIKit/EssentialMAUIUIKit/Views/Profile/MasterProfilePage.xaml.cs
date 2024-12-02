namespace EssentialMAUIUIKit.Views.Profile
{
    public partial class MasterProfilePage : ContentView
    {
        public MasterProfilePage()
        {
            InitializeComponent();
            this.ProfileImage.Source = App.ImageServerPath + "ProfileImage1.png";
        }
    }
}