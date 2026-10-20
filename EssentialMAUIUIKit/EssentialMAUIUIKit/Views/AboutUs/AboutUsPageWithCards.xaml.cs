namespace EssentialMAUIUIKit.Views.AboutUs
{
    public partial class AboutUsPageWithCards : ContentView
    {
        public AboutUsPageWithCards()
        {
            InitializeComponent();
        }
        private async void ProfileButton_Tapped(object sender, TappedEventArgs e)
        {
            // Click effect: shrink then restore
            await ProfileAvatarBorder.ScaleToAsync(0.88, length: 80, easing: Easing.CubicOut);
            await ProfileAvatarBorder.ScaleToAsync(1.0, length: 120, easing: Easing.CubicIn);
        }
    }
}