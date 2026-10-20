using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Transaction
{
    public partial class CheckoutPage : ContentView
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private async void OnCardsTapped(object sender, TappedEventArgs e)
        {
            if (sender is Border border)
            {
                await border.ScaleToAsync(0.97, 80, Easing.CubicOut);
                await border.ScaleToAsync(1.0, 80, Easing.CubicIn);
            }
        }
    }
}