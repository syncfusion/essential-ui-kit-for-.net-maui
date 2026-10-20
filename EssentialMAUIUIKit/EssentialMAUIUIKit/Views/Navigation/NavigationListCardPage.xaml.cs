namespace EssentialMAUIUIKit.Views.Navigation
{
    public partial class NavigationListCardPage : ContentView
    {
        public NavigationListCardPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, TappedEventArgs e)
        {
            if (sender is Border border)
            {
                await border.ScaleToAsync(0.97, 80, Easing.CubicOut);
                await border.ScaleToAsync(1.0, 80, Easing.CubicIn);
            }
        }
    }
}